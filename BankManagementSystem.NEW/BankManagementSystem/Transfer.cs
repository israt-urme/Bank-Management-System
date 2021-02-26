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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        private void button1_Click(object sender, EventArgs e)
        {
            string faccNo, taccNo, date;
            double bal;
            faccNo = textfAcc.Text;
            taccNo = textTAcc.Text;
            date = textDate.Text;
            bal = double.Parse(textAmount.Text);

            con.Open();
            MySqlCommand cm = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();

            cm.Connection = con;
            cm.Transaction = transation;

            try
            {

                cm.CommandText = "update account_details set Balance = Balance - '" + bal + "' where Account_No = '" + faccNo + "'";
                cm.ExecuteNonQuery();

                cm.CommandText = "update account_details set Balance = Balance + '" + bal + "' where Account_No = '" + taccNo + "'";

                cm.CommandText = "insert into transfer(From_Account_No,To_Account_No,Date,Amount) values('" + faccNo + "','" + taccNo + "','" + date + "','" + bal + "')";
                cm.ExecuteNonQuery();

                transation.Commit();
                MessageBox.Show("Transferred Succesfully....");
            }
            catch (Exception ex)
            {
                transation.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            searchdata("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from transfer";

            MySqlCommand cm = new MySqlCommand(query, con);

            MySqlDataAdapter My = new MySqlDataAdapter();
            My.SelectCommand = cm;
            DataTable dTable = new DataTable();

            My.Fill(dTable);
            dataGridView1.DataSource = dTable;
            con.Close();
        }
        //to search data...
        public void searchdata(string valuetosearch)
        {
            if (comboBox1.Text == "Transfer_id")
            {
                string query = "select * from transfer where Transfer_id like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "From_Account_No")
            {
                string query = "select * from transfer where From_Account_No  like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "To_Account_No")
            {
                string query = "select * from transfer where To_Account_No  like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Date")
            {
                string query = "select * from transfer where Date  like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Amount")
            {
                string query = "select * from transfer where Amount like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string valuetosearch = textBox1.Text.ToString();
            searchdata(valuetosearch);
        }
        //
    }
}
