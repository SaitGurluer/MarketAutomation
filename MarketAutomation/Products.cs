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
using static System.Collections.Specialized.BitVector32;

namespace MarketAutomation
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        ProductDAL productDal = new ProductDAL();
        string barcode;
        public void DeleteButton()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "delete";
            buttonColumn.HeaderText = "Ürünü Sil";
            buttonColumn.Text = "SİL";
            buttonColumn.DefaultCellStyle.BackColor = Color.Red;
            buttonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Insert(dataGridView1.ColumnCount, buttonColumn);

        }

       
        private void Products_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=productDal.listedProduct();
            productDal.getCategories(cmbxCategory);
            DeleteButton();
        }

        private void cmbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            productDal.getSubCategories(cmbxSubCategory, cmbxCategory);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(cmbxCategory.Text !="" && cmbxSubCategory.Text!="")
                dataGridView1.DataSource=productDal.listedFilteredProduct(productDal.getCatID(cmbxCategory),productDal.getSubCatID(cmbxSubCategory));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=productDal.listedSearchedProduct(txtProductName.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            barcode = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            productDal.Update(new Product
            {
                barcode = barcode,
                salePrice = double.Parse(txtPrice.Text)
            });
            dataGridView1.DataSource = productDal.listedProduct();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            productDal.Delete(new Product
            {
                barcode = barcode          
            });
            dataGridView1.DataSource = productDal.listedProduct();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DialogResult delete = MessageBox.Show("Ürünü Silmek İstediğinize Emin Misiniz ?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (delete == DialogResult.Yes)
                {
                    productDal.Delete(new Product
                    {
                        barcode = barcode
                    });
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = productDal.listedProduct();
                    DeleteButton();
                }   
            }
        }
    }
}
