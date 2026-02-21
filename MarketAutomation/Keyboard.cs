using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace MarketAutomation
{

    public class Keyboard 
    {

        private Form1 form1;
        public Keyboard(Form1 _form1)
        {
           form1 = _form1;
        }

        public void loadKeyBoard(int size)
        {

            // Eski klavye butonlarını temizlemek için bu kodu yazıyoruz
            for (int i = form1.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = form1.Controls[i];
                if (ctrl is Button btn && btn.Tag != null && btn.Tag.ToString() == "keyboard")
                {
                    form1.Controls.Remove(ctrl);
                    ctrl.Dispose(); // Eski klavye butonlarını hafızadan da silmek için
                }
            }

            char[] keyChar = new char[40] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I',
                'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V',
                'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            

            int locX = 510;
            int locY = 80;

            for (int i = 0; i < keyChar.Length; i++)
            {

                Button btn = new Button();
                btn.Size = new System.Drawing.Size(60, 50);
                btn.Tag = "keyboard"; // SİLMEK için işaret koyuyoruz
                if (size == 0)
                {
                    btn.Text = keyChar[i].ToString().ToLower();
                }
                else if (size == 1)
                {
                    btn.Text = keyChar[i].ToString().ToUpper();
                }
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Click += btnEvent_Click;
                btn.Font = new Font("Tahoma", 20, FontStyle.Bold);
                if (i % 5 == 0 && i != 0)
                {
                    locX = 510;
                    locY += 50;
                }
                if (i == 30)
                {
                    locY += 20;
                }
                btn.Location = new Point(locX, locY);
                locX += 60;
                form1.Controls.Add(btn);

            }


            void btnEvent_Click(object sender, EventArgs e)
            {
                if (form1.activeTextBox != null)
                {
                    Button btn = (Button)sender;
                    form1.activeTextBox.Text += btn.Text;
                    form1.activeTextBox.Select(form1.activeTextBox.Text.Length, 0); // İmleç sona
                }
            }

        }

        public void TLPclear(TableLayoutPanel tlp1, TableLayoutPanel tlp2)
        {
            tlp1.Controls.Clear();
            tlp2.Controls.Clear();
        }


        public void ClearText()
        {
            if (form1.activeTextBox != null)
            {   if(form1.activeTextBox.Text.Length > 0)
                {
                    form1.activeTextBox.Text = form1.activeTextBox.Text.Remove(form1.activeTextBox.Text.Length - 1);
                    form1.activeTextBox.Select(form1.activeTextBox.Text.Length, 0); // İmleç sona
                }       
            }
        }



    }
}
