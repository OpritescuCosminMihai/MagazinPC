using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModeleMagazin;

namespace NivelStocareDate
{
    // Clasa care se ocupă cu salvarea/încărcarea produselor de tip Periferic
    public class StocareDatePeriferice
    {
        // Calea către fișierul text în care sunt salvate perifericele
        private string fisierPeriferice;

        // Constructorul setează calea fișierului și îl creează dacă nu există deja
        public StocareDatePeriferice(string periferice)
        {
            fisierPeriferice = periferice;
            File.Open(fisierPeriferice, FileMode.OpenOrCreate).Close(); // se asigură că fișierul există
        }

        // Adaugă un nou produs de tip periferic la finalul fișierului
        public void SalveazaProdus(Produs produs)
        {
            string filePath = fisierPeriferice;

            using (StreamWriter sw = new StreamWriter(filePath, true)) // true = adaugă la final
            {
                sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
            }

            Console.WriteLine($"{produs.Nume} salvat in {filePath}");
        }

        // Obține produsele din fișier, linie cu linie, și le transformă în obiecte Produs
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
                        produse.Add(new Produs(linie)); // fiecare linie devine un produs
                    }
                }
            }

            return produse;
        }

        // Încărcare produse – identic ca mai sus, poate fi folosită interschimbabil
        public List<Produs> IncarcaProduse()
        {
            var lista = new List<Produs>();

            if (File.Exists(fisierPeriferice))
            {
                foreach (var linie in File.ReadAllLines(fisierPeriferice))
                {
                    if (!string.IsNullOrWhiteSpace(linie))
                    {
                        lista.Add(new Produs(linie)); // conversie linie → obiect
                    }
                }
            }

            return lista;
        }

        // Suprascrie complet fișierul cu lista actualizată (după editare sau ștergere)
        public void RescrieFisier(List<Produs> produse)
        {
            using (StreamWriter sw = new StreamWriter(fisierPeriferice, false)) // false = rescrie tot fișierul
            {
                foreach (var produs in produse)
                {
                    sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
                }
            }
        }
    }
}
