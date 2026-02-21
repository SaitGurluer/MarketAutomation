using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketAutomation
{
    public class GetUser
    {
        
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        string name;
        public string getUsername(int ID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select name,surname from users where ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                name += rdr[0].ToString()+" " + rdr[1].ToString();
            }
            return name;
        }




    }
}
