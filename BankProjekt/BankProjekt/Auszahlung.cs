using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BankProjekt
{
    class Auszahlung : Transaktion
    {
        public Auszahlung(decimal betrag, Object quelle, Object ziel) : base(betrag, quelle, ziel, null)
        {
            textFarbe = Brushes.Red;
        }

        public Auszahlung(decimal betrag, Object quelle, Object ziel, string verwendungszweck) : base(betrag, quelle, ziel, verwendungszweck)
        {
            textFarbe = Brushes.Red;
        }
    }
}
