using LibrarieModeleMagazin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    // Form pentru adăugare sau editare produs
    public class AddProductForm : Form
    {
        // Produsul completat sau editat de utilizator
        public Produs ProdusNou { get; private set; }

        // Referință la produsul care se editează (dacă este cazul)
        private Produs produsDeEditat; // păstrăm produsul original pentru editare

        // Controale pentru input
        private TextBox txtName, txtPrice, txtStock;
        private TextBox txtFurnizorNume, txtFurnizorContact;
        private Button btnSave;
        private GroupBox groupBoxTipProdus;
        private RadioButton radioPeriferic;
        private RadioButton radioComponenta;
        private ErrorProvider errorProvider;
        private CheckBox chkActiv;

        // Constructor pentru adăugare produs nou
        public AddProductForm()
        {
            SetupForm();
        }

        // Constructor pentru editare produs existent
        public AddProductForm(Produs produsExist)
        {
            produsDeEditat = produsExist;
            SetupForm();
            PrecompleteazaDate();
        }

        // Completează câmpurile formularului cu valorile produsului de editat
        private void PrecompleteazaDate()
        {
            txtName.Text = produsDeEditat.Nume;
            txtPrice.Text = produsDeEditat.Pret.ToString();
            txtStock.Text = produsDeEditat.Stoc.ToString();
            radioComponenta.Checked = produsDeEditat.Categorie == tip_produs.Componenta;
            radioPeriferic.Checked = produsDeEditat.Categorie == tip_produs.Periferic;
            txtFurnizorNume.Text = produsDeEditat.furnizor.Nume;
            txtFurnizorContact.Text = produsDeEditat.furnizor.Contact;
            chkActiv.Checked = produsDeEditat.Activ;
        }

        // Creează interfața grafică și configurează controalele
        private void SetupForm()
        {
            // Culori și fonturi pentru temă dark
            var darkBg = Color.FromArgb(30, 30, 30);
            var darkPanel = Color.FromArgb(45, 45, 48);
            var lightText = Color.WhiteSmoke;
            var defaultFont = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Setări generale pentru fereastră
            this.Text = "Adaugă Produs";
            this.Size = new Size(500, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = darkBg;
            this.ForeColor = lightText;
            this.Font = defaultFont;

            // Inițializare validări
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Grupare radio buttons pentru tip produs
            groupBoxTipProdus = new GroupBox
            {
                Text = "Tip produs",
                AutoSize = true,
                BackColor = darkPanel,
                ForeColor = lightText,
                Font = defaultFont,
                Padding = new Padding(10),
                Margin = new Padding(5)
            };

            // Radio button Componentă
            radioComponenta = new RadioButton
            {
                Text = "Componentă",
                Checked = true,
                AutoSize = true,
                Location = new Point(15, 28),
                BackColor = Color.Transparent,
                ForeColor = lightText,
                Font = defaultFont
            };

            // Radio button Periferic
            radioPeriferic = new RadioButton
            {
                Text = "Periferic",
                AutoSize = true,
                Location = new Point(140, 28),
                BackColor = Color.Transparent,
                ForeColor = lightText,
                Font = defaultFont
            };
            groupBoxTipProdus.Controls.Add(radioComponenta);
            groupBoxTipProdus.Controls.Add(radioPeriferic);

            // Checkbox pentru activare produs
            chkActiv = new CheckBox
            {
                Text = "Produs activ",
                Checked = true,             
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(3, 8, 3, 3),
                ForeColor = lightText,        
                Font = defaultFont
            };

            // Grid pentru aranjarea elementelor
            TableLayoutPanel tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 8,
                BackColor = darkBg,
                Padding = new Padding(15),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
            };
            tlp.RowStyles.Clear();
            // Padding pentru margini
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            // Spacing între rânduri
            for (int i = 0; i < 7; i++)
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            // Ultimul rând mai mare
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            // Ultimul rând pentru butoane
            tlp.RowStyles[3] = new RowStyle(SizeType.Absolute, 110F);

            // Funcție pentru etichete
            Func<string, Label> makeLabel = txt => new Label
            {
                Text = txt,
                Anchor = AnchorStyles.Right,
                AutoSize = true,
                ForeColor = lightText,
                Font = defaultFont,
                Margin = new Padding(3, 10, 3, 3)
            };

            // Nume produs
            Label lblName = makeLabel("Nume Produs:");
            txtName = new TextBox
            {
                Anchor = AnchorStyles.Left,
                Width = 220,
                BackColor = darkPanel,
                ForeColor = lightText,
                Font = defaultFont,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 8, 3, 3)
            };

            // Preț
            Label lblPrice = makeLabel("Preț:");
            txtPrice = new TextBox
            {
                Anchor = AnchorStyles.Left,
                Width = 220,
                BackColor = darkPanel,
                ForeColor = lightText,
                Font = defaultFont,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 8, 3, 3)
            };

            // Stoc
            Label lblStock = makeLabel("Stoc:");
            txtStock = new TextBox
            {
                Anchor = AnchorStyles.Left,
                Width = 220,
                BackColor = darkPanel,
                ForeColor = lightText,
                Font = defaultFont,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 8, 3, 3)
            };

            // Adăugăm controalele în grid
            tlp.Controls.Add(lblName, 0, 0);
            tlp.Controls.Add(txtName, 1, 0);
            tlp.Controls.Add(lblPrice, 0, 1);
            tlp.Controls.Add(txtPrice, 1, 1);
            tlp.Controls.Add(lblStock, 0, 2);
            tlp.Controls.Add(txtStock, 1, 2);

            // Tip produs
            var lblTip = makeLabel("Tip produs:");
            tlp.Controls.Add(lblTip, 0, 3);
            tlp.Controls.Add(groupBoxTipProdus, 1, 3);

            // Furnizor
            Label lblFurnNume = makeLabel("Nume Furnizor:");
            txtFurnizorNume = new TextBox
            {
                Anchor = AnchorStyles.Left,
                Width = 220,
                BackColor = darkPanel,
                ForeColor = lightText,
                Font = defaultFont,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 8, 3, 3)
            };
            Label lblFurnContact = makeLabel("Contact Furnizor:");
            txtFurnizorContact = new TextBox
            {
                Anchor = AnchorStyles.Left,
                Width = 220,
                BackColor = darkPanel,
                ForeColor = lightText,
                Font = defaultFont,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3, 8, 3, 3)
            };
            tlp.Controls.Add(chkActiv, 1, 4);
            tlp.Controls.Add(lblFurnNume, 0, 5);
            tlp.Controls.Add(txtFurnizorNume, 1, 5);
            tlp.Controls.Add(lblFurnContact, 0, 6);
            tlp.Controls.Add(txtFurnizorContact, 1, 6);

            // Butoane Salvare / Anulare
            var pnlButtons = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = new Padding(3, 10, 3, 3)
            };
            btnSave = new Button
            {
                Text = "Salvează",
                Width = 100,
                Height = 30,
                Font = defaultFont,
                BackColor = Color.FromArgb(28, 151, 234),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(5, 0, 0, 0)
            };
            var btnCancel = new Button
            {
                Text = "Anulează",
                Width = 100,
                Height = 30,
                Font = defaultFont,
                BackColor = Color.FromArgb(100, 100, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(5, 0, 0, 0)
            };
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);

            tlp.Controls.Add(pnlButtons, 1, 7);

            // Adaugă totul pe form
            this.Controls.Add(tlp);
        }

        // Acțiune la apăsarea butonului "Salvează"
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Curățăm erorile anterioare
            errorProvider.Clear();
            bool isValid = true;

            // Validare câmpuri
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Introduceți numele produsului!");
                isValid = false;
            }

            if (!float.TryParse(txtPrice.Text, out float pret) || pret < 0)
            {
                errorProvider.SetError(txtPrice, "Preț invalid!");
                isValid = false;
            }

            if (!int.TryParse(txtStock.Text, out int stoc) || stoc < 0)
            {
                errorProvider.SetError(txtStock, "Stoc invalid!");
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

            // Dacă datele nu sunt valide, nu continuăm
            if (!isValid)
                return;

            try
            {
                // Creează obiectul Furnizor
                var furnizor = new Furnizor(txtFurnizorNume.Text, txtFurnizorContact.Text);

                // Verifică tipul de produs selectat
                var categorie = radioComponenta.Checked
                ? tip_produs.Componenta
                : tip_produs.Periferic;
                bool activ = chkActiv.Checked;


                if (produsDeEditat != null)
                {
                    // Edităm produsul existent
                    produsDeEditat.Nume = txtName.Text;
                    produsDeEditat.Pret = pret;
                    produsDeEditat.Stoc = stoc;
                    produsDeEditat.furnizor = furnizor;
                    produsDeEditat.Categorie = categorie;
                    produsDeEditat.Activ = activ;

                    ProdusNou = produsDeEditat;
                }
                else
                {
                    // Creăm produs nou
                    var produs = new Produs(txtName.Text, pret, stoc, categorie, furnizor)
                    {
                        Activ = activ
                    };
                    ProdusNou = produs;
                }

                // Închidem form-ul cu rezultat OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                // Afișăm eroare dacă produsul este invalid
                MessageBox.Show("Datele introduse nu sunt valide: " + ex.Message, "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
