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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }
        Process process = new Process();
        private void btnInsert_Click(object sender, EventArgs e)
        {
            UserDAL userDAL = new UserDAL();
            userDAL.Insert(new User
            {
                username = txtUsername.Text,
                password = process.MD5Password(txtPassword.Text),
                name = txtName.Text,
                surname = txtSurname.Text,
                position = txtPosition.Text,
                status =  int.Parse(cmbxStatus.Text)
            });
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
