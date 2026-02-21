using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace MarketAutomation
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        ProductDAL productDAL = new ProductDAL();
        private void Product_Load(object sender, EventArgs e)
        {
            productDAL.getCategories(cmbxCategory);
        }


        public void clearText()
        {
            cmbxCategory.Text = "";
            cmbxSubCategory.Text = "";
            mTxtBarcode.Text = "";
            txtProductName.Text = "";     
            mTxtSale.Text = "";
            cmbxUnit.Text = "";
        }


        private void cmbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            productDAL.getSubCategories(cmbxSubCategory,cmbxCategory);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Ürünü Eklemek İstediğinize Emin Misiniz ?","Bilgilendirme",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (result == DialogResult.Yes) { 
                productDAL.Insert(new Product
                {
                    categoryID = int.Parse(productDAL.getCatID(cmbxCategory).ToString()),
                    subCategoryID = int.Parse(productDAL.getSubCatID(cmbxSubCategory).ToString()),
                    barcode = mTxtBarcode.Text,
                    name = txtProductName.Text,
                    salePrice = double.Parse(mTxtSale.Text),
                    unit = cmbxUnit.Text,
                });
            }
            if(productDAL.addResult == DialogResult.OK)
            {
                clearText();
            }

        }




        
    }
}
