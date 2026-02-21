using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAutomation
{
    public class ProductDAL
    {

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        public void getCategories(ComboBox cmbxCategory)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from category", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbxCategory.Items.Add(reader[2]);
            }
            conn.Close();
        }

        public void getSubCategories(ComboBox cmbxSubCategory, ComboBox cmbxCategory)
        {
            cmbxSubCategory.Items.Clear();
            cmbxSubCategory.Text = "";
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from subCategory,category where categoryName=@Name and category.ID = subCategory.categoryID ", conn);
            command.Parameters.AddWithValue("@Name", cmbxCategory.SelectedItem.ToString());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbxSubCategory.Items.Add(reader[2]);
            }
            conn.Close();
        }

        public int getCatID(ComboBox cmbxCategory)
        {
           
            Product product = new Product();
            conn.Open();
            SqlCommand command = new SqlCommand("Select ID from category where categoryName=@catName", conn);
            command.Parameters.AddWithValue("@catName", cmbxCategory.SelectedItem.ToString());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                product.categoryID = reader.GetInt32(0);
            }
            conn.Close();
            return product.categoryID;
            
        }

        public int getSubCatID(ComboBox cmbxSubCategory)
        {

            Product product = new Product();
            conn.Open();
            SqlCommand command = new SqlCommand("Select ID from subCategory where subCategoryName=@subCatName", conn);
            command.Parameters.AddWithValue("@subCatName", cmbxSubCategory.SelectedItem.ToString());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                product.subCategoryID = reader.GetInt32(0);
            }
            conn.Close();
            return product.subCategoryID;
            
        }


        public void getProductName(ComboBox cmbxProductName)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from product", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbxProductName.Items.Add(reader[4]);
            }
            conn.Close();
        }


        public int getProductID(ComboBox cmbxProductName)
        {

            Product product = new Product();
            conn.Open();
            SqlCommand command = new SqlCommand("Select ID from product where name=@productName", conn);
            command.Parameters.AddWithValue("@productName", cmbxProductName.SelectedItem.ToString());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                product.ID = reader.GetInt32(0);
            }
            conn.Close();
            return product.ID;

        }

        public int getProductIDbarcode(string barcode)
        {
            Product product = new Product();
            conn.Open();
            SqlCommand command = new SqlCommand("Select ID from product where barcode=@barcode", conn);
            command.Parameters.AddWithValue("@barcode",barcode);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                product.ID = reader.GetInt32(0);
            }
            conn.Close();
            return product.ID;
        }








        public DialogResult addResult;
        public void Insert(Product product)
        {
            
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into product values(@categoryID,@subCategoryID,@barcode,@name,@salePrice,@unit)", conn);
            cmd.Parameters.AddWithValue("@categoryID", product.categoryID);
            cmd.Parameters.AddWithValue("@subCategoryID", product.subCategoryID);
            cmd.Parameters.AddWithValue("@barcode", product.barcode);
            cmd.Parameters.AddWithValue("@name", product.name);                    
            cmd.Parameters.AddWithValue("@salePrice", product.salePrice);
            cmd.Parameters.AddWithValue("@unit", product.unit);         
            cmd.ExecuteNonQuery();


            SqlCommand command = new SqlCommand("insert into stock (productID) select ID from product where barcode = @barcode",conn);
            command.Parameters.AddWithValue("@barcode",product.barcode);
            command.ExecuteNonQuery();

            conn.Close();
            addResult =  MessageBox.Show("Ürün Başarılı Bir Şekilde Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        public void Update(Product product)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update product set salePrice = @salePrice where barcode=@barcode ", conn);           
            cmd.Parameters.AddWithValue("@barcode", product.barcode);         
            cmd.Parameters.AddWithValue("@salePrice", product.salePrice);
            cmd.ExecuteNonQuery();

            SqlCommand command = new SqlCommand("insert into pricing (productID,salePrice,labelDate) select ID,salePrice,getdate() from product where barcode = @barcode", conn);
            command.Parameters.AddWithValue("@barcode", product.barcode);
            command.ExecuteNonQuery();

            conn.Close();
            
        }

        public void Delete(Product product)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from product where barcode = @barcode", conn);
            cmd.Parameters.AddWithValue("@barcode", product.barcode);
            cmd.ExecuteNonQuery();
            conn.Close();
           
        }

       

        public List<string> listedInfo(string netBarcode)
        {
            List<string> Info = new List<string>();
            conn.Open();
            string query = "select categoryName as [Kategori],subCategoryName as [Alt Kategori],barcode as [Barkod],name as [Ürün Adı]," +
                "salePrice as [Satış Fiyatı],unit as [Birim] from product inner join category on product.categoryID=category.ID " +
                "inner join subCategory on product.subCategoryID=subCategory.ID where product.barcode=@netBarcode";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@netBarcode", netBarcode);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Info.Add(reader[0].ToString());
                Info.Add(reader[1].ToString());
                Info.Add(reader[2].ToString());
                Info.Add(reader[3].ToString());
                Info.Add(reader[4].ToString());
                Info.Add(reader[5].ToString()); ;              
            }
            reader.Close();
            conn.Close();
            return Info;
        }



        public DataTable listedProduct()
        {
            conn.Open();
            string query = "select categoryName as [Kategori],subCategoryName as [Alt Kategori],barcode as [Barkod],name as [Ürün Adı]," +
                "salePrice as [Satış Fiyatı],unit as [Birim] from product inner join category on product.categoryID=category.ID " +
                "inner join subCategory on product.subCategoryID=subCategory.ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            conn.Close();
            return dt;       
        }


        public DataTable listedFilteredProduct(int categoryID, int subCategoryID)
        {
            conn.Open();
            string query = "select categoryName as [Kategori],subCategoryName as [Alt Kategori],barcode as [Barkod],name as [Ürün Adı]," +
                "salePrice as [Satış Fiyatı],unit as [Birim] from product inner join category on product.categoryID=category.ID " +
                "inner join subCategory on product.subCategoryID=subCategory.ID " +
                "where product.categoryID=@categoryID and product.subCategoryID=@subCategoryID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@categoryID", categoryID);
            cmd.Parameters.AddWithValue("@subCategoryID", subCategoryID);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            rdr.Close();
            conn.Close();
            return dt;
        }



        public DataTable listedSearchedProduct(string productName)
        {
            conn.Open();
            string query = "select categoryName as [Kategori],subCategoryName as [Alt Kategori],barcode as [Barkod],name as [Ürün Adı]," +
                "salePrice as [Satış Fiyatı],unit as [Birim] from product inner join category on product.categoryID=category.ID " +
                "inner join subCategory on product.subCategoryID=subCategory.ID where product.name like '%" + productName + "%' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();
            return dt;
        }

    }
}
