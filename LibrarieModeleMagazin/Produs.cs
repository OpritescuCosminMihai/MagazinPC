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
        public string Nume { get; set; }
        public float Pret { get; set; }
        public int Stoc { get; set; }
        public tip_produs Categorie { get; set; }

        public Produs(string nume, float pret, int stoc, tip_produs categorie)
        {
            Nume = nume;
            Pret = pret;
            Stoc = stoc;
            Categorie = categorie;
        }
        public Produs(string linieFisier)
        {
            var date = linieFisier.Split(',');
            Nume = date[0];
            Pret = float.Parse(date[1]);
            Stoc = int.Parse(date[2]);
        }
        public string AfiseazaDetalii()
        {
            return $"{Nume} - {Pret} RON - Stoc: {Stoc} - Categorie: {Categorie}";
        }
    }
}
