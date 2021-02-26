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
using PagedList;

namespace BankManagementSystem
{
    public partial class Transaction_details : Form
    {
        public Transaction_details()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database = bank; username = root; password=;");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from transaction";

            MySqlCommand cm = new MySqlCommand(query, con);

            MySqlDataAdapter My = new MySqlDataAdapter();
            My.SelectCommand = cm;
            DataTable dTable = new DataTable();

            My.Fill(dTable);
            dataGridView1.DataSource = dTable;
            con.Close();
        }

        private void Transaction_details_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text=="Deposit")
            {
                MySqlDataAdapter My = new MySqlDataAdapter("select Transac_id, Account_No, Date, Balance, Deposit, Deposit_status, Withdraw_status from transaction where deposit_status='YES' and date between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", con);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if(comboBox1.Text=="Withdraw")
            {
                MySqlDataAdapter My = new MySqlDataAdapter("select Transac_id, Account_No, Date, Balance, Withdraw, Deposit_status, Withdraw_status from transaction where withdraw_status='YES' and date between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", con);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else if (comboBox1.Text == "Account_No")
            {
                MySqlDataAdapter My = new MySqlDataAdapter("select Transac_id, Account_No, Date, Balance, Withdraw, Deposit_status, Withdraw_status from transaction where Account_No='" +textBox1.Text+ "'and date between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", con);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            else
            {
                MySqlDataAdapter My = new MySqlDataAdapter("select * from transaction where date between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", con);
                // MySqlDataAdapter My = new MySqlDataAdapter("select * from transaction",con);
                DataTable dTable = new DataTable();
                My.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        Bitmap bp;
        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
            //int h = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            //bp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            //dataGridView1.Height = h;
            //printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bp, 10, 10);
        }
    }
}
