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
    public partial class Notice : Form
    {
        public Notice()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=market;Integrated Security=True;TrustServerCertificate=True");

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Listed()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Id as [Kod] ,Title as [Mesaj Başlığı] , Details as [Mesaj Detayı] from notice", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable(); 
            dt.Load(rdr);
            dataGridView1.DataSource = dt;
            rdr.Close();    
            conn.Close();
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into notice(Title,Details) values(@Title,@Details) ",conn);
            cmd.Parameters.AddWithValue("@Title",txtTitle.Text);
            cmd.Parameters.AddWithValue("@Details", txtDetails.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Tebrikler Mesaj Başarılı Bir Şekilde İletildi ","Bilgilendirme ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTitle.Text = "";
            txtDetails.Text = "";
            Listed();
        }

        private void Notice_Load(object sender, EventArgs e)
        {
            Listed();
        }
        int Id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtTitle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDetails.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnUpdateMessage_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update notice set Title =@Title , Details=@Details where Id = @Id ", conn);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@Details", txtDetails.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Tebrikler Mesaj Başarılı Bir Şekilde Güncellendi ", "Bilgilendirme ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTitle.Text = "";
            txtDetails.Text = "";
            Listed();
        }

        private void btnDeleteMessage_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from notice where Id = @Id ", conn);
            cmd.Parameters.AddWithValue("@Id", Id);           
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Tebrikler Mesaj Başarılı Bir Şekilde Silindi ", "Bilgilendirme ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTitle.Text = "";
            txtDetails.Text = "";
            Listed();
        }
    }
}
