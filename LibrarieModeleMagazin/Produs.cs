using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarieModeleMagazin
{
    // Enum pentru tipul produsului: Componentă sau Periferic
    public enum tip_produs
    {
        Componenta = 1,
        Periferic = 2
    }
    // Clasa care reprezintă un produs din magazin
    public class Produs
    {
        // Specifică dacă produsul este activ (vizibil/utilizabil în aplicație)
        public bool Activ { get; set; }
        // Identificator unic pentru fiecare produs (generat automat)
        public Guid ID { get; private set; } = Guid.NewGuid();
        // Numele produsului
        public string Nume { get; set; }
        // Prețul produsului
        public float Pret { get; set; }
        // Cantitatea disponibilă în stoc
        public int Stoc { get; set; }
        // Categoria produsului: Componentă sau Periferic
        public tip_produs Categorie { get; set; }
        // Furnizorul asociat produsului (nume și contact)
        public Furnizor furnizor { get; set; }

        // Constructor folosit când creezi manual un produs nou în aplicație
        public Produs(string nume, float pret, int stoc, tip_produs categorie, Furnizor furnizor)
        {
            Nume = nume;
            Pret = pret;
            Stoc = stoc;
            Categorie = categorie;
            this.furnizor = furnizor;

            Activ = true;

            if (!EsteValid())
                throw new ArgumentException("Produsul conține date invalide.");
        }

        // Constructor folosit pentru a crea un produs pe baza unui rând din fișier (citire din fișier)
        public Produs(string linieFisier)
        {
            var date = linieFisier.Split(',');

            ID = Guid.Parse(date[0]);
            Nume = date[1];
            Pret = float.Parse(date[2]);
            Stoc = int.Parse(date[3]);
            Categorie = (tip_produs)Enum.Parse(typeof(tip_produs), date[4]);
            furnizor = new Furnizor(date[5], date[6]);

            Activ = true;

            // Verifică dacă produsul este valid, altfel aruncă excepție
            if (!EsteValid())
                throw new ArgumentException("Produs invalid citit din fișier.");
        }

        // Metodă care verifică dacă produsul este valid (nume nenul, preț pozitiv, stoc ≥ 0, furnizor valid)
        public bool EsteValid()
        {
            return !string.IsNullOrWhiteSpace(Nume) &&
                   Pret > 0 &&
                   Stoc >= 0 &&
                   furnizor != null &&
                   furnizor.ContactValid();
        }

        // Metodă care returnează un text cu toate detaliile produsului (pentru afișare)
        public string AfiseazaDetalii()
        {
            return $"{Nume} - {Pret} RON - Stoc: {Stoc} - Categorie: {Categorie} - Furnizor: {furnizor.Nume} - Contact: {furnizor.Contact}";
        }
    }

}
