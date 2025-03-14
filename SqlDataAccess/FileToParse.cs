namespace SqlDataAccess
{
    public class FileToParse
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public string? LayoutName { get; set; }
        public string? Status { get; set; }
        public string? Errors { get; set; }
        public DateTime AddedAt { get; set; }

        public FileToParse(string filePath)
        {
            FullPath = filePath;
            FileName = Path.GetFileName(filePath);
        }

        public FileToParse(string filePath, string layoutName)
        {
            FullPath = filePath;
            FileName = Path.GetFileName(filePath);
            LayoutName = layoutName;
        }
    }
}
