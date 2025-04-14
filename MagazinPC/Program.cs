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
            StocareDateComponente stocareComponente = new StocareDateComponente("StocComponente.txt");
            StocareDatePeriferice stocarePeriferice = new StocareDatePeriferice("StocPeriferice.txt");
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
                        AdaugaProdusInMagazin(magazin, stocareComponente, stocarePeriferice);
                        Console.ReadKey();
                        break;
                    case "2":
                        StergeProdusDinMagazin(magazin);
                        Console.ReadKey();
                        break;
                    case "3":
                        magazin.AfiseazaProduse();
                        Console.ReadKey();
                        break;
                    case "4":
                        CautaProdusInMagazin(magazin);
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.ReadKey();
                        break;
                    case "6":
                        AfiseazaProduseDinFisier(stocareComponente, stocarePeriferice);
                        Console.ReadKey();
                        break;
                    case "7":
                        magazin.Produse.Clear();
                        magazin.IncarcareDinFisier(stocareComponente.IncarcaProduse());
                        magazin.IncarcareDinFisier(stocarePeriferice.IncarcaProduse());
                        Console.ReadKey();
                        break;
                    case "8":
                        ruleaza = false;
                        Console.WriteLine("Programul se inchide...");
                        break;
                    default:
                        Console.WriteLine("Optiune invalida! Incearca din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AdaugaProdusInMagazin(Magazin magazin, StocareDateComponente stocareComponente, StocareDatePeriferice stocarePeriferice)
        {
            Console.Write("Numele produsului: ");
            string nume_produs = Console.ReadLine();

            Console.Write("Pretul produsului: ");
            float pret = float.Parse(Console.ReadLine());

            Console.Write("Cantitatea în stoc: ");
            int stoc = int.Parse(Console.ReadLine());

            Console.Write("Categorie (1 = Componenta, 2 = Periferic): ");
            tip_produs categorie = (tip_produs)int.Parse(Console.ReadLine());

            Console.Write("Nume furnizor: ");
            string nume_furnizor = Console.ReadLine();

            Console.Write("Contact furnizor: ");
            string contact = Console.ReadLine();

            magazin.AdaugaProdus(new Produs(nume_produs, pret, stoc, categorie,new Furnizor(nume_furnizor,contact)));
            
            if (magazin.Produse[magazin.Produse.Count - 1].Categorie == tip_produs.Componenta)
                stocareComponente.SalveazaProdus(magazin.Produse.Count > 0 ? magazin.Produse[magazin.Produse.Count - 1] : null);
            if (magazin.Produse[magazin.Produse.Count - 1].Categorie == tip_produs.Periferic)
                stocarePeriferice.SalveazaProdus(magazin.Produse.Count > 0 ? magazin.Produse[magazin.Produse.Count - 1] : null);
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
        static void AfiseazaProduseDinFisier(StocareDateComponente stocareC, StocareDatePeriferice stocareP)
        {
            List<Produs> prod1 = stocareC.ObtineProduseDinFisier();
            Console.WriteLine("Produse in fisierComponente:");
            foreach(Produs _prod in prod1)
            {
                Console.WriteLine(_prod.AfiseazaDetalii());
            }
            List<Produs> prod2 = stocareP.ObtineProduseDinFisier();
            Console.WriteLine("Produse in fisierPeriferice:");
            foreach (Produs _prod in prod2)
            {
                Console.WriteLine(_prod.AfiseazaDetalii());
            }
        }
    }
}
