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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            MySqlCommand cmd = new MySqlCommand("select username,password from login where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows.Count > 0)
            {
                if(textBox3.Text== textBox4.Text)
                {
                    if(textBox3.Text.Length>3)
                    {
                        MySqlCommand cmd1 = new MySqlCommand("update login set password='" + textBox3.Text + "' where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
                        MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MessageBox.Show("password changed successfully");
                    }
                    else
                    {
                        errorProvider1.SetError(textBox3, "set minimum 4 characters");
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox3, "password unmatched");
                    errorProvider1.SetError(textBox4, "password unmatched");
                }
            }
            else
            {
                errorProvider1.SetError(textBox1, "incorrect username");
                errorProvider1.SetError(textBox2, "incorrect password");
            }
            con.Close();
        }
    }
}
