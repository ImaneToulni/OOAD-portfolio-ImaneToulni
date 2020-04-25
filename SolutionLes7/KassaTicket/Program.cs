using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            // Klasse Ticket
            Ticket naam = new Ticket("Imane");

            // Klasse Product
            Product product  = new Product("P02384",  " bananen: ", 1.75);
            Product product1 = new Product("P01820", " brood: ",    2.10);
            Product product2 = new Product("P45612", " kaas: ",     3.99);
            Product product3 = new Product("P98754", " koffie: ",   4.10);

            // KASSATICKET UITPRINTEN
            Console.WriteLine("KASSATICKET");
            Console.WriteLine("===================");

            // Naam printen
            Console.WriteLine("Uw kassier: " + naam);

            Console.WriteLine(Environment.NewLine);

            // Producten uitprinten
            Console.WriteLine(product);
            Console.WriteLine(product1);
            Console.WriteLine(product2);
            Console.WriteLine(product3);

            Console.WriteLine("---------------------");

            // Extra kosten 

            // Te betalen bedrag

            Console.ReadLine();
        }
    }
}
