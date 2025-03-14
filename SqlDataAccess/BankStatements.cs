using PdfProcessingLibrary;
using System.Data.SqlClient;

namespace SqlDataAccess
{
    public static class BankStatements
    {
        static SqlConnection? con;
        static SqlCommand? cmd;
        static int DocumentId;

        public static event Action<string, string>? ProgressChanged;

        public static int ConnectToDb()
        {
            string connectionString = "server=DELL2023_N04;database=BankStatements; User ID=vb; Password=vb";
            con = new SqlConnection(connectionString);
            con.Open();
            return 0;
        }

        public static int DisconectFromDb()
        {
            cmd = null;
            con?.Close();
            con = null;
            return 0;
        }

        public static int GetDocumentId()
        {
            return DocumentId;
        }

        public static int NewStatement(FileToParse newFile)
        {
            String queryStatement = "INSERT INTO Documents([FileName], [FullPath], [Date]) " + "\r\n"
            + "SELECT '" + newFile.FileName + "' AS[FileName],'" + newFile.FullPath + "' AS[FullPath], GETDATE() AS[Date]";
            cmd = new SqlCommand(queryStatement, con);
            cmd.ExecuteNonQuery();

            queryStatement = "SELECT SCOPE_IDENTITY()";
            cmd = new SqlCommand(queryStatement, con);
            Decimal result = (decimal)cmd.ExecuteScalar();
            DocumentId = Decimal.ToInt32(result);
            cmd = null;

            ProgressChanged?.Invoke($"Header for document {DocumentId} saved.", "Status");

            return 0;
        }

        public static int PopulatePdfRawData(List<RectAndText> extractedData)
        {
            string queryStatementConstant = "INSERT INTO PdfRawdata ([DocId],[Page],[Type],[Left],[Right],[Top],[Bottom],[BaseLine],[Text]) ";
            string queryStmt = "";
            int currentPage = 0;

            if (extractedData != null)
            {
                int numberOfPages = extractedData.LastOrDefault()?.PageNumber ?? 0;
                foreach (RectAndText item in extractedData.OrderBy(p => p.PageNumber).ThenByDescending(p => p.BaseLine).ThenBy(p => p.Left))
                {
                    if (item.PageNumber != currentPage)
                    {
                        currentPage = item.PageNumber;
                        ProgressChanged?.Invoke(arg1: $"Saving data for page {currentPage} of {numberOfPages}", "Status");
                    }
                    if (item.Text.Contains('\'')) { item.Text = item.Text.Replace("'", "''"); }
                    if (Double.IsNaN(item.Left)) { item.Left = 0; }
                    if (Double.IsNaN(item.Right)) { item.Right = 0; }
                    if (Double.IsNaN(item.Top)) { item.Top = 0; }
                    if (Double.IsNaN(item.Bottom)) { item.Bottom = 0; }
                    if (Double.IsNaN(item.BaseLine)) { item.BaseLine = 0; }
                    queryStmt = "SELECT " +
                            DocumentId + " AS [DocId]," +
                            item.PageNumber + " AS [Page]," +
                            "'" + item.Type + "' AS [Type]," +
                            item.Left + " AS [Left]," +
                            item.Right + " AS [Right]," +
                            item.Top + " AS [Top]," +
                            item.Bottom + " AS [Bottom]," +
                            item.BaseLine + " AS [BaseLine]," +
                            "LEFT('"+item.Text + "',500) AS [Text]";

                    cmd = new SqlCommand(queryStatementConstant + queryStmt, con);
                    cmd.ExecuteNonQuery();
                }
            }
            ProgressChanged?.Invoke($"Data for document {DocumentId} saved.", "Status");
            return 0;
        }
    }
}
