﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModeleMagazin
{
    public class Furnizor
    {
        public string Nume { get; set; }
        public string Contact { get; set; }
        public Furnizor(string nume, string contact)
        {
            Nume = nume;
            Contact = contact;
        }
        public string FurnizorInfo()
        {
            return $"Nume_Furnizor: {Nume} Contact: {Contact}.";
        }
        public override string ToString()
        {
            return $"{Nume} - {Contact}";
        }

    }
}
