using BookMaster3000.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BookMaster3000.Views
{
    public partial class CatalogFrom : Form
    {
        private int PageSize = 50;
        private int PageIndex = 0;
        private int TotalBooks = 0;
        private int CurrentPage = 0;
        private int TotalPages = 0;

        private List<Image> Pictures = new List<Image>();
        public int CoverIndex = 0;

        public bool IsInChangesDetectionMode = true;

        private Books SelectedBook = null;

        public CatalogFrom()
        {
            InitializeComponent();
            RemoveArrows();
            FillLvBooks();
            UpdateCurrentPageNum();
            UpdateNavButtonsView();
            SetMaxNudNumber();
            UpdateViewManually();
        }

        //After lvBooks is displayed
        public void CatalogFrom_Shown()
        {
            GetCoversOfBook();
            UpdatePictureBox();
        }

        private void UpdateViewManually()
        {
            IsInChangesDetectionMode = false;

            lblTotalSites.Text = TotalPages.ToString();
            lblTotalBooks.Text = TotalBooks.ToString() + " Books found";
            nudPageIndex.Value = CurrentPage;

            IsInChangesDetectionMode = true;
        }

        private void GetCoversOfBook()
        {
            var covers = SelectedBook.BookCovers.Select(x => x.CoverFile).ToList();

            // Remove old pictures
            Pictures = new List<Image>();

            foreach (var cover in covers)
            {
                var coverSaved = Directory.GetParent(Application.StartupPath).ToString();
                var coverFullPath = Path.Combine(coverSaved, "..\\wwwroot\\BookCovers\\" + cover + ".jpg");
                if (File.Exists(coverFullPath))
                {
                    var coverImage = Image.FromFile(coverFullPath);
                    Pictures.Add(coverImage);
                }
            }
        }

        private void UpdateNavButtonsView()
        {
            btnPageBack.Enabled = CurrentPage == 1 ? false : true;
            btnPageNext.Enabled = CurrentPage == TotalPages ? false : true;
        }

        private void UpdatePictureBox()
        {
            btnPictureBack.Enabled = CoverIndex <= 0 ? false : true;
            btnPictureNext.Enabled = CoverIndex >= Pictures.Count - 1 ? false : true;

            if (Pictures.Count != 0)
            {
                pbBook.Image = Pictures[CoverIndex];
            }
            else
            {
                pbBook.Image = null;
            }
        }

        private void SelectItemInLvBooks()
        {
            if (lvBooks.Items.Count > 0)
            {
                lvBooks.Items[0].Selected = true;
                SelectedBook = DB.GetCtx().Books.Find(lvBooks.Items[0].Tag);
            }
        }

        private void SetMaxNudNumber()
        {
            nudPageIndex.Maximum = TotalPages;
            nudPageIndex.Minimum = 0;
        }

        private void RemoveArrows()
        {
            nudPageIndex.Controls.RemoveAt(0);
        }

        private void FillLvBooks()
        {
            lvBooks.Items.Clear();

            var Title = txtTitle.Text;
            var AuthorName = txtAuthor.Text;
            var Subject = txtSubject.Text;

            var IsTiteEmpty = string.IsNullOrEmpty(Title);
            var IsAuthorNameEmpty = string.IsNullOrEmpty(AuthorName);
            var IsSubjectEmpty = string.IsNullOrEmpty(Subject);

            var booksQuery = DB.GetCtx().Books.AsNoTracking().Include("Authors").OrderBy(x => x.Title)
                .Where(x => (x.Title.Contains(Title) || IsTiteEmpty) &&
                (x.Authors.Any(y => y.Name.Contains(AuthorName)) || IsAuthorNameEmpty) &&
                (x.BookSubjects.Any(y => y.Subject.Contains(Subject)) || IsSubjectEmpty));

            //Update Values
            TotalBooks = booksQuery.Count();
            TotalPages = (TotalBooks % PageSize) > 0 ? (TotalBooks / PageSize) + 1 : (TotalBooks / PageSize);

            var books = booksQuery.Skip(PageIndex).Take(PageSize).ToList();

            foreach (var b in books.ToList())
            {
                var lvi = new ListViewItem(b.Title);
                var authors = b.Authors.Select(x => x.Name).ToArray();
                var aggAuthors = authors.Aggregate("", (a, t) => (a == "" ? "" : a + ", ") + t);
                lvi.SubItems.Add(aggAuthors);
                lvi.Tag = b.Key;

                lvBooks.Items.Add(lvi);
            }
            //Select one Item to display different Details
            SelectItemInLvBooks();
        }

        private void UpdateCurrentPageNum(bool IsPositiv = true)
        {
            if (IsPositiv)
            {
                CurrentPage++;
            }
            else
            {
                CurrentPage--;
            }
        }

        private void btnPageNext_Click(object sender, EventArgs e)
        {
            PageIndex += PageSize;
            FillLvBooks();
            UpdateCurrentPageNum();
            UpdateNavButtonsView();
            UpdateViewManually();
        }

        private void btnPageBack_Click(object sender, EventArgs e)
        {
            PageIndex -= PageSize;
            FillLvBooks();
            UpdateCurrentPageNum(false);
            UpdateNavButtonsView();
            UpdateViewManually();
        }

        private void nudPageIndex_ValueChanged(object sender, EventArgs e)
        {
            if (nudPageIndex.IsHandleCreated && IsInChangesDetectionMode)
            {
                if (nudPageIndex.Value <= TotalPages && nudPageIndex.Value >= 1)
                {
                    CurrentPage = (int)nudPageIndex.Value;
                    PageIndex = CurrentPage * PageSize;
                    FillLvBooks();
                }
            }
        }

        private void lvBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBooks.SelectedItems.Count > 0 && lvBooks.IsHandleCreated)
            {
                var ListViewBookid = lvBooks.SelectedItems[0].Tag;
                SelectedBook = DB.GetCtx().Books.Include("BookSubjects").FirstOrDefault(x => x.Key == ListViewBookid.ToString());

                lblTitle.Text = SelectedBook.Title;
                lblSutitel.Text = SelectedBook.Subtitle;
                llAuthors.Text = SelectedBook.Authors.Select(x => x.Name).Aggregate("", (a, t) => (a == "" ? "" : a + ", ") + t);
                lblFistPublished.Text = SelectedBook.FirstPublishDate;
                rtbDescription.Text = SelectedBook.Description;
                lblSubject.Text = SelectedBook.BookSubjects.Select(x => x.Subject).Aggregate("", (a, t) => (a == "" ? "" : a + ", ") + t);
                GetCoversOfBook();
                UpdatePictureBox();
            }
        }

        private void btnPictureNext_Click(object sender, EventArgs e)
        {
            CoverIndex++;
            UpdatePictureBox();
        }

        private void btnPictureBack_Click(object sender, EventArgs e)
        {
            CoverIndex--;
            UpdatePictureBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            PageIndex = 0;
            FillLvBooks();
            UpdateNavButtonsView();
            UpdateViewManually();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void llAuthors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthorForm af = new AuthorForm(SelectedBook.Authors.ToList());
            af.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
        }

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm cf = new CustomerForm();
            cf.ShowDialog();
        }

        private void circulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DB.ApplicationUser != null)
            {
                CirculationForm cf = new CirculationForm();
                cf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Not Logged in!");
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DB.ApplicationUser != null)
            {
                ReportForm cf = new ReportForm();
                cf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Not Logged in!");
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB.ApplicationUser = null;
        }
    }
}
