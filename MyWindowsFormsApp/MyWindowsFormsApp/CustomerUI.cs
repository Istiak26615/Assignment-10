using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWindowsFormsApp.BLL;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp
{
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUI()
        {
            InitializeComponent();
        }

        public void addButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            //Check UNIQUE
            if (_customerManager.IsNameExists(customer))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exists!");
                return;
            }

            //Set Price as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
           
            //Add/Insert Item
            bool isAdded = _customerManager.Add(customer);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            //showDataGridView.DataSource = dataTable;
            showDataGridView.DataSource = _customerManager.Display();
        }

        public void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();
        }

        public void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_customerManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _customerManager.Display();
        }

        private void updatebButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }

            if (_customerManager.Update(nameTextBox.Text, addressTextBox.Text, Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        public void searchButton_Click(object sender, EventArgs e)
        {
           
            
                showDataGridView.DataSource = _customerManager.Search(nameTextBox.Text);
            

        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ;
            {
                DataGridViewRow row = this.showDataGridView.Rows[e.RowIndex];
                idTextBox.Text = row.Cells["ID"].Value.ToString();
                nameTextBox.Text = row.Cells["Name"].Value.ToString();
                addressTextBox.Text = row.Cells["Address"].Value.ToString();



            }
        }

        private void CustomerUI_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _customerManager.CustomerCombo();
        }
    }
}
