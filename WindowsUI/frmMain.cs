using iText.Kernel.Exceptions;
using PdfProcessingLibrary;
using SqlDataAccess;
using System.Diagnostics;
using WindowsUI;

namespace Itext7PdfImport
{
    public partial class FrmMain : Form
    {
        private readonly List<FileToParse> selectedFiles = []; // Add this field to store the selected file paths.
        string? lastEnteredPassword = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnSelectFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|STA files (*.STA)|*.STA|All files (*.*)|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (dr == DialogResult.OK)
            {
                selectedFiles.Clear();
                textBoxOutput.Text = "";
                foreach (string fileName in openFileDialog1.FileNames) // Use FileNames property for multiple selections
                {
                    FileToParse fileToParse = new(fileName)
                    {
                        LayoutName = "Unkonown",
                        Status = "Selected"
                    };
                    fileToParse.Status = "No errors";
                    fileToParse.AddedAt = DateTime.Now;
                    selectedFiles.Add(fileToParse); // Store the selected file paths in the list
                }
                dataGridFiles.DataSource = null;
                dataGridFiles.DataSource = selectedFiles;
            }
        }

        private async void BtnParsePdf_Click(object sender, EventArgs e)
        {
            int result;
            textBoxOutput.Text = "";
            toolStripStatusLabel1.Text = "";
            PdfExtractor.ProgressChanged += OnProgressChanged;

            foreach (FileToParse fileToParse in selectedFiles)
            {
                textBoxOutput.Text += DateTime.Now.ToString() + " reading PDF file: " + fileToParse.FileName + "...\r\n";

                await OpenPdf(fileToParse.FullPath, lastEnteredPassword);
                //result = await Task.Run(() => PdfExtractor.ExtractTextWithCoords(fileToParse.FullPath));
                result = 0;

                if (result == 0)
                {
                    //PdfExtractor.ConcatenateTextChunks();
                    textBoxOutput.Text += DateTime.Now.ToString() + " writing data...\r\n";
                    WriteDocument(fileToParse.FullPath);
                    Debug.WriteLine("Done!");
                    textBoxOutput.Text += DateTime.Now.ToString() + " data saved!\r\n";
                }
                else
                {
                    Debug.WriteLine("Some error!");
                }
            }
            PdfExtractor.ProgressChanged -= OnProgressChanged;
        }


        private async Task OpenPdf(string filePath, string? password = null)
        {
            try
            {
                int result = await Task.Run(() => PdfExtractor.ExtractTextWithCoords(filePath, password)); // Assuming ExtractTextWithCoords is updated to support async
                if (result == 0)
                {
                    PdfExtractor.ConcatenateTextChunks();
                    textBoxOutput.Text += DateTime.Now.ToString() + " data retreived!\r\n";
                }
            }
            catch (PasswordRequiredException)
            {
                lastEnteredPassword = null;
                frmPassword passwordForm = new();
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    lastEnteredPassword = passwordForm.Password;
                    await OpenPdf(filePath, lastEnteredPassword);
                }
                else
                {
                    MessageBox.Show("Password is required to open this PDF.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnProgressChanged(string progressMessage, string target)
        {
            if (InvokeRequired)
            {
                // Invoke on the main thread to update both controls safely
                Invoke((MethodInvoker)delegate { UpdateControls(progressMessage, target); });
            }
            else
            {
                // Directly update if already on the main UI thread
                UpdateControls(progressMessage, target);
            }
        }

        private void UpdateControls(string progressMessage, string target)
        {
            if (target == "Status")
            {
                textBoxOutput.Text += $"{DateTime.Now} {progressMessage}\r\n";
                // Set the caret position to the end of the text and scroll to that position
                textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
                textBoxOutput.ScrollToCaret();
            }
            else if (target == "Progress")
            {
                toolStripStatusLabel1.Text = progressMessage;
            }
        }

        private void WriteDocument(string filepath)
        {
            BankStatements.ConnectToDb();
            BankStatements.ProgressChanged += OnProgressChanged;
            if (PdfExtractor.ConcatenatedChunks != null)
            {
                FileToParse newFile = new(filepath);
                BankStatements.NewStatement(newFile);
                Debug.WriteLine(BankStatements.GetDocumentId());
                BankStatements.PopulatePdfRawData(PdfExtractor.ConcatenatedChunks);
                // int result = await Task.Run(() => BankStatements.PopulatePdfRawData(PdfExtractor.ExtractedData));
            }
            BankStatements.DisconectFromDb();
            BankStatements.ProgressChanged -= OnProgressChanged;
        }

        private static void DebugDumpFileContent()
        {
            if (PdfExtractor.ExtractedData != null)
            {
                foreach (var item in PdfExtractor.ExtractedData)
                {
                    Debug.WriteLine($"Text: {item.Text}, Coordinates: Top: {item.Top}, Left: {item.Left}, Right: {item.Right}, Bottom: {item.Bottom}, Page: {item.PageNumber}");
                }
            }
        }

        private void buttonParseForm_Click(object sender, EventArgs e)
        {
            foreach (FileToParse fileToParse in selectedFiles)
            {
                PdfExtractor.ExtractAcroFields(fileToParse.FullPath);
            }
        }
    }
}
