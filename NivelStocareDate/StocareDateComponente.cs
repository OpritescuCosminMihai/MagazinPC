using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModeleMagazin;

namespace NivelStocareDate
{
    // Clasa care se ocupă cu salvarea/încărcarea produselor de tip Componentă în/din fișier text
    public class StocareDateComponente
    {
        // Calea către fișierul text unde se salvează componentele
        private string fisierComponente;

        // Constructorul setează calea fișierului și îl creează dacă nu există
        public StocareDateComponente(string componente)
        {
            fisierComponente = componente;
            File.Open(fisierComponente, FileMode.OpenOrCreate).Close(); // se asigură că fișierul există
        }

        // Salvează un produs nou (Componentă) în fișier – adaugă o linie la final
        public void SalveazaProdus(Produs produs)
        {
            string filePath = fisierComponente;

            using (StreamWriter sw = new StreamWriter(filePath, true)) // true = append
            {
                sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
            }

            Console.WriteLine($"{produs.Nume} salvat in {filePath}"); // mesaj de debug
        }

        // Metodă alternativă care returnează toate produsele din fișier (ca listă de obiecte Produs)
        public List<Produs> ObtineProduseDinFisier()
        {
            List<Produs> produse = new List<Produs>();
            string fisier = fisierComponente;

            if (File.Exists(fisier))
            {
                foreach (string linie in File.ReadAllLines(fisier)) // citim fiecare linie
                {
                    if (!string.IsNullOrWhiteSpace(linie))
                    {
                        produse.Add(new Produs(linie)); // transformăm linia în obiect Produs
                    }
                }
            }

            return produse;
        }

        // Încărcăm produsele din fișier – logic identică cu metoda de mai sus
        public List<Produs> IncarcaProduse()
        {
            var lista = new List<Produs>();

            if (File.Exists(fisierComponente))
            {
                foreach (var linie in File.ReadAllLines(fisierComponente))
                {
                    if (!string.IsNullOrWhiteSpace(linie))
                    {
                        lista.Add(new Produs(linie)); // creare produs din linie
                    }
                }
            }

            return lista;
        }

        // Rescrie complet fișierul cu o listă de produse (de obicei după ștergere/editare)
        public void RescrieFisier(List<Produs> produse)
        {
            using (StreamWriter sw = new StreamWriter(fisierComponente, false)) // false = suprascriere
            {
                foreach (var produs in produse)
                {
                    sw.WriteLine($"{produs.ID},{produs.Nume},{produs.Pret},{produs.Stoc},{produs.Categorie},{produs.furnizor.Nume},{produs.furnizor.Contact}");
                }
            }
        }
    }
}
