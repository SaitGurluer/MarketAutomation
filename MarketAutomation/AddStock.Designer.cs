namespace MarketAutomation
{
    partial class AddStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mTxtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.mTxtPurchasePrice = new System.Windows.Forms.MaskedTextBox();
            this.btnAddInput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mTxtBarcodeAdd = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mTxtBarcode = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTxtQuantity
            // 
            this.mTxtQuantity.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mTxtQuantity.Location = new System.Drawing.Point(369, 70);
            this.mTxtQuantity.Mask = "00000000";
            this.mTxtQuantity.Name = "mTxtQuantity";
            this.mTxtQuantity.Size = new System.Drawing.Size(279, 40);
            this.mTxtQuantity.TabIndex = 1;
            this.mTxtQuantity.ValidatingType = typeof(int);
            // 
            // mTxtPurchasePrice
            // 
            this.mTxtPurchasePrice.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mTxtPurchasePrice.Location = new System.Drawing.Point(701, 70);
            this.mTxtPurchasePrice.Mask = "00000000";
            this.mTxtPurchasePrice.Name = "mTxtPurchasePrice";
            this.mTxtPurchasePrice.Size = new System.Drawing.Size(279, 40);
            this.mTxtPurchasePrice.TabIndex = 2;
            this.mTxtPurchasePrice.ValidatingType = typeof(int);
            // 
            // btnAddInput
            // 
            this.btnAddInput.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddInput.Location = new System.Drawing.Point(31, 137);
            this.btnAddInput.Name = "btnAddInput";
            this.btnAddInput.Size = new System.Drawing.Size(949, 59);
            this.btnAddInput.TabIndex = 3;
            this.btnAddInput.Text = "Girdi Ekle";
            this.btnAddInput.UseVisualStyleBackColor = true;
            this.btnAddInput.Click += new System.EventHandler(this.btnAddInput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(363, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alınan Miktarı Girin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(695, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "Alış Fiyatını Giriniz";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.mTxtBarcodeAdd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.mTxtPurchasePrice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mTxtQuantity);
            this.panel1.Controls.Add(this.btnAddInput);
            this.panel1.Location = new System.Drawing.Point(37, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 232);
            this.panel1.TabIndex = 7;
            // 
            // mTxtBarcodeAdd
            // 
            this.mTxtBarcodeAdd.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mTxtBarcodeAdd.Location = new System.Drawing.Point(31, 70);
            this.mTxtBarcodeAdd.Mask = "0000000000000";
            this.mTxtBarcodeAdd.Name = "mTxtBarcodeAdd";
            this.mTxtBarcodeAdd.Size = new System.Drawing.Size(279, 40);
            this.mTxtBarcodeAdd.TabIndex = 7;
            this.mTxtBarcodeAdd.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 34);
            this.label5.TabIndex = 8;
            this.label5.Text = "Barkod Giriniz";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 443);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1012, 374);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(696, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(279, 53);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Sorgula";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.mTxtBarcode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Location = new System.Drawing.Point(37, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 100);
            this.panel2.TabIndex = 11;
            // 
            // mTxtBarcode
            // 
            this.mTxtBarcode.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mTxtBarcode.Location = new System.Drawing.Point(364, 31);
            this.mTxtBarcode.Mask = "0000000000000";
            this.mTxtBarcode.Name = "mTxtBarcode";
            this.mTxtBarcode.Size = new System.Drawing.Size(279, 40);
            this.mTxtBarcode.TabIndex = 12;
            this.mTxtBarcode.ValidatingType = typeof(int);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(34, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 34);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ürün Barkodu Girin";
            // 
            // AddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1096, 903);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1100, 900);
            this.Name = "AddStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddStock";
            this.Load += new System.EventHandler(this.AddStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox mTxtQuantity;
        private System.Windows.Forms.MaskedTextBox mTxtPurchasePrice;
        private System.Windows.Forms.Button btnAddInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox mTxtBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mTxtBarcodeAdd;
        private System.Windows.Forms.Label label5;
    }
}