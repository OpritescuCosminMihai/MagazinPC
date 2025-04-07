using LibrarieModeleMagazin;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1: Form
    {
        private Magazin magazin;
        private StocareDateComponente stocareComponente;
        private StocareDatePeriferice stocarePeriferice;

        public Form1()
        {
            InitializeComponent();
            magazin = new Magazin();
            stocareComponente = new StocareDateComponente("StocComponente.txt");
            stocarePeriferice = new StocareDatePeriferice("StocPeriferice.txt");

            // Populăm ComboBox-ul cu valorile enum tip_produs
            cmbCategorie.DataSource = Enum.GetValues(typeof(tip_produs));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCategorie.DataSource = Enum.GetValues(typeof(tip_produs));
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                string numeProdus = txtNumeProdus.Text;
                float pret = float.Parse(txtPret.Text);
                int stoc = int.Parse(txtStoc.Text);
                tip_produs categorie = (tip_produs)cmbCategorie.SelectedItem;
                string numeFurnizor = txtNumeFurnizor.Text;
                string contactFurnizor = txtContact.Text;

                Produs produs = new Produs(numeProdus, pret, stoc, categorie, new Furnizor(numeFurnizor, contactFurnizor));
                magazin.AdaugaProdus(produs);

                UpdateGrid();

                MessageBox.Show("Produs adăugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            try
            {
                string numeSterge = txtNumeSterge.Text;
                magazin.StergeProdus(numeSterge);
                UpdateGrid();
                MessageBox.Show("Produs șters cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            try
            {
                string numeCauta = txtNumeCauta.Text;
                var produsGasit = magazin.Produse.FirstOrDefault(p => p.Nume.Equals(numeCauta, StringComparison.OrdinalIgnoreCase));
                if (produsGasit != null)
                    MessageBox.Show(produsGasit.AfiseazaDetalii());
                else
                    MessageBox.Show("Produsul nu a fost găsit!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            try
            {
                if (magazin.Produse.Count > 0)
                {
                    Produs ultimulProdus = magazin.Produse.Last();
                    if (ultimulProdus.Categorie == tip_produs.Componenta)
                        stocareComponente.SalveazaProdus(ultimulProdus);
                    else if (ultimulProdus.Categorie == tip_produs.Periferic)
                        stocarePeriferice.SalveazaProdus(ultimulProdus);

                    MessageBox.Show("Produs salvat în fișier.");
                }
                else
                {
                    MessageBox.Show("Nu există produse de salvat!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void btnIncarca_Click(object sender, EventArgs e)
        {
            try
            {
                magazin.Produse.Clear();
                magazin.IncarcareDinFisier(stocareComponente.IncarcaProduse());
                magazin.IncarcareDinFisier(stocarePeriferice.IncarcaProduse());
                UpdateGrid();
                MessageBox.Show("Produsele au fost încărcate din fișiere.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }
        private void UpdateGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = magazin.Produse;
        }

        private void txtNumeProdus_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
