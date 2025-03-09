using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazin magazin = new Magazin();
            bool ruleaza = true;

            while (ruleaza)
            {
                Console.WriteLine("\n=== Meniu Magazin PC ===");
                Console.WriteLine("1 Adauga produs");
                Console.WriteLine("2 Sterge produs");
                Console.WriteLine("3 Afiseaza produse");
                Console.WriteLine("4 Cauta un produs");
                Console.WriteLine("5 Iesire");
                Console.Write("Alege o optiune: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        AdaugaProdusInMagazin(magazin);
                        break;
                    case "2":
                        StergeProdusDinMagazin(magazin);
                        break;
                    case "3":
                        List<Produs> lista = magazin.AfiseazaProduse();
                        foreach(Produs p in lista)
                        {
                            Console.WriteLine(p.AfiseazaDetalii());
                        }
                        break;
                    case "4":
                        Console.WriteLine("Introduceti numele produsului pe care doriti sa-l cautati: ");
                        string numeProdus = Console.ReadLine();
                        Produs px = magazin.CautaProdus(numeProdus);
                        px.AfiseazaDetalii();
                        if (px != null)
                            Console.WriteLine(px.AfiseazaDetalii());
                        else
                            Console.WriteLine("Nu exista acest produs!");
                            break;
                    case "5":
                        ruleaza = false;
                        Console.WriteLine("\nProgramul se închide...");
                        break;
                    default:
                        Console.WriteLine("Opțiune invalidă! Încearcă din nou.");
                        break;
                }
            }
        }

        static void AdaugaProdusInMagazin(Magazin magazin)
        {
            Console.Write("\nIntrodu numele produsului: ");
            string nume = Console.ReadLine();

            Console.Write("Introdu pretul produsului: ");
            float pret = float.Parse(Console.ReadLine());

            Console.Write("Introdu cantitatea în stoc: ");
            int stoc = int.Parse(Console.ReadLine());

            Console.Write("Produsul este o componenta PC sau un periferic? (1/2): ");
            Enum.TryParse(Console.ReadLine(), out tip_produs tip);

            if (tip != tip_produs.Componenta && tip != tip_produs.Periferic)
            {
                throw new ArgumentException("Tipul trebuie sa fie 1 sau 2!");
            }

            Console.Write("Introdu numele furnizorului: ");
            string numeFurnizor = Console.ReadLine();

            Console.Write("Introdu numarul de contact al furnizorului: ");
            string contactFurnizor = Console.ReadLine();

            magazin.AdaugaProdus(new Produs(nume, pret, stoc, tip, new Furnizor(numeFurnizor, contactFurnizor)));
        }

        static void StergeProdusDinMagazin(Magazin magazin)
        {
            Console.Write("\nIntrodu numele produsului pe care vrei sa-l stergi: ");
            string nume = Console.ReadLine();
            magazin.StergeProdus(nume);
        }
    }
}
