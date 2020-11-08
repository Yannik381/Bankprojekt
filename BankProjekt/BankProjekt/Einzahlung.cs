using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BankProjekt
{
    class Einzahlung : Transaktion
    {
        public Einzahlung(decimal betrag, Object quelle, Object ziel) : base(betrag, quelle, ziel, null)
        {
            textFarbe = Brushes.Black;
        }

        public Einzahlung(decimal betrag, Object quelle, Object ziel, string verwedungszweck) : base(betrag, quelle, ziel, verwedungszweck)
        {
            textFarbe = Brushes.Black;
        }
    }
}