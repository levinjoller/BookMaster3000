using BookMaster3000.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BookMaster3000.Views
{
    public partial class ReportForm : Form
    {
        public TabPage ActivatedTab { get; set; }
        public List<BookCustomers> Reminders { get; set; }
        public List<BookCustomers> BookHistory = new List<BookCustomers>();
        public Books Book { get; set; }
        public ImageList Icons { get; set; } = new ImageList();
        private ListViewColumnSorter lvcs = new ListViewColumnSorter();

        public ReportForm()
        {
            InitializeComponent();
            UpdateReportsLv();
            UpdateActivatedTab();
            FillImageLIst();
            RegisterListViewColumnSorter();
        }

        private void RegisterListViewColumnSorter()
        {
            lvReports.ListViewItemSorter = lvcs;
        }

        private void FillImageLIst()
        {
            var path = Directory.GetParent(Application.StartupPath).ToString();
            Icons.Images.Add(Image.FromFile(Path.Combine(path, "..\\wwwroot\\warning symbol.png")));
            lvBookHistory.SmallImageList = Icons;
        }

        private void UpdateActivatedTab()
        {
            ActivatedTab = tcReports.SelectedTab;
        }

        private void UpdateReportsLv()
        {
            lvReports.Items.Clear();

            Reminders = DB.GetCtx().BookCustomers
                .Include("Customer")
                .Include("Books")
                .Where(x => (x.UntilDate <= DateTime.Now) && !x.IsReturned)
                .OrderBy(x => x.UntilDate)
                .ToList();

            foreach (var issue in Reminders)
            {
                var lvi = new ListViewItem(issue.Books.Title);
                lvi.SubItems.Add(issue.Customer.Name);
                lvi.SubItems.Add(issue.IssueDate.ToString("dd.MM.yy"));
                lvi.SubItems.Add(issue.UntilDate.ToString("dd.MM.yy"));

                lvReports.Items.Add(lvi);
            }
        }

        private void tcReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcReports.IsHandleCreated)
            {
                UpdateActivatedTab();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (ActivatedTab.Name == "tpReports")
            {
                ExportReminders();
            }
            else
            {
                ExportBookHistory();
            }

        }

        private void ExportList(List<BookCustomers> list)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "csv";
            sfd.Filter = "Csv (*.csv)|*.csv";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    sw.WriteLine("sep=,");
                    if (ActivatedTab.Name == "tpReports")
                    {
                        sw.WriteLine("Title,Customer,Date of issue,Return until");
                        foreach (var remide in list)
                        {
                            sw.WriteLine(remide.GetExportView());
                        }
                    }
                    else
                    {
                        sw.WriteLine("Customer,Date of issue,Return until");
                        foreach (var issue in list)
                        {
                            sw.WriteLine(issue.GetExportView(false));
                        }
                    }
                    sw.Close();
                    MessageBox.Show("Updated/Created successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ExportBookHistory()
        {
            if (BookHistory.Count < 1)
            {
                return;
            }

            ExportList(BookHistory);
        }

        private void ExportReminders()
        {
            ExportList(Reminders);
        }

        private void txtBookID_TextChanged(object sender, EventArgs e)
        {
            if (txtBookID.IsHandleCreated && !string.IsNullOrWhiteSpace(txtBookID.Text))
            {
                BookHistory = DB.GetCtx().BookCustomers.OrderBy(x => x.IssueDate).Where(y => y.BookKey == txtBookID.Text && y.IsReturned).ToList();

                UpdateHitoryLv();

                if (BookHistory.Count > 0)
                {
                    Book = BookHistory[0].Books;
                    UpdateViewLabels();
                }
            }
        }

        private void UpdateViewLabels()
        {
            lblTitle.Text = Book.Title;
            lblSubtitle.Text = Book.Subtitle;
        }

        private void UpdateHitoryLv()
        {
            lvBookHistory.Items.Clear();

            foreach (var issue in BookHistory)
            {
                var lvi = new ListViewItem(issue.Customer.Name)
                {
                    ImageIndex = issue.UntilDate <= issue.ReturnDate ? 0 : -1
                };
                lvi.SubItems.Add(issue.IssueDate.ToString("dd.MM.yy"));
                lvi.SubItems.Add(issue.ReturnDate?.ToString("dd.MM.yy"));

                lvBookHistory.Items.Add(lvi);
            }
        }

        private void lvReports_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvcs.ColumnToSort)
            {
                lvcs.orderOfSort = lvcs.orderOfSort == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                lvcs.ColumnToSort = e.Column;
                lvcs.orderOfSort = SortOrder.Ascending;
            }
            lvReports.Sort();
        }
    }

    internal class ListViewColumnSorter : IComparer
    {
        public int ColumnToSort;
        public SortOrder orderOfSort;
        public CaseInsensitiveComparer objectComparer;

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            orderOfSort = SortOrder.None;
            objectComparer = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem lviX, lviY;

            lviX = (ListViewItem)x;
            lviY = (ListViewItem)y;

            compareResult = objectComparer.Compare(lviX.SubItems[ColumnToSort].Text, lviY.SubItems[ColumnToSort].Text);

            if (orderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (orderOfSort == SortOrder.Descending)
            {
                return -compareResult;
            }
            else
            {
                return 0;
            }

        }
    }
}
