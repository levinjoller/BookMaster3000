using BookMaster3000.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BookMaster3000.Views
{
    public partial class CirculationForm : Form
    {
        public Customer customer { get; set; }
        public Books CurrentBook { get; set; }
        public BookCustomers CurrentIssue { get; set; }
        public ImageList icons { get; set; } = new ImageList();
        public CirculationForm()
        {
            InitializeComponent();
        }

        private void btnCirculation_Click(object sender, EventArgs e)
        {
            var customer = DB.GetCtx().Customer.Find(txtCustomerId.Text);

            if (string.IsNullOrWhiteSpace(txtCustomerId.Text) || customer == null)
            {
                MessageBox.Show("Customer ID is not valid!");
                return;
            }
            this.customer = customer;
            FillInCustomerInfo();
            EnableDisableEditBtn();
            FillImageList();
            UpdateLvIssues();
            UpdateLvHistory();
        }

        private void FillImageList()
        {
            var path = Directory.GetParent(Application.StartupPath).ToString();
            icons.Images.Add(Image.FromFile(Path.Combine(path, "..\\wwwroot\\warning symbol.png")));
            lvHistory.SmallImageList = icons;
            lvIssues.SmallImageList = icons;
        }

        private void EnableDisableEditBtn()
        {
            btnEdit.Enabled = customer != null;
        }

        private void FillInCustomerInfo()
        {
            lblCustomerID.Text = customer.ID;
            lblCustomerAddress.Text = customer.Address;
            lblCustomerZip.Text = customer.Zip;
            lblCustomerCity.Text = customer.City;
            lblCustomerName.Text = customer.Name;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditCustomer aed = new AddEditCustomer(customer);
            aed.ShowDialog();
        }

        private void txtBookId_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookId.Text) && !txtBookId.IsHandleCreated)
            {
                return;
            }

            var book = DB.GetCtx().Books.FirstOrDefault(x => x.Key == txtBookId.Text);

            if (book != null)
            {
                CurrentBook = book;
                UpdateViewLabels();
                DisableEnableButtonsReturnIssue();
            }
        }

        private void DisableEnableButtonsReturnIssue()
        {
            var IsLoanInGeneral = DB.GetCtx().BookCustomers.Where(x => x.BookKey == CurrentBook.Key)
                .Where(y => !y.IsReturned).Count() > 0;

            var IsLoanByCustomer = DB.GetCtx().BookCustomers.Where(x => x.BookKey == CurrentBook.Key && x.CustomerID == customer.ID)
                .Where(y => !y.IsReturned).Count() > 0;

            btnIssue.Enabled = !IsLoanInGeneral;
            btnReturn.Enabled = IsLoanInGeneral && IsLoanByCustomer;

            if (btnReturn.Enabled)
            {
                SetCurrentIssue();
            }
        }

        private void SetCurrentIssue()
        {
            CurrentIssue = DB.GetCtx().BookCustomers.Where(x => x.BookKey == CurrentBook.Key && x.CustomerID == customer.ID)
                .FirstOrDefault(y => !y.IsReturned);
        }

        private void UpdateViewLabels()
        {
            lblTitleBook.Text = CurrentBook.Title;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            var issuesAmount = DB.GetCtx().BookCustomers.Where(x => x.CustomerID == customer.ID && x.BookKey == CurrentBook.Key)
                .Where(y => !y.IsReturned).Count();

            if (issuesAmount >= 5)
            {
                MessageBox.Show("No more issues allowed!");
                return;
            }

            var issue = new BookCustomers()
            {
                CustomerID = customer.ID,
                BookKey = CurrentBook.Key,
                IssueDate = DateTime.Now.Date,
                UntilDate = DateTime.Now.AddDays(21)
            };
            DB.GetCtx().BookCustomers.Add(issue);
            DB.GetCtx().SaveChanges();

            UpdateLvIssues();
        }

        private void UpdateLvIssues()
        {
            lvIssues.Items.Clear();

            var Issues = DB.GetCtx().BookCustomers
                .OrderBy(y => y.UntilDate)
                .Where(x => x.CustomerID == customer.ID && !x.IsReturned)
                .ToList();

            foreach (var issue in Issues)
            {
                var lvi = new ListViewItem(issue.Books.Title)
                {
                    ImageIndex = (issue.UntilDate <= DateTime.Now) ? 0 : -1
                };

                lvi.SubItems.Add(issue.IssueDate.ToString("dd.MM.yy"));
                lvi.SubItems.Add(issue.UntilDate.ToString("dd.MM.yy"));

                lvi.Tag = issue.ID;

                lvIssues.Items.Add(lvi);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (CurrentIssue.UntilDate.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Book is returned too late!");
            }

            CurrentIssue.IsReturned = true;
            CurrentIssue.ReturnDate = DateTime.Now.Date;

            DB.GetCtx().Entry(CurrentIssue).State = EntityState.Modified;
            DB.GetCtx().SaveChanges();

            UpdateLvHistory();
            UpdateLvIssues();
        }

        private void UpdateLvHistory()
        {
            lvHistory.Items.Clear();

            var history = DB.GetCtx().BookCustomers
                .OrderBy(x => x.ReturnDate)
                .Where(x => x.CustomerID == customer.ID && x.IsReturned)
                .ToList();

            foreach (var issue in history)
            {
                var lvi = new ListViewItem(issue.Books.Title)
                {
                    ImageIndex = (issue.ReturnDate >= issue.UntilDate) ? 0 : -1
                };
                lvi.SubItems.Add(issue.IssueDate.ToString("dd.MM.yy"));
                lvi.SubItems.Add(issue.ReturnDate?.ToString("dd.MM.yy"));

                lvi.Tag = issue.ID;

                lvHistory.Items.Add(lvi);
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (lvIssues.SelectedItems.Count < 1)
            {
                MessageBox.Show("No issue selected!");
                return;
            }

            var id = lvIssues.SelectedItems[0].Tag;
            var issue = DB.GetCtx().BookCustomers.Find(id);

            if (issue == null)
            {
                return;
            }

            var dateSpan = issue.UntilDate.Subtract(issue.IssueDate);
            if (dateSpan.TotalDays > 21)
            {
                MessageBox.Show("Cannot extend the return deadline more than once!");
                return;
            }

            issue.UntilDate = issue.UntilDate.AddDays(7);
            DB.GetCtx().Entry(issue).State = EntityState.Modified;
            DB.GetCtx().SaveChanges();

            UpdateLvIssues();
        }

        private void lvIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvIssues.IsHandleCreated && lvIssues.SelectedItems.Count > 0)
            {
                btnRenew.Enabled = true;
            }
            else
            {
                btnRenew.Enabled = false;
            }
        }
    }
}
