using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BankManagementSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateAccount account = new CreateAccount();
            account.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            DialogResult iExit;
            iExit = MessageBox.Show("Are you sure you want to exit",
                "Bank Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Withdraw wit = new Withdraw();
            wit.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Transfer tran = new Transfer();
            tran.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Account_details acc = new Account_details();
            acc.Show();
        }
/*
        private void button2_Click(object sender, EventArgs e)
        {
            Register_Loan rl = new Register_Loan();
            rl.Show();
        }
        */
        private void button9_Click(object sender, EventArgs e)
        {
            Transaction_details tr = new Transaction_details();
            tr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            LoanSystem ls = new LoanSystem();
            DialogResult iExit;
            iExit = MessageBox.Show("Already have an account",
                "Bank Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                ls.Show();
            }
            else if (iExit == DialogResult.No)
            {
                CreateAccount ca = new CreateAccount();
                ca.Show();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            LoanDetails ld = new LoanDetails();
            ld.Show();
        }
    }
}
