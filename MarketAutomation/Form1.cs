using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace MarketAutomation
{
    public partial class Form1 : Form
    {

        
        Login login = new Login();
        Keyboard keyBoard;
        public TextBox activeTextBox;

        public Form1()
        {
            InitializeComponent();
            keyBoard = new Keyboard(this);
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "12345";
            keyBoard.loadKeyBoard(1);
        }

       
        private void btnSystem_Click(object sender, EventArgs e)
        {     
            login.LoginControl(txtUsername.Text, txtPassword.Text,"systemlogin");
            if (!login.notFound)
            {
                this.Hide();
            }
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            login.LoginControl(txtUsername.Text, txtPassword.Text, "adminpanel");
            if (!login.notFound)
            {
                this.Hide();
            }
        }

      

        private void btnSmall_Click(object sender, EventArgs e)
        {
            keyBoard.loadKeyBoard(0);

        }

        private void btnBig_Click(object sender, EventArgs e)
        {
            keyBoard.loadKeyBoard(1);
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            keyBoard.ClearText();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            Environment.Exit(0);
        }


        private void txtUsername_Enter(object sender, EventArgs e)
        {
            activeTextBox = (TextBox)sender;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            activeTextBox = (TextBox)sender;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //textBox1.Text = "X = " + Cursor.Position.X + "Y = " + Cursor.Position.Y;
        }
    }
}
