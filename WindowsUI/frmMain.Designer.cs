
namespace Itext7PdfImport
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnImport = new Button();
            btnParsePdf = new Button();
            btnSelectFiles = new Button();
            dataGridFiles = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            FullPath = new DataGridViewTextBoxColumn();
            AddedAt = new DataGridViewTextBoxColumn();
            LayoutName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Errors = new DataGridViewTextBoxColumn();
            textBoxOutput = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            buttonParseForm = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridFiles).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnImport
            // 
            btnImport.Location = new Point(236, 12);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(94, 29);
            btnImport.TabIndex = 0;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // btnParsePdf
            // 
            btnParsePdf.Location = new Point(114, 12);
            btnParsePdf.Name = "btnParsePdf";
            btnParsePdf.Size = new Size(116, 29);
            btnParsePdf.TabIndex = 4;
            btnParsePdf.Text = "Parse PDF Files";
            btnParsePdf.UseVisualStyleBackColor = true;
            btnParsePdf.Click += BtnParsePdf_Click;
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Location = new Point(14, 12);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new Size(94, 29);
            btnSelectFiles.TabIndex = 3;
            btnSelectFiles.Text = "Select Files";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += BtnSelectFiles_Click;
            // 
            // dataGridFiles
            // 
            dataGridFiles.AllowUserToAddRows = false;
            dataGridFiles.AllowUserToDeleteRows = false;
            dataGridFiles.AllowUserToResizeRows = false;
            dataGridFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridFiles.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridFiles.Columns.AddRange(new DataGridViewColumn[] { FileName, FullPath, AddedAt, LayoutName, Status, Errors });
            dataGridFiles.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridFiles.Location = new Point(12, 47);
            dataGridFiles.MultiSelect = false;
            dataGridFiles.Name = "dataGridFiles";
            dataGridFiles.ReadOnly = true;
            dataGridFiles.RowHeadersVisible = false;
            dataGridFiles.RowHeadersWidth = 51;
            dataGridFiles.ShowEditingIcon = false;
            dataGridFiles.Size = new Size(936, 232);
            dataGridFiles.TabIndex = 5;
            // 
            // FileName
            // 
            FileName.DataPropertyName = "FileName";
            FileName.HeaderText = "File name";
            FileName.MinimumWidth = 6;
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            FileName.Width = 125;
            // 
            // FullPath
            // 
            FullPath.DataPropertyName = "FullPath";
            FullPath.HeaderText = "Full path";
            FullPath.MinimumWidth = 6;
            FullPath.Name = "FullPath";
            FullPath.ReadOnly = true;
            FullPath.Width = 125;
            // 
            // AddedAt
            // 
            AddedAt.DataPropertyName = "AddedAt";
            AddedAt.HeaderText = "Added at";
            AddedAt.MinimumWidth = 6;
            AddedAt.Name = "AddedAt";
            AddedAt.ReadOnly = true;
            AddedAt.Width = 125;
            // 
            // LayoutName
            // 
            LayoutName.DataPropertyName = "LayoutName";
            LayoutName.HeaderText = "Layout";
            LayoutName.MinimumWidth = 6;
            LayoutName.Name = "LayoutName";
            LayoutName.ReadOnly = true;
            LayoutName.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 125;
            // 
            // Errors
            // 
            Errors.DataPropertyName = "Errors";
            Errors.HeaderText = "Errors";
            Errors.MinimumWidth = 6;
            Errors.Name = "Errors";
            Errors.ReadOnly = true;
            Errors.Width = 125;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxOutput.Location = new Point(14, 285);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(934, 146);
            textBoxOutput.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 430);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(960, 26);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonParseForm
            // 
            buttonParseForm.Location = new Point(336, 12);
            buttonParseForm.Name = "buttonParseForm";
            buttonParseForm.Size = new Size(187, 29);
            buttonParseForm.TabIndex = 8;
            buttonParseForm.Text = "Parse PDF Form";
            buttonParseForm.UseVisualStyleBackColor = true;
            buttonParseForm.Click += buttonParseForm_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 456);
            Controls.Add(buttonParseForm);
            Controls.Add(statusStrip1);
            Controls.Add(textBoxOutput);
            Controls.Add(dataGridFiles);
            Controls.Add(btnParsePdf);
            Controls.Add(btnSelectFiles);
            Controls.Add(btnImport);
            Name = "FrmMain";
            Text = "PdfImport";
            ((System.ComponentModel.ISupportInitialize)dataGridFiles).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImport;
        private Button btnParsePdf;
        private Button btnSelectFiles;
        private DataGridView dataGridFiles;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn FullPath;
        private DataGridViewTextBoxColumn AddedAt;
        private DataGridViewTextBoxColumn LayoutName;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Errors;
        private TextBox textBoxOutput;
        private OpenFileDialog openFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button buttonParseForm;
    }
}
