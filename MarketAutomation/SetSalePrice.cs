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
    public partial class SetSalePrice : Form
    {
       
        string Barcode;
        double oldPrice;
        public SetSalePrice(string barcode)
        {
            InitializeComponent();          
            Barcode = barcode;
        }

        
      

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        
        private void btnNumberClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtMoney.Text += btn.Text;
        }


        private void btnDeleteText(object sender, EventArgs e)
        {
            if (txtMoney.Text != "")
            {
                //txtMoney.Text = txtMoney.Text.Remove(txtMoney.Text.Length - 1);
                txtMoney.Text = "";
            }
        }

        private void SetSalePrice_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select salePrice from product where barcode = @barcode", conn);
            cmd.Parameters.AddWithValue("@barcode",Barcode);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtMoney.Text = reader["salePrice"].ToString();
                oldPrice = Convert.ToDouble(reader["salePrice"].ToString());
            }
            reader.Close();
            conn.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update product set salePrice = @salePrice where barcode = @barcode", conn);
            cmd.Parameters.AddWithValue("@salePrice", Convert.ToDouble(txtMoney.Text));
            cmd.Parameters.AddWithValue("@barcode", Barcode);
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
           
        }

        public void ReturnOldPrice()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update product set salePrice = @salePrice where barcode = @barcode", conn);
            cmd.Parameters.AddWithValue("@salePrice", oldPrice);
            cmd.Parameters.AddWithValue("@barcode", Barcode);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnDotClick(object sender, EventArgs e)
        {
            if (txtMoney.Text != "")
            {
                txtMoney.Text += btnDot.Text;
            }
        }
    }
}
