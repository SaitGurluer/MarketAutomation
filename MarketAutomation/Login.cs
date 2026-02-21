using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAutomation
{
    public class Login
    {

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        public string control = "";
        public int Id;
        adminPanel adminpanel;
        SystemLogin sysLogin;
        GetUser getUser;
        Process process = new Process();
        public bool notFound = false;


        public void LoginControl(string Name , string Password,string choise)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from users where username = @username and password = @pass", conn);
            cmd.Parameters.AddWithValue("@username", Name);
            cmd.Parameters.AddWithValue("@pass", process.MD5Password(Password));
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Id = Convert.ToInt32(rdr["ID"]);
                string position = rdr["position"].ToString();
                getUser = new GetUser();

                if (choise == "adminpanel")
                {
                    notFound = false;
                    adminpanel = new adminPanel();
                    adminpanel.Show();
                    adminpanel.lblHeader.Text += " " + getUser.getUsername(Id);
                    if (position == "cashier")
                    {
                        adminpanel.btnProductUpdate.Visible = false;
                        adminpanel.btnProductDelete.Visible = false;
                        adminpanel.btnShowCashier.Visible = false;
                        adminpanel.btnAddCashier.Visible = false;
                        adminpanel.btnTotalSales.Visible = false;
                        adminpanel.btnNotice.Visible = false;
                    }

                }
                else if (choise == "systemlogin")
                {
                    notFound = false;
                    sysLogin = new SystemLogin();
                    sysLogin.Show();
                    sysLogin.lblCashier.Text = getUser.getUsername(Id);
                    sysLogin.txtID.Text = Id.ToString();

                }

            }
            else
            {
                MessageBox.Show("Sisteminizde Bu Bilgiler ile Eşleşen Kullanıcı Bulunamadı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                notFound = true;
            }
            rdr.Close();
            conn.Close();

        }
        public void loginControl(User user, string choise)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from users where username = @username and password = @pass", conn);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@pass", process.MD5Password(user.password));
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Id = Convert.ToInt32(rdr["ID"]);
                string position = rdr["position"].ToString();
                getUser = new GetUser();

                if (choise == "adminpanel")
                {
                    notFound = false;
                    adminpanel = new adminPanel();
                    adminpanel.Show();
                    adminpanel.lblHeader.Text += " " + getUser.getUsername(Id);
                    if (position == "cashier")
                    {
                        adminpanel.btnProductUpdate.Visible = false;
                        adminpanel.btnProductDelete.Visible = false;
                        adminpanel.btnNotice.Visible = false;
                        adminpanel.btnShowCashier.Visible = false;
                        adminpanel.btnAddCashier.Visible = false;
                        adminpanel.btnTotalSales.Visible = false;
                    }

                }
                else if (choise == "systemlogin")
                {
                    notFound = false;
                    sysLogin = new SystemLogin();
                    sysLogin.Show();
                    sysLogin.lblCashier.Text = getUser.getUsername(Id);
                    sysLogin.txtID.Text = Id.ToString();

                }

            }
            else
            {
                MessageBox.Show("Sisteminizde Bu Bilgiler ile Eşleşen Kullanıcı Bulunamadı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                notFound = true;
            }
            rdr.Close();
            conn.Close();

        }

    }
}
