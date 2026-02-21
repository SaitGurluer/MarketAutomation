using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MarketAutomation
{
    public partial class SystemLogin : Form
    {

        public SystemLogin()
        {
            InitializeComponent();
        }
        // Sadece Tarih Bilgisi Almak İçin --> CONVERT(DATE,GETDATE(),104)
        // Sadece Saat Bilgisi Almak İçin --> CONVERT(VARCHAR(5),GETDATE(),108)
        //8690524164832
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");
        salesDAL salesDal = new salesDAL();
        Process process = new Process();
        processLogDAL processLogDal = new processLogDAL();
        Form1 form1 = new Form1();
        int receipt = 1;


        public void ImportText(string text)
        {
            txtInput.Text += text;
        }


        public void DGWColumns(DataGridView dgw)
        {
            dgw.ColumnCount = 8;
            dgw.Columns[0].Name = "No";
            dgw.Columns[1].Name = "Barkod";
            dgw.Columns[2].Name = "Ürün Adı";
            dgw.Columns[3].Name = "Adet";
            dgw.Columns[4].Name = "Birim";
            dgw.Columns[5].Name = "KDV";
            dgw.Columns[6].Name = "Fiyat";
            dgw.Columns[7].Name = "Tutar";      
            dgw.Rows.Add(" ", " ", " ", " ", " ", " ", " ", " ");
        }


        private void systemLogin_Load(object sender, EventArgs e)
        {
            lblCalendar.Text = DateTime.Now.Date.ToString().TrimEnd('0', ':');
            lblReceipt.Text = receipt.ToString();
        }

        private void btnNumberClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtInput.Text += btn.Text;
        }

        private void btnMultiChar_Click(object sender, EventArgs e)
        {
            if (!(txtInput.Text.Contains("*")))
            {
                txtInput.Text += "*";
            }
        }

        private void btnDeleteText_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                txtInput.Text = txtInput.Text.Remove(txtInput.Text.Length - 1);
            }
        }

        bool start = true;

        void ClearColumn()
        {
            dataGridView1.Columns.Clear();
        }

     
        private void btnOk_Click(object sender, EventArgs e)
        {
 
            if (start)
            {
                ClearColumn();
                start = false;
            }
            double totalPrice = 0;
            int quantity = 1;
            int starLocation = 0;
            if (txtInput.Text != "")
            {
                string netBarcode = txtInput.Text;

                if (txtInput.Text.Contains("*"))
                {
                    starLocation = txtInput.Text.IndexOf("*");
                    quantity = int.Parse(txtInput.Text.Substring(0, int.Parse(starLocation.ToString())));
                    netBarcode = txtInput.Text.Substring(int.Parse(starLocation.ToString()) + 1);
                }


                if (setSalePrice)
                {
                    SetSalePrice set = new SetSalePrice(netBarcode);
                    set.ShowDialog();
                    totalPrice = salesDal.findTotalPrice(netBarcode, quantity);
                    salesDal.Insert(netBarcode, quantity, totalPrice);
                    dataGridView1.DataSource = salesDal.Listed();
                    set.ReturnOldPrice();

                }
                else
                {
                    totalPrice = salesDal.findTotalPrice(netBarcode, quantity);
                    salesDal.Insert(netBarcode, quantity, totalPrice);
                    dataGridView1.DataSource = salesDal.Listed();
                }



                //totalPrice = salesDal.findTotalPrice(netBarcode, quantity);
                //salesDal.Insert(netBarcode, quantity, totalPrice);
                //dataGridView1.DataSource = salesDal.Listed();
                dataGridView1.Columns[8].Visible = false;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "1")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                txtInput.Clear();

                if (dataGridView1.Rows.Count > 1)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                }


            }

        }



        private void txtInput_TextChanged(object sender, EventArgs e)
        {

            int quantity = 1;
            int starLocation = 0;
            double totalPrice = 0;
            if (txtInput.Text != "")
            {
                string netBarcode = txtInput.Text;

                if (txtInput.Text.Contains("*"))
                {
                    starLocation = txtInput.Text.IndexOf("*");
                    quantity = int.Parse(txtInput.Text.Substring(0, int.Parse(starLocation.ToString())));
                    netBarcode = txtInput.Text.Substring(int.Parse(starLocation.ToString()) + 1);
                }
                if (netBarcode.Length == 13)
                {
                    
                    if (start)
                    {
                        ClearColumn();
                        start = false;
                    }

                    totalPrice = salesDal.findTotalPrice(netBarcode, quantity);
                    salesDal.Insert(netBarcode, quantity,totalPrice);
                    dataGridView1.DataSource = salesDal.Listed();
                    dataGridView1.Columns[8].Visible = false;
                    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[8].Value.ToString()== "1")
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                   
                    txtInput.Clear();
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];

                }
            }
        }



        private void btnCash_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dataGridView1.Rows.Count > 0 && dt != null)
            {
                start = true; 
                string IdText = "";
                string priceText = "";
                string quantityText = "";
                double totalPrice = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select ID from product where barcode = @barcode", conn);
                    cmd.Parameters.AddWithValue("@barcode", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        IdText += rdr[0].ToString() + " ";

                    }
                    rdr.Close();
                    conn.Close();
                    priceText += dataGridView1.Rows[i].Cells[7].Value.ToString() + " ";
                    quantityText += dataGridView1.Rows[i].Cells[3].Value.ToString() + " ";
                    totalPrice += double.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                }
    
                processLogDal.Insert(txtID.Text, IdText, quantityText, priceText, totalPrice, receipt);
                receipt++;
                lblReceipt.Text = receipt.ToString();

            
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                DGWColumns(dataGridView1);

            }
        }



        private void btnBreakfast_Click(object sender, EventArgs e)
        {
            Breakfast breakfast = new Breakfast(this);
            breakfast.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            form1.Show();
        }

        private void btnKeypad_Click(object sender, EventArgs e)
        {
            if (TLPnumbers.Visible == true)
            {
                btnKeypad.Text = "KEYPAD ON";
                TLPprocess.Visible = true;
                TLPnumbers.Visible = false;
            }
            else if (TLPnumbers.Visible == false)
            {
                btnKeypad.Text = "KEYPAD OFF";
                TLPprocess.Visible = false;
                TLPnumbers.Visible = true;
            }
        }



        private void SystemLogin_Shown(object sender, EventArgs e)
        {
            txtInput.Focus();
        }


        public void deleteRow(int Id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update sales set isCancel='1' where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(Id.ToString()));
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
            deleteRow((dataGridView1.CurrentRow.Index) + 1);
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];

        }

        private void btnReceiptDelete_Click(object sender, EventArgs e)
        {
           
            start = true;
            salesDal.TruncateTable();   
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            DGWColumns(dataGridView1);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

            start = true;            
            string userIDText = "";
            string logTimeText = "";
            string receiptNoText = "";
            string productIDText = "";
            string productPriceText = "";
            string totalPriceText = "";        
            double dailyTotalPrice = 0;

            conn.Open();
            SqlCommand command = new SqlCommand("select * from processLog",conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userIDText += reader[1].ToString()+" ";
                logTimeText += reader[2].ToString()+" ";
                receiptNoText += reader[3].ToString()+ " "; 
                productIDText += reader[4].ToString();
                productPriceText += reader[5].ToString();
                totalPriceText += reader[6].ToString();
                dailyTotalPrice += double.Parse(reader[7].ToString());
            }
            reader.Close();
            conn.Close();



            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into zReport values(@userIDText,@logTimeText,@receiptNoText,@productIDText,@productPriceText,@totalPriceText,@dailyTotalPrice,CONVERT(DATE,GETDATE(),104))",conn);
            cmd.Parameters.AddWithValue("@userIDText", userIDText);
            cmd.Parameters.AddWithValue("@logTimeText", logTimeText);
            cmd.Parameters.AddWithValue("@receiptNoText", receiptNoText);
            cmd.Parameters.AddWithValue("@productIDText", productIDText);
            cmd.Parameters.AddWithValue("@productPriceText", productPriceText);
            cmd.Parameters.AddWithValue("@totalPriceText", totalPriceText);
            cmd.Parameters.AddWithValue("@dailyTotalPrice", dailyTotalPrice);
            cmd.ExecuteNonQuery();



            SqlCommand CMD = new SqlCommand("truncate table processLog",conn);
            CMD.ExecuteNonQuery();
            conn.Close();
            
        
        }

        bool setSalePrice=false;
        private void btnSetSalePrice_Click(object sender, EventArgs e)
        {
            if (setSalePrice)
            {
                setSalePrice = false;
                btnSetSalePrice.BackColor = Color.MediumSpringGreen;
                btnSetSalePrice.ForeColor = Color.Black;

            }
            else
            {
                setSalePrice = true;
                btnSetSalePrice.BackColor = Color.Red;
                btnSetSalePrice.ForeColor = Color.White;
            }
            
        }

        private void btnWiFi_Click(object sender, EventArgs e)
        {
           
        }

        private void btnFindPrice_Click(object sender, EventArgs e)
        {
            ProductInfo productInfo = new ProductInfo();
            productInfo.ShowDialog();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            LockScreen locked = new LockScreen();
            locked.ShowDialog();
        }

        private void btnLegume_Click(object sender, EventArgs e)
        {
        
        }
    }
}
