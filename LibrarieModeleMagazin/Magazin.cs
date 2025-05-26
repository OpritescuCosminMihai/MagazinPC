using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarieModeleMagazin
{
    // Clasa care gestionează toate produsele din aplicație (un fel de "bază de date" în memorie)
    public class Magazin
    {
        // Lista care conține toate produsele din aplicație
        public List<Produs> Produse { get; private set; } = new List<Produs>();

        // Adaugă un produs în lista Produse
        public void AdaugaProdus(Produs produs)
        {
            Produse.Add(produs);
        }

        // Șterge un produs din listă după numele lui
        public void StergeProdus(string numeProdus)
        {
            // Caută primul produs care are numele dat (ignora majuscule/minuscule)
            Produs produs = Produse.FirstOrDefault(p => p.Nume.Equals(numeProdus, StringComparison.OrdinalIgnoreCase));

            if (produs != null)
            {
                Produse.Remove(produs); // dacă a fost găsit, îl elimină
                Console.WriteLine($"{numeProdus} a fost sters.");
            }
            else
            {
                Console.WriteLine("Produsul nu exista.");
            }
        }

        // Încarcă o listă de produse dintr-o sursă externă (ex: fișier)
        public void IncarcareDinFisier(List<Produs> ProduseDinFisier)
        {
            foreach (Produs p in ProduseDinFisier)
            {
                Produse.Add(p); // adaugă fiecare produs în lista internă
            }
        }

        // Afișează toate produsele sub formă de array de string-uri (util pentru interfață console)
        public string[] AfiseazaProduse()
        {
            string[] produse = new string[Produse.Count];

            if (Produse.Count == 0)
            {
                Console.WriteLine("Nu exista produse.");
            }
            else
            {
                foreach (Produs p in Produse)
                {
                    produse.Aggregate(p.AfiseazaDetalii(), (current, produs) => current + "\n" + produs);
                }
            }

            return produse;
        }

        // Caută un produs după nume și returnează detaliile lui
        public string CautaProdus(string numeProdus)
        {
            // Caută produsul după nume (fără diferență între majuscule/minuscule)
            Produs produs = Produse.FirstOrDefault(p => p.Nume.Equals(numeProdus, StringComparison.OrdinalIgnoreCase));

            if (produs != null)
                return produs.AfiseazaDetalii(); // returnează detaliile dacă l-a găsit
            else
                return "Produsul nu exista."; // mesaj dacă nu există
        }
    }
}
