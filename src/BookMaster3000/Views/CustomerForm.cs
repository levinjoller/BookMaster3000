using BookMaster3000.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BookMaster3000.Views
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            FillLvCustomer();
        }

        private void FillLvCustomer()
        {
            lvCustomer.Items.Clear();

            var IsIDEmpty = string.IsNullOrEmpty(txtCustomerID.Text);
            var IsNameEmpty = string.IsNullOrEmpty(txtName.Text);

            var customers = DB.GetCtx().Customer.OrderBy(x => x.ID)
                .Where(x => (x.ID.Equals(txtCustomerID.Text) || IsIDEmpty) &&
                (x.Name.Contains(txtName.Text) || IsNameEmpty))
                .ToList();

            foreach (var customer in customers)
            {
                var lv = new ListViewItem(customer.ID);
                lv.SubItems.Add(customer.Name);
                lv.SubItems.Add(customer.Address);
                lv.SubItems.Add(customer.Zip);
                lv.SubItems.Add(customer.City);
                lv.Tag = customer.ID;

                lvCustomer.Items.Add(lv);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillLvCustomer();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvCustomer.SelectedItems.Count < 1)
            {
                MessageBox.Show("No Customer selected!");
                return;
            }
            var id = lvCustomer.SelectedItems[0].Tag;
            var customer = DB.GetCtx().Customer.Find(id);
            AddEditCustomer aec = new AddEditCustomer(customer);
            if (aec.ShowDialog() == DialogResult.OK)
            {
                FillLvCustomer();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditCustomer aec = new AddEditCustomer();
            if (aec.ShowDialog() == DialogResult.OK)
            {
                FillLvCustomer();
            }
        }
    }
}
