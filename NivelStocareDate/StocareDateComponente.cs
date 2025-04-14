using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModeleMagazin;

namespace NivelStocareDate
{
    public class StocareDateComponente
    {
        private string fisierComponente;

        public StocareDateComponente(string componente)
        {
            fisierComponente = componente;
            File.Open(fisierComponente, FileMode.OpenOrCreate).Close();
        }

        public void SalveazaProdus(Produs produs)
        {
            string filePath = fisierComponente;
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
            }
            Console.WriteLine($"{produs.Nume} salvat in {filePath}");
        }

        public List<Produs> ObtineProduseDinFisier()
        {
            List<Produs> produse = new List<Produs>();
            string fisier = fisierComponente;

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

            if (File.Exists(fisierComponente))
            {
                foreach (var linie in File.ReadAllLines(fisierComponente))
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
            using (StreamWriter sw = new StreamWriter(fisierComponente, false)) // sau fisierPeriferice
            {
                foreach (var produs in produse)
                {
                    sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
                }
            }
        }
    }
}
