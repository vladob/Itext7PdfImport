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
            } else if (type == EventType.RENDER_PATH)
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
            }
            base.EventOccurred(data, type);
        }

        public List<RectAndText> GetTextChunks()
        {
            return textChunks;
        }
    }
}
