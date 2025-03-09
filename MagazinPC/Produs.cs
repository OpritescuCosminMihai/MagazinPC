using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinPC
{
    enum tip_produs
    {
        Altele = 0,
        Componenta = 1,
        Periferic = 2
    }
    class Produs
    {
        public tip_produs Categorie { get; set; }
        public string Nume { get; set; }
        public float Pret { get; set; }
        public int Stoc { get; set; }
        public Furnizor furnizor { get; set; }

        public Produs(string nume, float pret, int stoc, tip_produs categorie, Furnizor furnizor)
        {
            this.Nume = nume;
            this.Pret = pret;
            this. Stoc = stoc;
            this.Categorie = categorie;
            this.furnizor = furnizor;
        }

        public string AfiseazaDetalii()
        {
            string categ;
            switch(Categorie)
            {
                case tip_produs.Altele:
                    categ = "Altele";
                    break;
                case tip_produs.Componenta:
                    categ = "Componenta";
                    break;
                case tip_produs.Periferic:
                    categ = "Periferic";
                    break;
                default:
                    categ = "";
                    break;
            }
            return $"Produs: {Nume}, Pret: {Pret} RON, Stoc: {Stoc} bucati, Categorie: {categ}";
        }
    }
}
