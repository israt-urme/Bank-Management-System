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
using System.Drawing.Printing;


namespace BankManagementSystem
{
    public partial class Withdraw : Form
    {

        private Button b4 = new Button();
        private PrintDocument printDoc1 = new PrintDocument();

        public Withdraw()
        {
            InitializeComponent();

            //printing..

            b4.Text = "BMS";
            b4.Click += new EventHandler(button4_Click);
            printDoc1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.Controls.Add(b4);
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "select * from account_details where Account_No = '" + textAccNo.Text + "'";
                MySqlCommand cm = new MySqlCommand(str, con);
                MySqlDataReader rd;
                rd = cm.ExecuteReader();
                if (rd.Read())
                {
                    textbal.Text = rd[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string acno, date,dep_status,wit_status;
            double bal, withdraw;

            acno = textAccNo.Text;
            date = textAccDate.Text;
            bal = double.Parse(textbal.Text);
            withdraw = double.Parse(textwithdraw.Text);
            dep_status = "NO";
            wit_status = "YES";

            con.Open();
            MySqlCommand cm = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();

            cm.Connection = con;
            cm.Transaction = transation;

            try
            {
                if ((double.Parse(textbal.Text)) - (double.Parse(textwithdraw.Text)) >= 500)
                {


                    cm.CommandText = "update account_details set Balance = Balance - '" + withdraw + "' where Account_No = '" + acno + "'";
                    cm.ExecuteNonQuery();
                    cm.CommandText = "insert into transaction(Account_No ,Date,Balance ,Withdraw,Deposit_status,Withdraw_status) values('" + acno + "','" + date + "','" + bal + "','" + withdraw + "','" + dep_status + "','" + wit_status + "')";
                    cm.ExecuteNonQuery();

                    transation.Commit();
                    MessageBox.Show("Transaction Added Succesfully....");
                }
                else
                {
                    errorProvider1.SetError(textwithdraw, "cash below 500");
                    MessageBox.Show("Cash must have upto 500tk\nTry Again!!");
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

        //printing....

        Bitmap bmp;

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Bank Management System", new Font("Times New Roman", 25), Brushes.Purple, new Point(250, 80));
            e.Graphics.DrawString("Mirpur, Dhaka", new Font("Times New Roman", 18), Brushes.Purple, new Point(350, 120));
            e.Graphics.DrawString("Account No: " + textAccNo.Text, new Font("Arial", 14), Brushes.Black, new Point(100, 200));
            e.Graphics.DrawString("Date: " + DateTime.Now, new Font("Arial", 14), Brushes.Black, new Point(100, 230));
            e.Graphics.DrawString(label6.Text, new Font("Arial", 14), Brushes.Black, new Point(100, 280));
            e.Graphics.DrawString("Main Balance", new Font("Arial", 14), Brushes.Black, new Point(100, 300));
            e.Graphics.DrawString("Withdraw  Balance", new Font("Arial", 14), Brushes.Black, new Point(100, 360));
            e.Graphics.DrawString(label6.Text, new Font("Arial", 14), Brushes.Black, new Point(100, 410));
            e.Graphics.DrawString("Current Balance", new Font("Arial", 14), Brushes.Black, new Point(100, 430));
            //connected values to preview

            e.Graphics.DrawString("Rs " + textbal.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 300));
            e.Graphics.DrawString("Rs " + textwithdraw.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 360));
            e.Graphics.DrawString("Rs " + textBox1.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 430));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bmp = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

            printDocument1.Print();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {

        }

        private void NewMethod()
        {
            if (textbal.Text != "" && textwithdraw.Text != "")
            {
                Decimal current_bal = Convert.ToInt32(textbal.Text) - Convert.ToInt32(textwithdraw.Text);
                textBox1.Text = current_bal.ToString();
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void textwithdraw_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
