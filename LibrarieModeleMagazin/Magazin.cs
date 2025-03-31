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
        public void AfiseazaProduse()
        {
            if (Produse.Count == 0)
            {
                Console.WriteLine("Nu exista produse.");
            }
            else
            {
                foreach (Produs p in Produse)
                {
                    Console.WriteLine(p.AfiseazaDetalii());
                }
            }
        }
        public void CautaProdus(string numeProdus)
        {
            Produs produs = Produse.FirstOrDefault(p => p.Nume.Equals(numeProdus, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(produs != null ? produs.AfiseazaDetalii() : "Produs inexistent.");
        }
    }
}
