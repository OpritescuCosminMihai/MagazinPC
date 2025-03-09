using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinPC
{
    class Magazin
    {
        private List<Produs> produse = new List<Produs>();

        public void AdaugaProdus(Produs produs)
        {
            produse.Add(produs);
        }

        public bool StergeProdus(string numeProdus)
        {
            Produs produsDeSters = produse.Find(p => p.Nume.Equals(numeProdus, StringComparison.OrdinalIgnoreCase));

            if (produsDeSters != null)
            {
                produse.Remove(produsDeSters);
                return true;
            }
            return false;
        }

        public List<Produs> AfiseazaProduse()
        {
            return produse;
        }

        public Produs CautaProdus(string numeProdus)
        {
            Produs produsDeAfisat = produse.Find(p => p.Nume == numeProdus);

            return produsDeAfisat;
        }
    }
}
