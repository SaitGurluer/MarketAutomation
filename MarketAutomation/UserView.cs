using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketAutomation
{
    public partial class UserView : Form
    {
        public UserView()
        {
            InitializeComponent();
        }
        UserDAL userDAL = new UserDAL();
       
        string ID; 
        public void Listed()
        {
            dataGridView1.DataSource = userDAL.Listed();
        }

        public void UpdateButton(string section)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "update";
            buttonColumn.HeaderText = section + " Yetkisi";
            buttonColumn.Text = "Yetkilendir";
            buttonColumn.DefaultCellStyle.BackColor = Color.Blue;
            buttonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Insert(dataGridView1.ColumnCount, buttonColumn);

        }

        public void authority(string Position)
        {
           
            DialogResult update = MessageBox.Show("Yetkilendirmek İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (update == DialogResult.Yes)
            {
                userDAL.Update(new User
                {
                    ID = int.Parse(ID),
                    position = Position

                }); 
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                Listed();
                UpdateButton("Satış");
                UpdateButton("Ekleme");
                UpdateButton("Güncelleme");

            }

        }

        public void UpdateAuthority()
        {
                 
            if (dataGridView1.CurrentRow.Cells[4].Selected)
            {
                authority("satis");       
            }
            if (dataGridView1.CurrentRow.Cells[5].Selected)
            {
                authority("ekle");
            }
            if (dataGridView1.CurrentRow.Cells[6].Selected)
            {
                authority("guncelle");
            }
            
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            Listed();
            UpdateButton("Satış");
            UpdateButton("Ekleme");
            UpdateButton("Güncelleme");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateAuthority();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

       
    }
}
