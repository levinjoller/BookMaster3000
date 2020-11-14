namespace BookMaster3000.Views
{
    partial class AuthorForm
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
            this.cmbAutor = new System.Windows.Forms.ComboBox();
            this.lblBirth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbBio = new System.Windows.Forms.RichTextBox();
            this.llWikipedia = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbAutor
            // 
            this.cmbAutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutor.FormattingEnabled = true;
            this.cmbAutor.Location = new System.Drawing.Point(41, 24);
            this.cmbAutor.Name = "cmbAutor";
            this.cmbAutor.Size = new System.Drawing.Size(293, 21);
            this.cmbAutor.TabIndex = 0;
            this.cmbAutor.SelectionChangeCommitted += new System.EventHandler(this.cmbAutor_SelectionChangeCommitted);
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(41, 52);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(35, 13);
            this.lblBirth.TabIndex = 1;
            this.lblBirth.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bio";
            // 
            // rtbBio
            // 
            this.rtbBio.Location = new System.Drawing.Point(41, 110);
            this.rtbBio.Name = "rtbBio";
            this.rtbBio.Size = new System.Drawing.Size(293, 223);
            this.rtbBio.TabIndex = 2;
            this.rtbBio.Text = "";
            // 
            // llWikipedia
            // 
            this.llWikipedia.AutoSize = true;
            this.llWikipedia.Location = new System.Drawing.Point(41, 356);
            this.llWikipedia.Name = "llWikipedia";
            this.llWikipedia.Size = new System.Drawing.Size(55, 13);
            this.llWikipedia.TabIndex = 3;
            this.llWikipedia.TabStop = true;
            this.llWikipedia.Text = "linkLabel1";
            this.llWikipedia.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llWikipedia_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(41, 389);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // AuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(387, 433);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.llWikipedia);
            this.Controls.Add(this.rtbBio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.cmbAutor);
            this.Name = "AuthorForm";
            this.Text = "Author";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAutor;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbBio;
        private System.Windows.Forms.LinkLabel llWikipedia;
        private System.Windows.Forms.Button btnClose;
    }
}