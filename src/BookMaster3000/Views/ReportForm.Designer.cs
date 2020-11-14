namespace BookMaster3000.Views
{
    partial class ReportForm
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
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tcReports = new System.Windows.Forms.TabControl();
            this.tpReports = new System.Windows.Forms.TabPage();
            this.lvReports = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateIssue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateUntil = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpBookHistory = new System.Windows.Forms.TabPage();
            this.lvBookHistory = new System.Windows.Forms.ListView();
            this.colCustomerHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateIssueHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateReturn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tcReports.SuspendLayout();
            this.tpReports.SuspendLayout();
            this.tpBookHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(164)))), ((int)(((byte)(59)))));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(1014, 21);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report";
            // 
            // tcReports
            // 
            this.tcReports.Controls.Add(this.tpReports);
            this.tcReports.Controls.Add(this.tpBookHistory);
            this.tcReports.Location = new System.Drawing.Point(-1, 64);
            this.tcReports.Name = "tcReports";
            this.tcReports.SelectedIndex = 0;
            this.tcReports.Size = new System.Drawing.Size(1128, 549);
            this.tcReports.TabIndex = 2;
            this.tcReports.SelectedIndexChanged += new System.EventHandler(this.tcReports_SelectedIndexChanged);
            // 
            // tpReports
            // 
            this.tpReports.Controls.Add(this.lvReports);
            this.tpReports.Location = new System.Drawing.Point(4, 22);
            this.tpReports.Name = "tpReports";
            this.tpReports.Padding = new System.Windows.Forms.Padding(3);
            this.tpReports.Size = new System.Drawing.Size(1120, 523);
            this.tpReports.TabIndex = 0;
            this.tpReports.Text = "Reminders";
            this.tpReports.UseVisualStyleBackColor = true;
            // 
            // lvReports
            // 
            this.lvReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colCustomer,
            this.colDateIssue,
            this.colDateUntil});
            this.lvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvReports.FullRowSelect = true;
            this.lvReports.HideSelection = false;
            this.lvReports.Location = new System.Drawing.Point(3, 3);
            this.lvReports.MultiSelect = false;
            this.lvReports.Name = "lvReports";
            this.lvReports.Size = new System.Drawing.Size(1114, 517);
            this.lvReports.TabIndex = 0;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            this.lvReports.View = System.Windows.Forms.View.Details;
            this.lvReports.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvReports_ColumnClick);
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 503;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer";
            this.colCustomer.Width = 253;
            // 
            // colDateIssue
            // 
            this.colDateIssue.Text = "Date of issue";
            this.colDateIssue.Width = 171;
            // 
            // colDateUntil
            // 
            this.colDateUntil.Text = "Return until";
            this.colDateUntil.Width = 161;
            // 
            // tpBookHistory
            // 
            this.tpBookHistory.Controls.Add(this.lvBookHistory);
            this.tpBookHistory.Controls.Add(this.txtBookID);
            this.tpBookHistory.Controls.Add(this.lblSubtitle);
            this.tpBookHistory.Controls.Add(this.lblTitle);
            this.tpBookHistory.Controls.Add(this.label2);
            this.tpBookHistory.Location = new System.Drawing.Point(4, 22);
            this.tpBookHistory.Name = "tpBookHistory";
            this.tpBookHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpBookHistory.Size = new System.Drawing.Size(1120, 523);
            this.tpBookHistory.TabIndex = 1;
            this.tpBookHistory.Text = "Book history";
            this.tpBookHistory.UseVisualStyleBackColor = true;
            // 
            // lvBookHistory
            // 
            this.lvBookHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerHistory,
            this.colDateIssueHistory,
            this.colDateReturn});
            this.lvBookHistory.HideSelection = false;
            this.lvBookHistory.Location = new System.Drawing.Point(269, 3);
            this.lvBookHistory.Name = "lvBookHistory";
            this.lvBookHistory.Size = new System.Drawing.Size(851, 514);
            this.lvBookHistory.TabIndex = 2;
            this.lvBookHistory.UseCompatibleStateImageBehavior = false;
            this.lvBookHistory.View = System.Windows.Forms.View.Details;
            // 
            // colCustomerHistory
            // 
            this.colCustomerHistory.Text = "Customer";
            this.colCustomerHistory.Width = 488;
            // 
            // colDateIssueHistory
            // 
            this.colDateIssueHistory.Text = "Date of issue";
            this.colDateIssueHistory.Width = 151;
            // 
            // colDateReturn
            // 
            this.colDateReturn.Text = "Return Date";
            this.colDateReturn.Width = 179;
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(12, 39);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(196, 20);
            this.txtBookID.TabIndex = 1;
            this.txtBookID.TextChanged += new System.EventHandler(this.txtBookID_TextChanged);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(9, 113);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(0, 13);
            this.lblSubtitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(9, 91);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Book ID";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 609);
            this.Controls.Add(this.tcReports);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Name = "ReportForm";
            this.Text = "f";
            this.tcReports.ResumeLayout(false);
            this.tpReports.ResumeLayout(false);
            this.tpBookHistory.ResumeLayout(false);
            this.tpBookHistory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcReports;
        private System.Windows.Forms.TabPage tpReports;
        private System.Windows.Forms.TabPage tpBookHistory;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colDateIssue;
        private System.Windows.Forms.ColumnHeader colDateUntil;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvBookHistory;
        private System.Windows.Forms.ColumnHeader colCustomerHistory;
        private System.Windows.Forms.ColumnHeader colDateIssueHistory;
        private System.Windows.Forms.ColumnHeader colDateReturn;
    }
}