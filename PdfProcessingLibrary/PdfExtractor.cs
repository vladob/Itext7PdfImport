using iText.Forms.Fields;
using iText.Forms;
using iText.Forms.Form.Element;
using iText.Kernel;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Itext7PdfImport;
using static iText.IO.Codec.TiffWriter;


namespace PdfProcessingLibrary
{
    public static class PdfExtractor
    {
        public static List<RectAndText>? ExtractedData { get; private set; }
        public static List<RectAndText>? ConcatenatedChunks { get; private set; }
        public static event Action<string, string>? ProgressChanged;
        public static int ReadPdfFile(string filePath)
        {
            ExtractTextWithCoords(filePath);
            return 0;
        }

        public static int ExtractAcroFieldsMy(string filePath)
        {
            PdfReader pdfReader = new(filePath);
            PdfDocument pdfDocument = new(pdfReader);
            //AcroFields form = pdfDoc.getAcroFields();

            return 0;
        }

        public static void ExtractAcroFields(string filePath)
        {
            PdfReader pdfReader = new PdfReader(filePath);
            PdfDocument pdfDocument = new PdfDocument(pdfReader);

            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDocument, false);
            PdfFormField field1 = form.GetField("print");
            PdfFormField field2 = form.GetField("ico");
            PdfFormField field3 = form.GetField("dic");
            PdfFormField field4 = form.GetField("sknace");

            object allFields = form.GetAllFormFields();

            if (form != null)
            {
                foreach (object fieldName in form.GetAllFormFields())
                {
                    PdfFormField field = form.GetField("print");

                    // Determine the field type and extract the value accordingly
                    if (field is PdfTextFormField textField)
                    {
                        string fieldValue = textField.GetValueAsString();
                        Console.WriteLine($"{fieldName}: {fieldValue}");
                    }
                    else if (field is PdfButtonFormField buttonField)
                    {
                        // Handle button fields (checkboxes, radio buttons)
                        /*
                        if (buttonField.GetFieldType() == PdfName.Btn)
                        {
                            bool isChecked = buttonField.GetValue();
                            Console.WriteLine($"{fieldName}: {(isChecked ? "Checked" : "Not Checked")}");
                        }
                        */
                    }
                    else if (field is PdfChoiceFormField choiceField)
                    {
                        // Handle choice fields (dropdowns, list boxes)
 //                       IList<string> selectedValues = choiceField.GetValueAsString();
 //                       Console.WriteLine($"{fieldName}: {string.Join(", ", selectedValues)}");
                    }
                    // Add more cases for other field types as needed
                }
            }
            else
            {
                Console.WriteLine("No form fields found in the document.");
            }

 
        }


        public static int ExtractTextWithCoords(string filePath, string? password = null)
        {
            try
            {
                List<RectAndText> textChunks = [];
                ProgressChanged?.Invoke("Starting to read PDF file...", "Status");
                byte[]? passwordBytes = null;
                if (!string.IsNullOrEmpty(password))
                {
                    passwordBytes = System.Text.Encoding.ASCII.GetBytes(password);
                }
                PdfReader pdfReader = new(filePath, new ReaderProperties().SetPassword(passwordBytes));
                                using (pdfReader)
                using (PdfDocument pdfDocument = new(pdfReader))
                {
                    for (int page = 1; page <= pdfDocument.GetNumberOfPages(); page++)
                    {
                        ProgressChanged?.Invoke(($"Reading page {page} of {pdfDocument.GetNumberOfPages()}"), "Progress");
                        CustomLocationTextExtractionStrategy strategy = new(page);

                        PdfCanvasProcessor parser = new(strategy);
                        parser.ProcessPageContent(pdfDocument.GetPage(page));
                        textChunks.AddRange(strategy.GetTextChunks());
                    }
                }
                ProgressChanged?.Invoke("PDF file read successfully.", "Status");
                ExtractedData = textChunks;
            }
            catch (iText.Kernel.Exceptions.BadPasswordException ex)
            {
                throw new PasswordRequiredException("The PDF file is password-protected.");
            }
            return 0;
        }

        public static int ConcatenateTextChunks()
        {
            if (ExtractedData != null)
            {
                // Sort text chunks (optional, depending on PDF structure)
                var textChunks = ExtractedData.OrderBy(tc => tc.PageNumber).ThenByDescending(tc => tc.BaseLine).ThenBy(tc => tc.Left).ToList();
                ConcatenatedChunks = [];
                RectAndText currentChunk = textChunks[0];
                int currentBaseLine = 0;
                for (int i = 1; i < textChunks.Count; i++)
                {
                    var nextChunk = textChunks[i];
                    // Check if the chunks meet the proximity criteria
                    if (Math.Abs(currentChunk.Right - nextChunk.Left) < 2 && (currentChunk.BaseLine == nextChunk.BaseLine))
                    {
                        // Concatenate text and adjust bounding box
                        currentChunk.Text += nextChunk.Text;
                        currentChunk.Right = nextChunk.Right; // Adjust the bounding box's right edge
                        currentChunk.Top = Math.Max(currentChunk.Top, nextChunk.Top); // Adjust bottom if needed
                        currentChunk.Bottom = Math.Min(currentChunk.Bottom, nextChunk.Bottom); // Adjust bottom if needed
                    }
                    else
                    {
                        if (Math.Abs(currentBaseLine - currentChunk.BaseLine) < 2)
                        {
                            currentChunk.BaseLine = currentBaseLine;
                        } else
                        {
                            currentBaseLine = currentChunk.BaseLine;
                        }
                        // Add the current chunk to the list and move to the next
                        ConcatenatedChunks.Add(currentChunk);
                        currentChunk = nextChunk;
                    }
                }
                // Add the last chunk
                ConcatenatedChunks.Add(currentChunk);
            }
            return 0;
        }
    }
}
