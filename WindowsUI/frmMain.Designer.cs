
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
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dataGridFiles).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnImport
            // 
            btnImport.Enabled = false;
            btnImport.Location = new Point(206, 9);
            btnImport.Margin = new Padding(3, 2, 3, 2);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(82, 22);
            btnImport.TabIndex = 0;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            // 
            // btnParsePdf
            // 
            btnParsePdf.Location = new Point(100, 9);
            btnParsePdf.Margin = new Padding(3, 2, 3, 2);
            btnParsePdf.Name = "btnParsePdf";
            btnParsePdf.Size = new Size(102, 22);
            btnParsePdf.TabIndex = 4;
            btnParsePdf.Text = "Parse PDF Files";
            btnParsePdf.UseVisualStyleBackColor = true;
            btnParsePdf.Click += BtnParsePdf_Click;
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Location = new Point(12, 9);
            btnSelectFiles.Margin = new Padding(3, 2, 3, 2);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new Size(82, 22);
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
            dataGridFiles.Dock = DockStyle.Fill;
            dataGridFiles.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridFiles.Location = new Point(0, 0);
            dataGridFiles.Margin = new Padding(3, 2, 3, 2);
            dataGridFiles.MultiSelect = false;
            dataGridFiles.Name = "dataGridFiles";
            dataGridFiles.ReadOnly = true;
            dataGridFiles.RowHeadersVisible = false;
            dataGridFiles.RowHeadersWidth = 51;
            dataGridFiles.ShowEditingIcon = false;
            dataGridFiles.Size = new Size(816, 140);
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
            textBoxOutput.Dock = DockStyle.Fill;
            textBoxOutput.Location = new Point(0, 0);
            textBoxOutput.Margin = new Padding(3, 2, 3, 2);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(816, 137);
            textBoxOutput.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            statusStrip1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 320);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(164, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonParseForm
            // 
            buttonParseForm.Enabled = false;
            buttonParseForm.Location = new Point(294, 9);
            buttonParseForm.Margin = new Padding(3, 2, 3, 2);
            buttonParseForm.Name = "buttonParseForm";
            buttonParseForm.Size = new Size(164, 22);
            buttonParseForm.TabIndex = 8;
            buttonParseForm.Text = "Parse PDF Form";
            buttonParseForm.UseVisualStyleBackColor = true;
            buttonParseForm.Click += buttonParseForm_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 36);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridFiles);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBoxOutput);
            splitContainer1.Size = new Size(816, 281);
            splitContainer1.SplitterDistance = 140;
            splitContainer1.TabIndex = 9;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 342);
            Controls.Add(splitContainer1);
            Controls.Add(buttonParseForm);
            Controls.Add(statusStrip1);
            Controls.Add(btnParsePdf);
            Controls.Add(btnSelectFiles);
            Controls.Add(btnImport);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMain";
            Text = "PdfImport";
            ((System.ComponentModel.ISupportInitialize)dataGridFiles).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
        private SplitContainer splitContainer1;
    }
}
