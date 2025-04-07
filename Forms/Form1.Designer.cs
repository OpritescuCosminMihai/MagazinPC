namespace Forms
{
    partial class Form1
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
            this.txtNumeProdus = new System.Windows.Forms.TextBox();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.txtStoc = new System.Windows.Forms.TextBox();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.txtNumeFurnizor = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnCauta = new System.Windows.Forms.Button();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.btnIncarca = new System.Windows.Forms.Button();
            this.txtNumeSterge = new System.Windows.Forms.TextBox();
            this.txtNumeCauta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumeProdus
            // 
            this.txtNumeProdus.Location = new System.Drawing.Point(13, 13);
            this.txtNumeProdus.Name = "txtNumeProdus";
            this.txtNumeProdus.Size = new System.Drawing.Size(185, 26);
            this.txtNumeProdus.TabIndex = 0;
            this.txtNumeProdus.Text = "Nume Produs";
            this.txtNumeProdus.TextChanged += new System.EventHandler(this.txtNumeProdus_TextChanged);
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(13, 54);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(185, 26);
            this.txtPret.TabIndex = 1;
            this.txtPret.Text = "Pret Produs";
            this.txtPret.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtStoc
            // 
            this.txtStoc.Location = new System.Drawing.Point(13, 97);
            this.txtStoc.Name = "txtStoc";
            this.txtStoc.Size = new System.Drawing.Size(185, 26);
            this.txtStoc.TabIndex = 2;
            this.txtStoc.Text = "Stoc Produs";
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Location = new System.Drawing.Point(12, 142);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(186, 28);
            this.cmbCategorie.TabIndex = 3;
            this.cmbCategorie.Text = "Categorie Produs";
            // 
            // txtNumeFurnizor
            // 
            this.txtNumeFurnizor.Location = new System.Drawing.Point(13, 190);
            this.txtNumeFurnizor.Name = "txtNumeFurnizor";
            this.txtNumeFurnizor.Size = new System.Drawing.Size(185, 26);
            this.txtNumeFurnizor.TabIndex = 4;
            this.txtNumeFurnizor.Text = "Nume Furnizor";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(12, 238);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(186, 26);
            this.txtContact.TabIndex = 5;
            this.txtContact.Text = "Contact";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(236, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(755, 252);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnAdauga
            // 
            this.btnAdauga.Location = new System.Drawing.Point(12, 273);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(146, 42);
            this.btnAdauga.TabIndex = 7;
            this.btnAdauga.Text = "Adauga Produs";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.Location = new System.Drawing.Point(204, 438);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(146, 42);
            this.btnSterge.TabIndex = 8;
            this.btnSterge.Text = "Sterge Produs";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnCauta
            // 
            this.btnCauta.Location = new System.Drawing.Point(204, 390);
            this.btnCauta.Name = "btnCauta";
            this.btnCauta.Size = new System.Drawing.Size(146, 42);
            this.btnCauta.TabIndex = 9;
            this.btnCauta.Text = "Cauta Produs";
            this.btnCauta.UseVisualStyleBackColor = true;
            this.btnCauta.Click += new System.EventHandler(this.btnCauta_Click);
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(12, 321);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(146, 42);
            this.btnSalveaza.TabIndex = 10;
            this.btnSalveaza.Text = "Salveaza Produs";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // btnIncarca
            // 
            this.btnIncarca.Location = new System.Drawing.Point(487, 301);
            this.btnIncarca.Name = "btnIncarca";
            this.btnIncarca.Size = new System.Drawing.Size(146, 42);
            this.btnIncarca.TabIndex = 11;
            this.btnIncarca.Text = "Incarca produse";
            this.btnIncarca.UseVisualStyleBackColor = true;
            this.btnIncarca.Click += new System.EventHandler(this.btnIncarca_Click);
            // 
            // txtNumeSterge
            // 
            this.txtNumeSterge.Location = new System.Drawing.Point(12, 446);
            this.txtNumeSterge.Name = "txtNumeSterge";
            this.txtNumeSterge.Size = new System.Drawing.Size(186, 26);
            this.txtNumeSterge.TabIndex = 12;
            this.txtNumeSterge.Text = "Nume Produs de Sters";
            // 
            // txtNumeCauta
            // 
            this.txtNumeCauta.Location = new System.Drawing.Point(13, 398);
            this.txtNumeCauta.Name = "txtNumeCauta";
            this.txtNumeCauta.Size = new System.Drawing.Size(186, 26);
            this.txtNumeCauta.TabIndex = 13;
            this.txtNumeCauta.Text = "Nume Produs de Cautat";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1003, 928);
            this.Controls.Add(this.txtNumeCauta);
            this.Controls.Add(this.txtNumeSterge);
            this.Controls.Add(this.btnIncarca);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.btnCauta);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtNumeFurnizor);
            this.Controls.Add(this.cmbCategorie);
            this.Controls.Add(this.txtStoc);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.txtNumeProdus);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumeProdus;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.TextBox txtStoc;
        private System.Windows.Forms.ComboBox cmbCategorie;
        private System.Windows.Forms.TextBox txtNumeFurnizor;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnCauta;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Button btnIncarca;
        private System.Windows.Forms.TextBox txtNumeSterge;
        private System.Windows.Forms.TextBox txtNumeCauta;
    }
}

