using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarieModeleMagazin
{
    public class Magazin
    {
        public List<Produs> Produse { get; private set; } = new List<Produs>();

        public void AdaugaProdus(Produs produs)
        {
            Produse.Add(produs);
        }
        public void StergeProdus(string numeProdus)
        {
            Produs produs = Produse.FirstOrDefault(p => p.Nume.Equals(numeProdus, StringComparison.OrdinalIgnoreCase));
            if (produs != null)
            {
                Produse.Remove(produs);
                Console.WriteLine($"{numeProdus} a fost sters.");
            }
            else
            {
                Console.WriteLine("Produsul nu exista.");
            }
        }
        public void IncarcareDinFisier(List<Produs> ProduseDinFisier)
        {
            foreach (Produs p in ProduseDinFisier)
            {
                Produse.Add(p);
            }
        }
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
        public string CautaProdus(string numeProdus)
        {
            Produs produs = Produse.FirstOrDefault(p => p.Nume.Equals(numeProdus, StringComparison.OrdinalIgnoreCase));
            if (produs != null)
                return produs.AfiseazaDetalii();
            else
                return "Produsul nu exista.";
        }
    }
}
