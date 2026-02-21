using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAutomation
{
    public partial class LockScreen : Form
    {
        public LockScreen()
        {
            InitializeComponent();
        }
        public TextBox activeTextBox;
        private void btnNumberClick(object sender, EventArgs e)
        {
            if (activeTextBox != null)
            {
                Button btn = (Button)sender;
                activeTextBox.Text += btn.Text;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            activeTextBox = (TextBox)sender;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            activeTextBox = (TextBox)sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "1" && txtPass.Text =="1")
            {
                this.Close();
            }
        }

        private void LockScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
