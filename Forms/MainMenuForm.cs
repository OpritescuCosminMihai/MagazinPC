using LibrarieModeleMagazin;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Forms
{
    // Clasa MainMenuForm reprezintă fereastra principală a aplicației
    public partial class MainMenuForm : Form
    {
        // Panou care va afișa cardurile produselor
        private FlowLayoutPanel flowPanelProducts;

        // Câmp pentru căutarea produselor după nume
        private TextBox txtSearch;

        // Buton pentru adăugarea unui produs nou
        private Button btnAddProduct;

        // Panou care conține bara de căutare și butonul de adăugare
        private Panel panelSearchArea;

        // Instanță pentru salvarea și încărcarea componentelor
        private StocareDateComponente stocareComponente;

        // Instanță pentru salvarea și încărcarea perifericelor
        private StocareDatePeriferice stocarePeriferice;

        // Obiectul care conține toate produsele din aplicație
        private Magazin magazin = new Magazin();

        public MainMenuForm()
        {
            InitializeComponent();

            // Menține meniul vizual sub alte controale
            menuStrip1.SendToBack();

            // Setează dimensiunea ferestrei principale
            this.Size = new Size(1280, 800);

            // Inițializează salvarea în fișiere
            stocareComponente = new StocareDateComponente("StocComponente.txt");
            stocarePeriferice = new StocareDatePeriferice("StocPeriferice.txt");

            // Inițializează meniul și panoul de start
            SetupMenuStrip();
            SetupHomePanel();
        }

        // Configurează stilul și evenimentele pentru meniul de sus
        private void SetupMenuStrip()
        {
            // Stil vizual pentru meniu
            menuStrip1.BackColor = Color.Black;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            menuStrip1.Height = 50;
            menuStrip1.Dock = DockStyle.Top;

            // Aplică stilul pe fiecare item
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
                item.BackColor = Color.Black;
            }

            // Evenimente pentru click pe butoanele meniului
            homeToolStripMenuItem.Click += menuItemHome_Click;
            productsToolStripMenuItem.Click += menuItemProducts_Click;
            editToolStripMenuItem.Click += (sender, e) => MessageBox.Show("Ai apăsat Edit!");
            aboutToolStripMenuItem.Click += (sender, e) => MessageBox.Show("OverKhlocked by Cosmin", "About");
        }

        // Afișează mesajul de bun venit + logo-ul în pagina Home
        private void SetupHomePanel()
        {
            panelHome.Controls.Clear();
            panelHome.Dock = DockStyle.Fill;
            panelHome.BackColor = Color.Black;

            Label lblWelcome = new Label
            {
                Text = "Bine ai venit la OverKhlocked!",
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };
            panelHome.Controls.Add(lblWelcome);

            Label lblDescription = new Label
            {
                Text = "Destinația ta pentru componente PC și periferice.",
                Font = new Font("Segoe UI", 18, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };
            panelHome.Controls.Add(lblDescription);

            PictureBox picLogo = new PictureBox
            {
                Size = new Size(450, 450),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile("D:\\C#\\MagazinPC_Proiect\\Logo\\MainMenuLogo.png")
            };
            int x = (panelHome.Width - picLogo.Width) / 2;
            int y = lblWelcome.Height + lblDescription.Height + 20;
            picLogo.Location = new Point(x, y);
            panelHome.Controls.Add(picLogo);

            panelHome.BringToFront();
        }

        // Configurează pagina Products (căutare + listă produse)
        private void SetupProductsPanel()
        {
            // Dacă deja e configurat, doar îl reafișăm
            if (flowPanelProducts != null)
            {
                panelSearchArea.Visible = true;
                flowPanelProducts.Visible = true;
                                           // Asigurăm că meniul este vizual deasupra oricărui panel
                menuStrip1.SendToBack(); // trimite meniul dedesubt
                panelSearchArea.BringToFront(); // ca să fie sub meniu, dar peste produse
                flowPanelProducts.BringToFront();
                return;
            }

            // Creează bara de sus pentru căutare și adăugare
            panelSearchArea = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.Black
            };

            // TextBox pentru căutare
            txtSearch = new TextBox
            {
                Text = "Caută produs...",
                Font = new Font("Segoe UI", 10),
                Width = 300,
                Location = new Point(10, 15),
                ForeColor = Color.Gray
            };

            txtSearch.GotFocus += (s, e) =>
            {
                if (txtSearch.Text == "Caută produs...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Caută produs...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            txtSearch.TextChanged += TxtSearch_TextChanged;
            panelSearchArea.Controls.Add(txtSearch);

            // Buton Adaugă produs
            btnAddProduct = CreeazaButonAdaugaProdus();
            btnAddProduct.Location = new Point(10, 55);
            panelSearchArea.Controls.Add(btnAddProduct);

            // Creează containerul vizual pentru produsele afișate
            flowPanelProducts = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            this.Controls.Add(flowPanelProducts);     // conținut principal
            this.Controls.Add(panelSearchArea);       // bara de căutare + buton

            // Asigurăm ordinea vizuală
            menuStrip1.BringToFront();

            // Încarcă toate produsele din fișiere și le afișează
            var produseComponente = stocareComponente.IncarcaProduse();
            var produsePeriferice = stocarePeriferice.IncarcaProduse();

            foreach (var produs in produseComponente.Concat(produsePeriferice))
            {
                magazin.AdaugaProdus(produs);
                flowPanelProducts.Controls.Add(CreateProductCard(
                    produs.Nume,
                    produs.Pret,
                    produs.Stoc,
                    produs.Categorie.ToString(),
                    produs.furnizor.Nume,
                    produs.furnizor.Contact,
                    produs.ID));
            }
            // Asigurăm că meniul este vizual deasupra oricărui panel
            menuStrip1.SendToBack(); // trimite meniul dedesubt
            panelSearchArea.BringToFront(); // ca să fie sub meniu, dar peste produse
            flowPanelProducts.BringToFront();
        }

        // Creează butonul "Adaugă Produs" și definește acțiunile sale
        private Button CreeazaButonAdaugaProdus()
        {
            Button btnAddProduct = new Button
            {
                Text = "Adaugă Produs",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(200, 40),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Margin = new Padding(10)
            };

            btnAddProduct.Click += (sender, e) =>
            {
                AddProductForm addForm = new AddProductForm();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var produsNou = addForm.ProdusNou;

                    if (!magazin.Produse.Any(p => p.Nume.Equals(produsNou.Nume, StringComparison.OrdinalIgnoreCase)))
                    {
                        magazin.AdaugaProdus(produsNou);
                        flowPanelProducts.Controls.Add(CreateProductCard(
                            produsNou.Nume,
                            produsNou.Pret,
                            produsNou.Stoc,
                            produsNou.Categorie.ToString(),
                            produsNou.furnizor.Nume,
                            produsNou.furnizor.Contact,
                            produsNou.ID));

                        if (produsNou.Categorie == tip_produs.Componenta)
                            stocareComponente.SalveazaProdus(produsNou);
                        else if (produsNou.Categorie == tip_produs.Periferic)
                            stocarePeriferice.SalveazaProdus(produsNou);

                        MessageBox.Show("Produsul a fost adăugat și salvat cu succes!", "Succes",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Un produs cu acest nume există deja!", "Eroare",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            };

            return btnAddProduct;
        }

        // Se execută la modificarea textului de căutare – filtrează cardurile afișate
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor == Color.Gray) return;

            string input = txtSearch.Text.Trim().ToLower();
            string[] cuvinte = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            flowPanelProducts.Controls.Clear();

            var produseFiltrate = magazin.Produse.Where(p =>
            {
                string numeProdus = p.Nume.ToLower();
                return cuvinte.All(cuv => numeProdus.Contains(cuv));
            });

            foreach (var produs in produseFiltrate)
            {
                flowPanelProducts.Controls.Add(CreateProductCard(
                    produs.Nume,
                    produs.Pret,
                    produs.Stoc,
                    produs.Categorie.ToString(),
                    produs.furnizor.Nume,
                    produs.furnizor.Contact,
                    produs.ID));
            }

            txtSearch.Focus();
            txtSearch.SelectionStart = txtSearch.Text.Length;
        }

        // Creează vizual un card pentru un produs (Panel cu toate detaliile + butoane Edit / Șterge)
        private Panel CreateProductCard(string nume, float pret, int stoc, string categorie, string furnizor, string contactFurnizor, Guid id)
        {
            Panel card = new Panel
            {
                Size = new Size(270, 260),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            Label lblName = new Label
            {
                Text = nume,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Size = new Size(250, 30),
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblName);

            Label lblPrice = new Label
            {
                Text = pret.ToString("0.00") + " RON",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Red,
                Size = new Size(250, 20),
                Location = new Point(10, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblPrice);

            Label lblStock = new Label
            {
                Text = $"Stoc: {stoc} | {categorie}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Size = new Size(250, 20),
                Location = new Point(10, 70),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblStock);

            Label lblSupplier = new Label
            {
                Text = "Furnizor: " + furnizor,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.DarkBlue,
                Size = new Size(250, 20),
                Location = new Point(10, 95),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblSupplier);

            Label lblContact = new Label
            {
                Text = "Contact: " + contactFurnizor,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                Size = new Size(250, 20),
                Location = new Point(10, 120),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblContact);

            Button btnEdit = new Button
            {
                Text = "Editează",
                Font = new Font("Segoe UI", 9),
                Size = new Size(90, 25),
                Location = new Point(30, 150)
            };
            btnEdit.Click += (sender, e) =>
            {
                var produsEditat = magazin.Produse.FirstOrDefault(p => p.ID == id);
                if (produsEditat == null)
                {
                    MessageBox.Show("Produsul nu a fost găsit pentru editare.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddProductForm editForm = new AddProductForm(produsEditat);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Actualizare UI pe cardul existent
                    foreach (Control ctrl in card.Controls)
                    {
                        if (ctrl is Label label)
                        {
                            switch (label.Text)
                            {
                                case var _ when label.Text.StartsWith("ID: "):
                                    label.Text = "ID: " + produsEditat.ID.ToString();
                                    break;
                                case var _ when label.Text.StartsWith("Furnizor: "):
                                    label.Text = "Furnizor: " + produsEditat.furnizor.Nume;
                                    break;
                                case var _ when label.Text.StartsWith("Contact: "):
                                    label.Text = "Contact: " + produsEditat.furnizor.Contact;
                                    break;
                                case var _ when label.Font.Style == FontStyle.Bold:
                                    label.Text = produsEditat.Nume;
                                    break;
                                case var _ when label.Text.Contains("RON"):
                                    label.Text = produsEditat.Pret.ToString("0.00") + " RON";
                                    break;
                                case var _ when label.Text.StartsWith("Stoc:"):
                                    label.Text = $"Stoc: {produsEditat.Stoc} | {produsEditat.Categorie}";
                                    break;
                            }
                        }
                    }

                    // Rescriere fișier
                    if (produsEditat.Categorie == tip_produs.Componenta)
                        stocareComponente.RescrieFisier(magazin.Produse.Where(p => p.Categorie == tip_produs.Componenta).ToList());
                    else if (produsEditat.Categorie == tip_produs.Periferic)
                        stocarePeriferice.RescrieFisier(magazin.Produse.Where(p => p.Categorie == tip_produs.Periferic).ToList());

                    MessageBox.Show("Produsul a fost actualizat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            card.Controls.Add(btnEdit);

            Button btnDelete = new Button
            {
                Text = "Șterge",
                Font = new Font("Segoe UI", 9),
                Size = new Size(90, 25),
                Location = new Point(140, 150)
            };
            btnDelete.Click += (sender, e) =>
            {
                DialogResult confirm = MessageBox.Show($"Sigur vrei să ștergi produsul \"{nume}\"?",
                    "Confirmare ștergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // 1. Găsește produsul în listă
                    var produsDeSters = magazin.Produse.FirstOrDefault(p => p.ID == id);
                    if (produsDeSters != null)
                    {
                        // 2. Șterge din listă
                        magazin.Produse.Remove(produsDeSters);

                        // 3. Șterge vizual
                        flowPanelProducts.Controls.Remove(card);

                        // 4. Rescrie fișierul corespunzător
                        if (produsDeSters.Categorie == tip_produs.Componenta)
                            stocareComponente.RescrieFisier(magazin.Produse.Where(p => p.Categorie == tip_produs.Componenta).ToList());
                        else if (produsDeSters.Categorie == tip_produs.Periferic)
                            stocarePeriferice.RescrieFisier(magazin.Produse.Where(p => p.Categorie == tip_produs.Periferic).ToList());

                        MessageBox.Show("Produsul a fost șters cu succes.", "Șters",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };

            card.Controls.Add(btnDelete);

            // ID produs (jos, mic)
            Label lblID = new Label
            {
                Text = "ID: " + id.ToString(),
                Font = new Font("Consolas", 7, FontStyle.Regular),
                ForeColor = Color.DarkGray,
                Size = new Size(250, 20),
                Location = new Point(10, 185),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblID);

            return card;
        }

        // Navigare în meniu – back to Home
        private void menuItemHome_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelHome.BringToFront();

            if (flowPanelProducts != null)
                flowPanelProducts.Visible = false;

            if (panelSearchArea != null)
                panelSearchArea.Visible = false;
        }

        // Navigare în meniu – mergi la Products
        private void menuItemProducts_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            SetupProductsPanel();
            if (flowPanelProducts != null)
            {
                flowPanelProducts.Visible = true;
                flowPanelProducts.BringToFront();
            }
        }
    }
}
