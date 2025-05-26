using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModeleMagazin
{
    // Clasa care reprezintă un furnizor asociat unui produs
    public class Furnizor
    {
        // Numele furnizorului
        public string Nume { get; set; }

        // Informațiile de contact (email sau telefon)
        public string Contact { get; set; }

        // Constructor pentru inițializarea unui furnizor cu nume și contact
        public Furnizor(string nume, string contact)
        {
            Nume = nume;
            Contact = contact;
        }

        // Metodă care returnează un text cu informațiile despre furnizor
        public string FurnizorInfo()
        {
            return $"Nume_Furnizor: {Nume} Contact: {Contact}.";
        }

        // Suprascrie metoda ToString() pentru a returna numele și contactul într-un singur string
        public override string ToString()
        {
            return $"{Nume} - {Contact}";
        }

        // Metodă care verifică dacă contactul furnizorului este valid
        public bool ContactValid()
        {
            // Verificare dacă este email simplu
            if (Contact.Contains("@") && Contact.Contains("."))
                return true;

            // Verificare dacă este telefon (doar cifre și lungime minimă)
            return Contact.All(char.IsDigit) && Contact.Length >= 7;
        }
    }
}
