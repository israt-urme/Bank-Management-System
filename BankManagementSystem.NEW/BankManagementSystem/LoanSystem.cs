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
    public partial class LoanSystem : Form
    {

        private Button b4 = new Button();
        private PrintDocument printDoc1 = new PrintDocument();

        public LoanSystem()
        {

            InitializeComponent();

            //printing..
            b4.Text = "BMS";
            b4.Click += new EventHandler(button3_Click);
            printDoc1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.Controls.Add(b4);
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");
        
        //to increase receipt no

        private void LoanSystem_Load(object sender, EventArgs e)
        {
            RecNo();
        }

        public void RecNo()
        {
            con.Open();
            string query = "select max(Receipt_no) from loan_details";

            MySqlCommand cm = new MySqlCommand(query, con);
            MySqlDataReader dr;
            dr = cm.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    label8.Text = "100";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    label8.Text = a.ToString();
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rno, accno, date, la, period, payment;
            rno = label8.Text;
            accno = textBox1.Text;
            date = dateTimePicker1.Text;
            la = textBox2.Text;
            period = textBox3.Text;
            payment = textBox4.Text;

            con.Open();
            MySqlCommand cm = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();

            cm.Connection = con;
            cm.Transaction = transation;

            try
            {

                cm.CommandText = "insert into loan_details(Receipt_no ,	Account_No ,	Date ,	Amount ,	Period, 	Payment, Due ) values('" + rno + "','" + accno + "','" + date + "','" + la + "','" + period + "','" + payment + "','" + la + "')";
                cm.ExecuteNonQuery();

                transation.Commit();
                MessageBox.Show("Loan Added Succesfully....");
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
            this.Close();
        }

        //printing

        Bitmap bmp;

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bmp = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //initialize_to_preview
            //e.Graphics.DrawImage(bmp, 25, 25);
            e.Graphics.DrawString("Bank Management System", new Font("Times New Roman", 25), Brushes.Purple, new Point(250, 80));
            e.Graphics.DrawString("Mirpur, Dhaka", new Font("Times New Roman", 18), Brushes.Purple, new Point(350, 120));
            e.Graphics.DrawString("Receipt No: " + label6.Text, new Font("Arial", 14), Brushes.Black, new Point(100, 200));
            e.Graphics.DrawString("Date: " + DateTime.Now, new Font("Arial", 14), Brushes.Black, new Point(100, 230));
            e.Graphics.DrawString("Account No: " + textBox1.Text, new Font("Arial", 14), Brushes.Black, new Point(100, 280));
            e.Graphics.DrawString("-------------------------------------------------------------------------", new Font("Times New Roman", 18), Brushes.Purple, new Point(100, 300));

            e.Graphics.DrawString("Loan Amount", new Font("Arial", 14), Brushes.Black, new Point(100, 360));
            e.Graphics.DrawString("Loan period(in month)", new Font("Arial", 14), Brushes.Black, new Point(100, 430));
            e.Graphics.DrawString("-------------------------------------------------------------------------", new Font("Times New Roman", 18), Brushes.Purple, new Point(100, 450));

            e.Graphics.DrawString("Payment(per month)", new Font("Arial", 14), Brushes.Black, new Point(100, 500));
            //connected values to preview

            e.Graphics.DrawString("Rs " + textBox2.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 360));
            e.Graphics.DrawString("   " + textBox3.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 430));
            e.Graphics.DrawString("Rs " + textBox4.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 500));
        
        }

        //calculating payment

        private void NewMethod()
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                Double payment = Convert.ToInt32(textBox2.Text) / Convert.ToInt32(textBox3.Text);
                textBox4.Text = payment.ToString();
            }
            else
            {
                textBox4.Text = "0";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }
    }
}
