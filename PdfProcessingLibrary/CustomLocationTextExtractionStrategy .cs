using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using PdfProcessingLibrary;

namespace Itext7PdfImport
{
    public class CustomLocationTextExtractionStrategy(int pageNumber) : LocationTextExtractionStrategy
    {
        private readonly List<RectAndText> textChunks = [];
        private readonly int pageNumber = pageNumber;

        public override void EventOccurred(IEventData data, EventType type)
        {
            if (type == EventType.RENDER_TEXT)
            {
                TextRenderInfo renderInfo = (TextRenderInfo)data;

                // Get the bounding box of the text chunk
                // In new version just baseLine will be used
                Rectangle ascentRect = renderInfo.GetAscentLine().GetBoundingRectangle();
                Rectangle descentRect = renderInfo.GetDescentLine().GetBoundingRectangle();
                Rectangle baseRect = renderInfo.GetBaseline().GetBoundingRectangle();

                // Adjust top if is inside boundaries of previous chunk
                // Add the rectangle and the text to the list
                textChunks.Add(new RectAndText("text", (int)baseRect.GetLeft(), (int)baseRect.GetRight(), (int)ascentRect.GetTop(), (int)descentRect.GetBottom(), (int)baseRect.GetTop(), renderInfo.GetText(), pageNumber));
                /// New version will include just Left, Right, BaseLine
                // textChunks.Add(new RectAndText((int)baseRect.GetLeft(), (int)baseRect.GetRight(), (int)baseRect.GetTop(), renderInfo.GetText(), pageNumber));
            } else if (type == EventType.RENDER_PATH)
            {
                PathRenderInfo renderInfo = (PathRenderInfo)data;
                Matrix ctm = renderInfo.GetGraphicsState().GetCtm();
                textChunks.Add(new RectAndText("line", (int)ctm.Get(6), 0, (int)ctm.Get(7), (int)ctm.Get(7), (int)ctm.Get(7),"<line>",pageNumber));
            }
            base.EventOccurred(data, type);
        }

        public List<RectAndText> GetTextChunks()
        {
            return textChunks;
        }
    }
}
