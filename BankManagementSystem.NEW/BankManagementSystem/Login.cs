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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            MySqlCommand cmd = new MySqlCommand("select username,password from login where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'",con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login successfully");
                ProgressBar pr = new ProgressBar();
                this.Hide();
                pr.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password\nTry Again");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            con.Close();
            /*
            if(username== "Manager" && password== "1234")
            {
                MessageBox.Show("Login successfully");
                ProgressBar pr = new ProgressBar();
                this.Hide();
                pr.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password\nTry Again");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm to exit",
                "Bank Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
