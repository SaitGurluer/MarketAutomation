using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAutomation
{
    public class UserDAL
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");


        public DataTable Listed()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ID,name,surname,position from users where position not in('admin')",conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            conn.Close();
            return dt;
        }


        public void Insert(User user)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into users values (@username , @password , @name , @surname , @position , @status)",conn);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@surname", user.surname);
            cmd.Parameters.AddWithValue("@position", user.position);
            cmd.Parameters.AddWithValue("@status", user.status);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void Update(User user) 
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update users set position=@position where ID = @ID", conn);
            cmd.Parameters.AddWithValue("@ID", user.ID);
            cmd.Parameters.AddWithValue("@position", user.position);        
            cmd.ExecuteNonQuery();
            conn.Close();

        }

    }
}
