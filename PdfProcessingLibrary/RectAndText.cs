namespace PdfProcessingLibrary
{
    public class RectAndText(string type, int left, int right, int top, int bottom, int baseLine, string text, int pageNumber, bool isBold, bool isItalic)
    {
        public string Type { get; set; } = type;
        public int Left { get; set; } = left;
        public int Right { get; set; } = right;
        public int Top { get; set; } = top;
        public int Bottom { get; set; } = bottom;
        public int BaseLine { get; set; } = baseLine;
        public string Text { get; set; } = text;
        public int PageNumber { get; set; } = pageNumber;
        public bool IsBold { get; set; } = isBold;
        public bool IsItalic { get; set; } = isItalic;

    }
}