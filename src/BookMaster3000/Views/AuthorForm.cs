using BookMaster3000.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace BookMaster3000.Views
{
    public partial class AuthorForm : Form
    {
        public List<Authors> Authors { get; private set; }
        public Authors SelectedAutor { get; set; }

        public AuthorForm(List<Authors> a)
        {
            Authors = a;
            SelectedAutor = Authors[0];
            InitializeComponent();
            FillCmb();
            UpdatedViewLabels();
        }

        private void UpdatedViewLabels()
        {
            lblBirth.Text = SelectedAutor.BirthDate;
            rtbBio.Text = SelectedAutor.Bio;
            llWikipedia.Text = SelectedAutor.Wikipedia;
        }

        private void FillCmb()
        {
            cmbAutor.DataSource = Authors;
            cmbAutor.DisplayMember = "Name";
        }

        private void cmbAutor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectAuthor = (Authors)cmbAutor.SelectedItem;
            SelectedAutor = selectAuthor;
            UpdatedViewLabels();
        }

        private void llWikipedia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(llWikipedia.Text);
        }
    }
}
