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
    public partial class LoanDetails : Form
    {
        public LoanDetails()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        MySqlDataAdapter My;
        DataTable dTable;
        MySqlCommandBuilder scb;

        private void LoanDetails_Load(object sender, EventArgs e)
        {
            searchdata("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from loan_details";

            MySqlCommand cm = new MySqlCommand(query, con);

            My = new MySqlDataAdapter();
            My.SelectCommand = cm;
            dTable = new DataTable();

            My.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }
        //to search data......

        public void searchdata(string valuetosearch)
        {
            if (comboBox1.Text == "Receipt_no")
            {
                string query = "select * from loan_details where Receipt_no like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Account_No")
            {
                string query = "select * from loan_details where Account_No  like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Date")
            {
                string query = "select * from loan_details where Date  like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Amount")
            {
                string query = "select * from loan_details where Amount like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Period")
            {
                string query = "select * from loan_details where period like '" + valuetosearch + "%'";

                MySqlCommand cm = new MySqlCommand(query, con);
                MySqlDataAdapter My = new MySqlDataAdapter(cm);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Payment")
            {
                string query = "select * from loan_details where Payment like '" + valuetosearch + "%'";

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

        //details check

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "select * from loan_details where Account_No = '" + textBox2.Text + "'";
                MySqlCommand cm = new MySqlCommand(str, con);
                MySqlDataReader rd;
                rd = cm.ExecuteReader();
                if (rd.Read())
                {
                    textBox3.Text = rd[3].ToString();
                    textBox4.Text = rd[6].ToString();
                    textBox6.Text = rd[5].ToString();
                    /*if (val == "")
                    {
                        label15.Text = "10000";
                    }
                    else
                    {
                        int a;
                        a = int.Parse(dr[0].ToString());
                        a = a + 1;
                        label15.Text = a.ToString();
                    }
                    con.Close();*/
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Found!", ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string acno;
            double bal, due, pay;

            acno = textBox2.Text;
            bal = double.Parse(textBox3.Text);
            due = double.Parse(textBox4.Text);
            pay = double.Parse(textBox6.Text);
            //current = double.Parse(textBox5.Text);

            con.Open();
            MySqlCommand cm = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();

            cm.Connection = con;
            cm.Transaction = transation;



            try
            {
                if (double.Parse(textBox4.Text) > 0)
                {
                    cm.CommandText = "update loan_details set Due = Due - '" + pay + "' where Account_No = '" + acno + "'";
                    cm.ExecuteNonQuery();
                    transation.Commit();
                    MessageBox.Show("updated Succesfully....");
                }
                else
                {
                    errorProvider1.SetError(textBox4, "error");
                    MessageBox.Show("Loan Already Paid\nCongratulations!");
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox6.Clear();
                }

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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(My);
                My.Update(dTable);
                MessageBox.Show("Update successfully!");
            }
            catch (Exception x)
            {
                MessageBox.Show("error!:" + x.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
            MessageBox.Show("Record deleted");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
