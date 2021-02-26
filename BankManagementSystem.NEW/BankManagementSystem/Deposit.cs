using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace BankManagementSystem
{
    public partial class Deposit : Form
    {

        private Button b4 = new Button();
        private PrintDocument printDoc1 = new PrintDocument();

        public Deposit()
        {
            InitializeComponent();

            //printing..

            b4.Text = "BMS";
            b4.Click += new EventHandler(button4_Click);
            printDoc1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.Controls.Add(b4);
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "select * from account_details where Account_No = '" + textAccNo.Text + "'";
                MySqlCommand cm = new MySqlCommand(str,con);
                MySqlDataReader rd;
                rd = cm.ExecuteReader();
                if (rd.Read())
                {
                    textbal.Text=rd[4].ToString();
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
            catch(Exception ex)
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
            string acno, date, dep_status, wit_status;
            double bal, deposit;

            acno = textAccNo.Text;
            date = textAccDate.Text;
            bal = double.Parse(textbal.Text);
            deposit = double.Parse(textdeposit.Text);
            dep_status = "YES";
            wit_status = "NO";

            con.Open();
            MySqlCommand cm = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();

            cm.Connection = con;
            cm.Transaction = transation;
            


            try
            {
                 if (double.Parse(textdeposit.Text) >= 200)
                 {
                        cm.CommandText = "update account_details set Balance = Balance + '" + deposit + "' where Account_No = '" + acno + "'";
                        cm.ExecuteNonQuery();
                        cm.CommandText = "insert into transaction(Account_No ,Date,Balance ,Deposit,Deposit_status,Withdraw_status) values('" + acno + "','" + date + "','" + bal + "','" + deposit + "','" + dep_status + "','" + wit_status + "')";
                        cm.ExecuteNonQuery();

                        transation.Commit();
                        MessageBox.Show("Transaction Added Succesfully....");
                 }
                else
                {
                    errorProvider1.SetError(textdeposit, "minimum cash 300");
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

        private void Deposit_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        //printing....

        Bitmap bmp;

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bmp = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
            
            printDocument1.Print();
        }
        
        
        private void printDocument1_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e)
        {
            //initialize_to_preview
            //e.Graphics.DrawImage(bmp, 25, 25);
            e.Graphics.DrawString("Bank Management System", new Font("Times New Roman", 25), Brushes.Purple, new Point(250, 80));
            e.Graphics.DrawString("Mirpur, Dhaka", new Font("Times New Roman", 18), Brushes.Purple, new Point(350, 120));
            e.Graphics.DrawString("Account No: " + textAccNo.Text, new Font("Arial", 14), Brushes.Black, new Point(100, 200));
            e.Graphics.DrawString("Date: " + DateTime.Now, new Font("Arial", 14), Brushes.Black, new Point(100, 230));
            e.Graphics.DrawString( label5.Text , new Font("Arial", 14), Brushes.Black, new Point(100, 280));
            e.Graphics.DrawString("Main Balance", new Font("Arial", 14), Brushes.Black,new Point(100, 300));
            e.Graphics.DrawString("Deposit  Balance", new Font("Arial", 14), Brushes.Black, new Point(100, 360));
            e.Graphics.DrawString(label5.Text, new Font("Arial", 14), Brushes.Black, new Point(100, 410));
            e.Graphics.DrawString("Current Balance", new Font("Arial", 14), Brushes.Black, new Point(100, 430));
            //connected values to preview

            e.Graphics.DrawString("Rs "+ textbal.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 300));
            e.Graphics.DrawString("Rs "+ textdeposit.Text, new Font("Arial", 14), Brushes.Black, new Point(600, 360));
            e.Graphics.DrawString("Rs "+ textBox1.Text , new Font("Arial", 14), Brushes.Black, new Point(600, 430));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void textAccNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textdeposit_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            if (textbal.Text != "" && textdeposit.Text != "")
            {
                Decimal current_bal = Convert.ToInt32(textbal.Text) + Convert.ToInt32(textdeposit.Text);
                textBox1.Text = current_bal.ToString();
            }
            else
            {
                textBox1.Text = "0";
            }
        }

    }
}
