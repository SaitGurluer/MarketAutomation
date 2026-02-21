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
namespace MarketAutomation
{
    public partial class adminPanel : Form
    {
        public adminPanel()
        {
            InitializeComponent();
        }
       
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        string name;
        
        private void adminPanel_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct product = new AddProduct();
            product.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnLoginSystem_Click(object sender, EventArgs e)
        {
            SystemLogin loginSystem = new SystemLogin();
            loginSystem.Show();
            this.Dispose();
        }

        private void btnAddCashier_Click(object sender, EventArgs e)
        {
            AddUser adduser = new AddUser();
            adduser.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            ProductInfo productInfo = new ProductInfo();
            productInfo.Show();
            
        }

        private void btnShowCashier_Click(object sender, EventArgs e)
        {
            UserView userView = new UserView();
            userView.Show();
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            AddStock addStock = new AddStock();
            addStock.Show();

        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNotice_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.ShowDialog();
        }
    }
}
