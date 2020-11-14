using BookMaster3000.Models;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace BookMaster3000.Views
{
    public partial class AddEditCustomer : Form
    {
        private Customer c = new Customer();
        private bool isEdit = false;

        public AddEditCustomer()
        {
            InitializeComponent();
        }

        public AddEditCustomer(Customer c) : this()
        {
            this.c = c;
            isEdit = true;
            FillInputs();
        }

        private void FillInputs()
        {
            txtId.Text = c.ID;
            txtAddress.Text = c.Address;
            txtZip.Text = c.Zip;
            txtCity.Text = c.City;
            txtName.Text = c.Name;
            txtPhone.Text = c.Phone;
            txtEmail.Text = c.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckIfValid())
            {
                MessageBox.Show("Form is Invalid");
                return;
            }

            if (!isEdit)
            {
                c.ID = c.GenerateId();
            }

            c.Address = txtAddress.Text;
            c.Zip = txtZip.Text;
            c.City = txtCity.Text;
            c.Name = txtName.Text;
            c.Phone = txtPhone.Text;
            c.Email = txtEmail.Text;

            if (isEdit)
            {
                DB.GetCtx().Entry(c).State = EntityState.Modified;
            }
            else
            {
                DB.GetCtx().Customer.Add(c);
            }
            DB.GetCtx().SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private bool CheckIfValid()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCity.Text) ||
                string.IsNullOrWhiteSpace(txtZip.Text))
            {
                return false;
            }
            return true;
        }
    }
}
