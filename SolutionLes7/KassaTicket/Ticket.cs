using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaTicket
{
    class Ticket
    {
        // GETTERS EN SETTERS 
        public string Producten { get; set; }
        public string BetaalMethode { get; set; }
        public string KassierNaam { get; set; }
        public double Totaalprijs { get; set; }

        // CONSTRUCTOR MET PARAMETERS
        public Ticket(string kassierNaam)
        {
            KassierNaam = kassierNaam;
        }
    }
}
