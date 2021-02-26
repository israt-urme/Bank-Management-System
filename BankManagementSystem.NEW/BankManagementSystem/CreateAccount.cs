using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//to connect database
using MySql.Data.MySqlClient;
//to add picture
using System.IO;
//to print
using System.Drawing.Printing;

namespace BankManagementSystem
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        string Gender;

        //to increase customer_id
        public void custid()
        {
            con.Open();
            string query = "select max(Customer_id) from customer";

            MySqlCommand cm = new MySqlCommand(query, con);
            MySqlDataReader dr;
            dr = cm.ExecuteReader();
            if(dr.Read())
            {
                string val = dr[0].ToString();
                if(val == "")
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
                con.Close();
            }
        }

        //to increase account_no
        public void AccNo()
        {
            con.Open();
            string query1 = "select max(Account_No) from account_details";

            MySqlCommand cm1 = new MySqlCommand(query1, con);
            MySqlDataReader dr1;
            dr1 = cm1.ExecuteReader();
            if (dr1.Read())
            {
                string val1 = dr1[0].ToString();
                if (val1 == "")
                {
                    label16.Text = "200";
                }
                else
                {
                    int a1;
                    a1 = int.Parse(dr1[0].ToString());
                    a1 = a1 + 1;
                    label16.Text = a1.ToString();
                }
                con.Close();
            }
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            custid();
            AccNo();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "female";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "others";
        }

        private void txtsave_Click(object sender, EventArgs e)
        {
            string cid, fn, ln, birth, add, nat, em, occ, ph,an,at,dis,bl;
            cid = label15.Text;
            fn = textFirstName.Text;
            ln = textLastName.Text;
            birth = dateTimePicker1.Text;
            add = textAddress.Text;
            nat = texNation.Text;
            em = textemail.Text;
            occ = textoccup.Text;
            ph = textphone.Text;

            an = label16.Text;
            at = textAccType.Text;
            dis = textdescription.Text;
            bl = textBalance.Text;

            con.Open();
            MySqlCommand cm = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();

            cm.Connection = con;
            cm.Transaction = transation;

            try
            {

                cm.CommandText= "insert into customer(Customer_id,FirstName,LastName,Gender,Date_of_Birth ,Address,Nationality,Email_Address,Occupation,Phone_No ) values('"+cid+ "','" +fn+ "','" + ln + "','" + Gender + "','" + birth + "','" + add + "','" + nat + "','" + em + "','" + occ + "','" + ph + "')";
                cm.ExecuteNonQuery();
                cm.CommandText = "insert into account_details(Account_No,Customer_id,Account_type,Description,Balance) values('" + an + "','" + cid + "','" + at + "','" + dis + "','" + bl + "')";
                cm.ExecuteNonQuery();

                transation.Commit();
                MessageBox.Show("Record Added Succesfully....");
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

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        //upload picture

        MemoryStream ms;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openlog = new OpenFileDialog();
            if (openlog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openlog.FileName);
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
