using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAutomation
{
    public partial class ProductInfo : Form
    {
        public ProductInfo()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        ProductDAL productDAL = new ProductDAL();
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> Info = new List<string>();
            Info.AddRange(productDAL.listedInfo(txtBarcode.Text));
            if (Info.Count !=0 )
            {
                lblCategory.Text = Info[0];
                lblSubCategory.Text = Info[1];
                lblBarcode.Text = Info[2];
                lblProductName.Text = Info[3];
                lblSale.Text = Info[4];
                lblUnit.Text = Info[5];
            }
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
