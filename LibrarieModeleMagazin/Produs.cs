using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrarieModeleMagazin
{
    public enum tip_produs
    {
        Componenta = 1,
        Periferic = 2
    }
    public class Produs
    {
        public bool Activ { get; set; }
        public Guid ID { get; private set; } = Guid.NewGuid();
        public string Nume { get; set; }
        public float Pret { get; set; }
        public int Stoc { get; set; }
        public tip_produs Categorie { get; set; }
        public Furnizor furnizor { get; set; }

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

            if (!EsteValid())
                throw new ArgumentException("Produs invalid citit din fișier.");
        }


        public bool EsteValid()
        {
            return !string.IsNullOrWhiteSpace(Nume) &&
                   Pret > 0 &&
                   Stoc >= 0 &&
                   furnizor != null &&
                   furnizor.ContactValid();
        }

        public string AfiseazaDetalii()
        {
            return $"{Nume} - {Pret} RON - Stoc: {Stoc} - Categorie: {Categorie} - Furnizor: {furnizor.Nume} - Contact: {furnizor.Contact}";
        }
    }

}
