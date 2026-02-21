using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAutomation
{
    public class processLogDAL
    {

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        Process process = new Process();
        

        public void Insert(string user,string barcodeText ,string quantityText, string priceText , double totalPrice, int receipt)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("insert into processLog values(@user,CONVERT(VARCHAR(5),GETDATE(),108),@receipt,@barcodeText,@quantityText,@priceText,@totalPrice)", conn);
            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@receipt", receipt);
            command.Parameters.AddWithValue("@barcodeText", barcodeText);
            command.Parameters.AddWithValue("@quantityText", quantityText);
            command.Parameters.AddWithValue("@priceText", priceText);
            command.Parameters.AddWithValue("@totalPrice", totalPrice);
            command.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("truncate table sales", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();
            receipt++;

            
        }
      
    }
}
