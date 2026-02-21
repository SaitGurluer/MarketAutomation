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
    public partial class Breakfast : Form
    {

        private SystemLogin sysLogin;
        public Breakfast(SystemLogin systemLogin)
        {
            InitializeComponent();
            sysLogin = systemLogin;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        List<string> names = new List<string>();
        List<string> barcodes = new List<string>();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Breakfast_Load(object sender, EventArgs e)
        {
         
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from breakfast ", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                names.Add(rdr["Name"].ToString());
                barcodes.Add(rdr["Barcode"].ToString());
            }
            rdr.Close();
            conn.Close();

        }

        public void ListedBreakfast()
        {
            int locX = 15;
            int locY = 135;

            for (int i = 0; i < names.Count; i++)
            {

                Button btn = new Button();
                btn.Text = names[i];
                btn.BackColor = Color.NavajoWhite;
                btn.Size = new System.Drawing.Size(185,120);                                            
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Click += btnEvent_Click;
                btn.Font = new Font("Tahoma", 16, FontStyle.Bold);
                if (i % 5 == 0 && i != 0)
                {
                    locX = 15;
                    locY += 125;
                }
                btn.Location = new Point(locX, locY);
                locX += 190;
                this.Controls.Add(btn);

            }
            void btnEvent_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                string product = btn.Text;
                for(int i = 0;i < names.Count;i++)
                {
                    if (names[i].Equals(product))
                    {
                        sysLogin.ImportText(barcodes[i].ToString());
                        //Bu satır ile kahvaltı formu açıkken form1'deki btnOK_Click event’ini tetikliyoruz.
                        sysLogin.btnOk.PerformClick();
                    }
                }
                
            }

        }
        private void Breakfast_Shown(object sender, EventArgs e)
        {
           ListedBreakfast();           
        } 


    }
}
