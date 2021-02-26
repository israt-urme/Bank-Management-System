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
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;
            if(progressBar1.Value>=99)
            {
                Main m = new Main();
                this.Hide();
                m.Show();

                timer1.Enabled = false;
                progressBar1.Value = progressBar1.Value - 1;
            }
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {

        }
    }
}
