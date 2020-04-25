using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; // regex 


namespace KassaTicket
{
    class Product
    {
        // GETTERS EN SETTERS 
        public string Code { get; set; }
        public string ProductNaam { get; set; }
        public double Eenheidsprijs { get; set; }


        // CONSTRUCTORS MET PARAMETERS
        public Product(string code, string prod, double prijs )
        {
            Code = code;
            ProductNaam = prod;
            Eenheidsprijs = prijs;

        }

        // STATISCHE VARIABELE EN METHODE TOEVOEGEN + VALIDEER CODE
        private static string rexCode = @"^\d\d\d\d\d\d$";
        public static bool ValideerCode(string code)
        {
            return Regex.Match(code, rexCode).Success;
        }

        // STRINGVOORSTELLING TERUGGEVEN MET ToString()
        public override string ToString()
        {
            return ProductNaam;
        }
    }
}
