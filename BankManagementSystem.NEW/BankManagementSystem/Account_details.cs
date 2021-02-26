using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BankManagementSystem
{
    public partial class Account_details : Form
    {
        public Account_details()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");
        
        //to search data......................

        private void Account_details_Load(object sender, EventArgs e)
        {
            searchdata("");
        }

        public void searchdata(string valuetosearch)
        {
            if(comboBox1.Text== "Account_No")
            {
                string query = "select * from Account_details natural join customer where Account_No like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Customer_id")
            {
                string query = "select * from Account_details natural join customer where Customer_id  like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Account_type")
            {
                string query = "select * from Account_details natural join customer where Account_type   like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Balance")
            {
                string query = "select * from Account_details natural join customer where Balance like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "FirstName")
            {
                string query = "select * from Account_details natural join customer where FirstName like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "LastName")
            {
                string query = "select * from Account_details natural join customer where LastName like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Gender")
            {
                string query = "select * from Account_details natural join customer where Gender like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Date_of_Birth")
            {
                string query = "select * from Account_details natural join customer where Date_of_Birth like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Address")
            {
                string query = "select * from Account_details natural join customer where Address like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Nationality")
            {
                string query = "select * from Account_details natural join customer where Nationality like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Email_Address")
            {
                string query = "select * from Account_details natural join customer where Email_Address like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Occupation")
            {
                string query = "select * from Account_details natural join customer where Occupation like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Phone_No")
            {
                string query = "select * from Account_details natural join customer where Phone_No like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            string valuetosearch = textBox1.Text.ToString();
            searchdata(valuetosearch);
            
            
        }
        //

        //to view CUSTOMER Information............

        MySqlDataAdapter My1;
        DataTable dTable;
        MySqlCommandBuilder scb;

        private void button1_Click(object sender, EventArgs e)
        {
            My1 = new MySqlDataAdapter("select * from customer",con);
            
            dTable = new DataTable();

            My1.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }
        //

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //to update CUSTOMER data...........
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(My1);
                My1.Update(dTable);
                MessageBox.Show("Update successfully!");
            }
            catch(Exception x)
            {
                MessageBox.Show("error!:"+x.Message);
            }
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //delete CUSTOMER data......
        private void button4_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
            MessageBox.Show("Record deleted Succesfully....");
        }

        //to view ACCOUNT data............
        private void button5_Click(object sender, EventArgs e)
        {
            My1 = new MySqlDataAdapter("select * from Account_details", con);

            dTable = new DataTable();

            My1.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }
        //update ACCOUNT
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(My1);
                My1.Update(dTable);
                MessageBox.Show("Update successfully!");
            }
            catch (Exception x)
            {
                MessageBox.Show("error!:" + x.Message);
            }
        }
        //delete ACCOUNT
        private void button7_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
            MessageBox.Show("Record deleted Succesfully....");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            My1 = new MySqlDataAdapter("select * from Account_details NATURAL JOIN customer", con);

            dTable = new DataTable();

            My1.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }
    }
}
