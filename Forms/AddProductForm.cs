using LibrarieModeleMagazin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    public class AddProductForm : Form
    {
        public Produs ProdusNou { get; private set; }
        private Produs produsDeEditat; // păstrăm produsul original pentru editare

        private TextBox txtName, txtPrice, txtStock;
        private ComboBox cmbCategory;
        private TextBox txtFurnizorNume, txtFurnizorContact;
        private Button btnSave;
        private ErrorProvider errorProvider;

        public AddProductForm()
        {
            SetupForm();
        }

        public AddProductForm(Produs produsExist)
        {
            produsDeEditat = produsExist;
            SetupForm();
            PrecompleteazaDate();
        }
        private void PrecompleteazaDate()
        {
            txtName.Text = produsDeEditat.Nume;
            txtPrice.Text = produsDeEditat.Pret.ToString();
            txtStock.Text = produsDeEditat.Stoc.ToString();
            cmbCategory.SelectedItem = produsDeEditat.Categorie;
            txtFurnizorNume.Text = produsDeEditat.furnizor.Nume;
            txtFurnizorContact.Text = produsDeEditat.furnizor.Contact;
        }

        private void SetupForm()
        {
            this.Text = "Adaugă Produs";
            this.Size = new Size(450, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.Dock = DockStyle.Fill;
            tlp.ColumnCount = 2;
            tlp.RowCount = 7;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            for (int i = 0; i < 7; i++)
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, i == 6 ? 50F : 40F));

            // Nume
            Label lblName = new Label() { Text = "Nume Produs:", Anchor = AnchorStyles.Right, AutoSize = true };
            txtName = new TextBox() { Anchor = AnchorStyles.Left, Width = 200 };

            // Pret
            Label lblPrice = new Label() { Text = "Preț:", Anchor = AnchorStyles.Right, AutoSize = true };
            txtPrice = new TextBox() { Anchor = AnchorStyles.Left, Width = 200 };

            // Stoc
            Label lblStock = new Label() { Text = "Stoc:", Anchor = AnchorStyles.Right, AutoSize = true };
            txtStock = new TextBox() { Anchor = AnchorStyles.Left, Width = 200 };

            // Categorie
            Label lblCategory = new Label() { Text = "Categorie:", Anchor = AnchorStyles.Right, AutoSize = true };
            cmbCategory = new ComboBox() { Anchor = AnchorStyles.Left, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCategory.DataSource = Enum.GetValues(typeof(tip_produs));

            // Furnizor nume
            Label lblFurnizorNume = new Label() { Text = "Nume Furnizor:", Anchor = AnchorStyles.Right, AutoSize = true };
            txtFurnizorNume = new TextBox() { Anchor = AnchorStyles.Left, Width = 200 };

            // Furnizor contact
            Label lblFurnizorContact = new Label() { Text = "Contact Furnizor:", Anchor = AnchorStyles.Right, AutoSize = true };
            txtFurnizorContact = new TextBox() { Anchor = AnchorStyles.Left, Width = 200 };

            // Buton Salvează
            btnSave = new Button() { Text = "Salvează", Anchor = AnchorStyles.None, Width = 100, Height = 30 };
            btnSave.Click += BtnSave_Click;

            // Adaugă în layout
            tlp.Controls.Add(lblName, 0, 0);
            tlp.Controls.Add(txtName, 1, 0);
            tlp.Controls.Add(lblPrice, 0, 1);
            tlp.Controls.Add(txtPrice, 1, 1);
            tlp.Controls.Add(lblStock, 0, 2);
            tlp.Controls.Add(txtStock, 1, 2);
            tlp.Controls.Add(lblCategory, 0, 3);
            tlp.Controls.Add(cmbCategory, 1, 3);
            tlp.Controls.Add(lblFurnizorNume, 0, 4);
            tlp.Controls.Add(txtFurnizorNume, 1, 4);
            tlp.Controls.Add(lblFurnizorContact, 0, 5);
            tlp.Controls.Add(txtFurnizorContact, 1, 5);
            tlp.Controls.Add(btnSave, 1, 6);

            this.Controls.Add(tlp);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Introduceți numele produsului!");
                isValid = false;
            }

            if (!float.TryParse(txtPrice.Text, out float pret) || pret <= 0)
            {
                errorProvider.SetError(txtPrice, "Preț invalid!");
                isValid = false;
            }

            if (!int.TryParse(txtStock.Text, out int stoc) || stoc < 0)
            {
                errorProvider.SetError(txtStock, "Stoc invalid!");
                isValid = false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                errorProvider.SetError(cmbCategory, "Selectați o categorie!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtFurnizorNume.Text))
            {
                errorProvider.SetError(txtFurnizorNume, "Introduceți numele furnizorului!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtFurnizorContact.Text))
            {
                errorProvider.SetError(txtFurnizorContact, "Introduceți contactul furnizorului!");
                isValid = false;
            }

            if (!isValid)
                return;

            try
            {
                var furnizor = new Furnizor(txtFurnizorNume.Text, txtFurnizorContact.Text);
                var categorie = (tip_produs)cmbCategory.SelectedItem;

                if (produsDeEditat != null)
                {
                    // Edităm produsul existent
                    produsDeEditat.Nume = txtName.Text;
                    produsDeEditat.Pret = pret;
                    produsDeEditat.Stoc = stoc;
                    produsDeEditat.Categorie = categorie;
                    produsDeEditat.furnizor = furnizor;

                    ProdusNou = produsDeEditat;
                }
                else
                {
                    // Creăm produs nou
                    Produs produs = new Produs(txtName.Text, pret, stoc, categorie, furnizor);
                    ProdusNou = produs;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Datele introduse nu sunt valide: " + ex.Message, "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
