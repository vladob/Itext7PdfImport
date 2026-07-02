using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using PdfProcessingLibrary;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Itext7PdfImport
{
    public class CustomLocationTextExtractionStrategy(int pageNumber) : LocationTextExtractionStrategy
    {
        private readonly List<RectAndText> textChunks = [];
        private readonly int pageNumber = pageNumber;

        public int CurrentPage { get; set; }
        public List<FoundRect> Results { get; } = new();

        public sealed class FoundRect
        {
            public int Page { get; }
            public Rectangle BBox { get; }  // page space
            public bool Filled { get; }
            public bool Stroked { get; }
            public FoundRect(int page, Rectangle bbox, bool filled, bool stroked)
                => (Page, BBox, Filled, Stroked) = (page, bbox, filled, stroked);
        }

        public override void EventOccurred(IEventData data, EventType type)
        {
            if (type == EventType.RENDER_TEXT)
            {
                TextRenderInfo renderInfo = (TextRenderInfo)data;

                // Get the font info from the render info

                var fontName = renderInfo.GetFont().GetFontProgram()?.ToString()?.ToLowerInvariant() ?? "";
                bool isBold = fontName.Contains("bold");
                bool isItalic = fontName.Contains("italic") || fontName.Contains("oblique");

                // Get the bounding box of the text chunk
                // In new version just baseLine will be used
                Rectangle ascentRect = renderInfo.GetAscentLine().GetBoundingRectangle();
                Rectangle descentRect = renderInfo.GetDescentLine().GetBoundingRectangle();
                Rectangle baseRect = renderInfo.GetBaseline().GetBoundingRectangle();

                // Adjust top if is inside boundaries of previous chunk
                // Add the rectangle and the text to the list
                textChunks.Add(new RectAndText(
                    type: "text",
                    left: (int)baseRect.GetLeft(),
                    right: (int)baseRect.GetRight(),
                    top: (int)ascentRect.GetTop(),
                    bottom: (int)descentRect.GetBottom(),
                    baseLine: (int)baseRect.GetTop(),
                    text: renderInfo.GetText(),
                    pageNumber: pageNumber,
                    isBold: isBold,
                    isItalic: isItalic
                 ));
                /// New version will include just Left, Right, BaseLine
                // textChunks.Add(new RectAndText((int)baseRect.GetLeft(), (int)baseRect.GetRight(), (int)baseRect.GetTop(), renderInfo.GetText(), pageNumber));
            }
            /*
            else if (type == EventType.RENDER_PATH)
            {
                var pri = (PathRenderInfo)data;
                foreach (var sp in pri.GetPath().GetSubpaths())
                {
                    if (TryGetRect(sp, pri.GetCtm(), out var rect))
                    {
                        int op = pri.GetOperation();
                        var fillColor = pri.GetFillColor();
                        var strokeColor = pri.GetStrokeColor();
                        var lineWidth = pri.GetLineWidth();
                        var typePri = pri.GetType();
                        var all = pri.ToString();
                        bool filled = (op & PathRenderInfo.FILL) != 0;
                        bool stroked = (op & PathRenderInfo.STROKE) != 0;
                        // ignore hairlines / tiny shapes
                        if ((rect.GetWidth() > 5 || rect.GetHeight() > 5) && filled)
                        {
                            Results.Add(new FoundRect(CurrentPage, rect, filled, stroked));
                            textChunks.Add(new RectAndText(
                                type: "rectangle",
                                left: (int)rect.GetLeft(),
                                right: (int)rect.GetRight(),
                                top: (int)rect.GetTop(),
                                bottom: (int)rect.GetBottom(),
                                baseLine: (int)rect.GetBottom(),
                                text: "!Rectangle!Fill" + fillColor.ToString() + "stroke" + strokeColor.ToString(),
                                pageNumber: pageNumber,
                                isBold: stroked,
                                isItalic: filled
                            ));
                        }
                        else
                        {
                            Debug.Print("Small rectangle");
                        }
                    }
                    else
                    {
                        Debug.Print("Not a rectangle");
                    }
                }
            }
            */
            else if (type == EventType.RENDER_PATH)
            {
                PathRenderInfo renderInfo = (PathRenderInfo)data;
                Matrix ctm = renderInfo.GetGraphicsState().GetCtm();
                textChunks.Add(new RectAndText(
                    type: "line",
                    left: (int)ctm.Get(6),
                    right: 0,
                    top: (int)ctm.Get(7),
                    bottom: (int)ctm.Get(7),
                    baseLine: (int)ctm.Get(7),
                    text: "<line>",
                    pageNumber: pageNumber,
                    isBold: false,
                    isItalic: false
                    ));
                base.EventOccurred(data, type);
            }
            else
            {
                Debug.Print("Other event: " + type.ToString());
            }
        }

        private static bool TryGetRect(iText.Kernel.Geom.Subpath sp, Matrix ctm, out Rectangle rect)
        {
            rect = null;
            var segs = sp.GetSegments();
            if (segs == null || segs.Count == 0) return false;
            if (!sp.IsClosed()) return false;
            if (segs.Any(s => s is not iText.Kernel.Geom.Line)) return false;

            // Collect points and transform to page space
            var pts = new List<Point>();
            pts.Add(segs[0].GetBasePoints()[0]);
            foreach (var s in segs) pts.Add(s.GetBasePoints().Last());
            // drop duplicate last point if closed
            var tpts = pts.Select(p => Transform(ctm, p)).ToList();
            if (Distance(tpts[0], tpts[^1]) < 1e-3) tpts.RemoveAt(tpts.Count - 1);
            if (tpts.Count != 4) return false;

            // Check right angles
            var v0 = Vec(tpts[0], tpts[1]);
            var v1 = Vec(tpts[1], tpts[2]);
            var v2 = Vec(tpts[2], tpts[3]);
            var v3 = Vec(tpts[3], tpts[0]);
            if (!(Orth(v0, v1) && Orth(v1, v2) && Orth(v2, v3) && Orth(v3, v0))) return false;

            float minX = tpts.Min(p => (float)p.GetX());
            float minY = tpts.Min(p => (float)p.GetY());
            float maxX = tpts.Max(p => (float)p.GetX());
            float maxY = tpts.Max(p => (float)p.GetY());
            rect = new Rectangle(minX, minY, maxX - minX, maxY - minY);
            return rect.GetWidth() > 0 && rect.GetHeight() > 0;
        }

        private static Point Transform(Matrix m, Point p)
        {
            var r = m.Multiply(new Matrix((float)p.GetX(), (float)p.GetY()));
            return new Point(r.Get(Matrix.I31), r.Get(Matrix.I32));
        }
        private static Point Vec(Point a, Point b) => new Point(b.GetX() - a.GetX(), b.GetY() - a.GetY());
        private static bool Orth(Point v, Point w)
        {
            double dot = v.GetX() * w.GetX() + v.GetY() * w.GetY();
            double nv = Math.Sqrt(v.GetX() * v.GetX() + v.GetY() * v.GetY());
            double nw = Math.Sqrt(w.GetX() * w.GetX() + w.GetY() * w.GetY());
            if (nv < 1e-6 || nw < 1e-6) return false;
            return Math.Abs(dot / (nv * nw)) < 0.01; // near 90°
        }
        private static double Distance(Point a, Point b)
        {
            double dx = a.GetX() - b.GetX(), dy = a.GetY() - b.GetY();
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public List<RectAndText> GetTextChunks()
        {
            return textChunks;
        }
    }
}
