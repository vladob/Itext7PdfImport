namespace WindowsUI
{
    partial class frmPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblFileName = new Label();
            lblForFile = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblFileName
            // 
            lblFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFileName.Location = new Point(12, 29);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(436, 20);
            lblFileName.TabIndex = 7;
            lblFileName.Text = "2023-01-27_C53_SK6011110000001542439004_000018.pdf";
            // 
            // lblForFile
            // 
            lblForFile.AutoSize = true;
            lblForFile.Location = new Point(12, 9);
            lblForFile.Name = "lblForFile";
            lblForFile.Size = new Size(58, 20);
            lblForFile.TabIndex = 6;
            lblForFile.Text = "For file:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(119, 56);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(277, 27);
            txtPassword.TabIndex = 9;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 59);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password:";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(259, 89);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(139, 89);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 10;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // frmPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 141);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblFileName);
            Controls.Add(lblForFile);
            Name = "frmPassword";
            Text = "Enter PDF Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFileName;
        private Label lblForFile;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnCancel;
        private Button btnOk;
    }
}