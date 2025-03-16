using System;
using System.Collections.Generic;
using NivelStocareDate;
using LibrarieModeleMagazin;

namespace MagazinPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazin magazin = new Magazin();
            StocareDate stocare = new StocareDate("StocComponente.txt", "StocPeriferice.txt");
            bool ruleaza = true;

            while (ruleaza)
            {
                Console.WriteLine("\n=== Meniu Magazin PC ===");
                Console.WriteLine("1. Adauga produs");
                Console.WriteLine("2. Sterge produs");
                Console.WriteLine("3. Afiseaza produse");
                Console.WriteLine("4. Cauta produs");
                Console.WriteLine("5. Salveaza ultimul produs in fisier");
                Console.WriteLine("6. Afiseaza produse din fisier");
                Console.WriteLine("7. Incarca produse din fisier");
                Console.WriteLine("8. Iesire");
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
                        magazin.AfiseazaProduse();
                        break;
                    case "4":
                        CautaProdusInMagazin(magazin);
                        break;
                    case "5":
                        SalveazaUltimulProdus(magazin, stocare);
                        break;
                    case "6":
                        AfiseazaProduseDinFisier(stocare);
                        break;
                    case "7":
                        magazin.IncarcareDinFisier(stocare.IncarcaProduse());
                        break;
                    case "8":
                        ruleaza = false;
                        Console.WriteLine("Programul se inchide...");
                        break;
                    default:
                        Console.WriteLine("Optiune invalida! Incearca din nou.");
                        break;
                }
            }
        }

        static void AdaugaProdusInMagazin(Magazin magazin)
        {
            Console.Write("Numele produsului: ");
            string nume = Console.ReadLine();

            Console.Write("Pretul produsului: ");
            float pret = float.Parse(Console.ReadLine());

            Console.Write("Cantitatea în stoc: ");
            int stoc = int.Parse(Console.ReadLine());

            Console.Write("Categorie (1 = Componenta, 2 = Periferic): ");
            tip_produs categorie = (tip_produs)int.Parse(Console.ReadLine());

            magazin.AdaugaProdus(new Produs(nume, pret, stoc, categorie));
        }

        static void StergeProdusDinMagazin(Magazin magazin)
        {
            Console.Write("Introdu numele produsului de sters: ");
            string nume = Console.ReadLine();
            magazin.StergeProdus(nume);
        }

        static void CautaProdusInMagazin(Magazin magazin)
        {
            Console.Write("Numele produsului de cautat: ");
            string nume = Console.ReadLine();
            magazin.CautaProdus(nume);
        }

        static void SalveazaUltimulProdus(Magazin magazin, StocareDate stocare)
        {
            if (magazin.Produse.Count > 0)
            {
                stocare.SalveazaProdus(magazin.Produse.Count > 0 ? magazin.Produse[magazin.Produse.Count - 1] : null);
            }
            else
            {
                Console.WriteLine("Nu exista produse de salvat!");
            }
        }

        static void AfiseazaProduseDinFisier(StocareDate stocare)
        {
            stocare.AfiseazaProduseDinFisier();
        }
    }
}
