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
using System.Diagnostics;
namespace MarketAutomation
{
    public partial class AddStock : Form
    {
        public AddStock()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        ProductDAL productDal = new ProductDAL();   
        private void btnSearch_Click(object sender, EventArgs e)
        {

            //Burada ürünleri çekerken kolumn isimlenine alians uygula ve join yapıp ürünün adını vs. çek 
            if(mTxtBarcode.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from purchase where productID = @productID", conn);
                cmd.Parameters.AddWithValue("@productID",productDal.getProductIDbarcode(mTxtBarcode.Text));
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                dataGridView1.DataSource = dt;
                rdr.Close();
                conn.Close();
            }
        }

        private void btnAddInput_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into purchase values (@productID,@quantity,getdate(),@price)", conn);
            cmd.Parameters.AddWithValue("@productID", productDal.getProductIDbarcode(mTxtBarcodeAdd.Text));
            cmd.Parameters.AddWithValue("@quantity", mTxtQuantity.Text);
            cmd.Parameters.AddWithValue("@price", mTxtPurchasePrice.Text);
            cmd.ExecuteNonQuery();


            SqlCommand command = new SqlCommand("Update stock set stockAmount=stockAmount + @stockAmount where productID = @productID", conn);
            command.Parameters.AddWithValue("@stockAmount",mTxtQuantity.Text);
            command.Parameters.AddWithValue("@productID",productDal.getProductIDbarcode(mTxtBarcodeAdd.Text));
            command.ExecuteNonQuery();
            conn.Close();

        }

        private void AddStock_Load(object sender, EventArgs e)
        {

        }


    }
}
