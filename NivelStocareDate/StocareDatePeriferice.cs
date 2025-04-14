using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModeleMagazin;

namespace NivelStocareDate
{
    public class StocareDatePeriferice
    {
        private string fisierPeriferice;

        public StocareDatePeriferice(string periferice)
        {
            fisierPeriferice = periferice;
            File.Open(fisierPeriferice, FileMode.OpenOrCreate).Close();
        }

        public void SalveazaProdus(Produs produs)
        {
            string filePath = fisierPeriferice;
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
            }
            Console.WriteLine($"{produs.Nume} salvat in {filePath}");
        }

        public List<Produs> ObtineProduseDinFisier()
        {
            List<Produs> produse = new List<Produs>();
            string fisier = fisierPeriferice;
            if (File.Exists(fisier))
            {
                foreach (string linie in File.ReadAllLines(fisier))
                {
                    if (!string.IsNullOrWhiteSpace(linie))
                    {
                        produse.Add(new Produs(linie));
                    }
                }
            }
            return produse;
        }
        public List<Produs> IncarcaProduse()
        {
            var lista = new List<Produs>();

            if (File.Exists(fisierPeriferice))
            {
                foreach (var linie in File.ReadAllLines(fisierPeriferice))
                {
                    if (!string.IsNullOrWhiteSpace(linie))
                    {
                        lista.Add(new Produs(linie));
                    }
                }
            }
            return lista;
        }
        public void RescrieFisier(List<Produs> produse)
        {
            using (StreamWriter sw = new StreamWriter(fisierPeriferice, false)) // sau fisierPeriferice
            {
                foreach (var produs in produse)
                {
                    sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
                }
            }
        }
    }
}
