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
    public class salesDAL
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        Process process = new Process();
     
        // İF txtInput.Text DOES NOT CONTAIN THIS CHARACTER (*)   
        int starLocation = 0;
       
        //DEFAULT PRODUCT QUANTITY --> 1
        int quantity = 1;


        string salePrice;
        public double findTotalPrice(string netBarcode , int quantity)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select salePrice from product where product.barcode = @netBarcode", conn);
            cmd.Parameters.AddWithValue("@netBarcode", netBarcode);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                salePrice = reader[0].ToString();
            }
            conn.Close();
            return quantity * double.Parse(salePrice);
            //Insert(netBarcode, quantity, quantity * double.Parse(salePrice));
           
        }
        

        public void Insert(string netBarcode, int quantity, double totalPrice)
        {          
            conn.Open();
            string query =
                "Insert into sales(categoryID,productID,subCategoryID,taxID ,quantity,totalSales) " +
                "select category.ID , product.ID , subCategory.ID , tax.ID, @quantity , @totalPrice " +
                "from category , product ,subCategory ,tax where tax.ID = category.taxID and subCategory.categoryID = category.ID " +
                "and category.ID=product.categoryID and product.subCategoryID = subCategory.ID and product.barcode = @barcode";

            //"Insert into sales(categoryID,productID,subCategoryID,taxID ,quantity,totalSales) " +
            //"select category.Id , product.Id , subCategory.Id , tax.Id, '" + quantity + "' , '" + totalPrice + "' from category " +
            //"inner join tax on category.taxID=tax.Id  inner join subCategory on category.Id = subCategory.categoryID " +
            //"inner join product on category.Id=product.categoryID where product.barcode = '" + netBarcode + "' and subCategory.ID = product.subCategoryID  ";
            
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@barcode", netBarcode);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
            cmd.ExecuteNonQuery();
            conn.Close();        
        }

        
        public DataTable Listed()
        {
            
            conn.Open();
            string query = "Select sales.ID as [No] , product.barcode as [Barkod], product.name as [Ürün Adı], sales.quantity as [Adet]," +
                " product.unit as [Birim], tax.taxRate as [KDV], product.salePrice as [Fiyat], sales.totalSales as [Tutar], sales.isCancel from sales ," +
                " product , category , subCategory , tax where sales.categoryID = category.ID and sales.productID = product.ID and " +
                " sales.subCategoryID = subCategory.ID and sales.taxID = tax.ID ";
            SqlCommand command = new SqlCommand(query, conn);    
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();
            return dt;
        }

        //public DataTable ClearDT() 
        //{
        //    dt.Clear();
        //    return dt;
        //}

        public void TruncateTable()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("truncate table sales", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            conn.Close();
        }

    }
}

