using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModeleMagazin;

namespace NivelStocareDate
{
    public class StocareDate
    {
        private string fisierComponente;
        private string fisierPeriferice;

        public StocareDate(string componente, string periferice)
        {
            fisierComponente = componente;
            fisierPeriferice = periferice;
            File.Open(fisierComponente, FileMode.OpenOrCreate).Close();
            File.Open(fisierPeriferice, FileMode.OpenOrCreate).Close();
        }

        public void SalveazaProdus(Produs produs)
        {
            string filePath = produs.Categorie == tip_produs.Componenta ? fisierComponente : fisierPeriferice;
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie}");
            }
            Console.WriteLine($"{produs.Nume} salvat in {filePath}");
        }

        public void AfiseazaProduseDinFisier()
        {
            string[] fisiere = { fisierComponente, fisierPeriferice };
            foreach (string fisier in fisiere)
            {
                Console.WriteLine($"\n{fisier}:");
                if (File.Exists(fisier))
                {
                    Console.WriteLine(File.ReadAllText(fisier));
                }
                else
                {
                    Console.WriteLine("Nu exista produse.");
                }
            }
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
    }
}
