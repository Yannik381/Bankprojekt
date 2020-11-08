using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjekt
{
    class Konto
    {

        private static long letzteKontonummer = 0;

        private long kontoNummer;
        private string kontoInhaber;
        private decimal kontoStand;
        private List<Transaktion> transaktionen;

        public long Kontonummer
        {
            get { return kontoNummer; }
        }
        public string Kontoinhaber
        {
            get { return kontoInhaber; }
        }
        public decimal Kontostand
        {
            get { return kontoStand; }
        }
        public List<Transaktion> Transaktionen
        {
            get { return transaktionen; }
        }

        public Konto(string kontoInhaber)
        {
            letzteKontonummer++;
            transaktionen = new List<Transaktion>();

            kontoNummer = letzteKontonummer;
            this.kontoInhaber = kontoInhaber;
            kontoStand = 0;
        }

        public bool einzahlen(decimal betrag)
        {
            return einzahlen(betrag, null, null);
        }

        public bool einzahlen(decimal betrag, Konto quelle, string verwendungszweck)
        {
            kontoStand = kontoStand + betrag;
            transaktionen.Add(new Einzahlung(betrag, quelle, this, verwendungszweck));
            return true;
        }

        public bool auszahlen(decimal betrag)
        {
            return auszahlen(betrag, null, "");
        }

        public bool auszahlen(decimal betrag, Konto ziel, string verwendungszweck)
        {
            if (betrag > kontoStand)
            {
                return false;
            }
            else
            {
                kontoStand = kontoStand - betrag;
                transaktionen.Add(new Auszahlung(betrag * -1, this, ziel, verwendungszweck));
                return true;
            }
        }

        public bool überweisen(Konto zielkonto, decimal betrag, string verwendungszweck)
        {
            if (betrag > kontoStand)
            {
                return false;
            }
            else
            {
                auszahlen(betrag, zielkonto, verwendungszweck);
                zielkonto.einzahlen(betrag, this, verwendungszweck);
                //transaktionen.Add(new Überweisung(this, zielkonto, verwendungszweck, betrag));
                return true;
            }
        }

        public override string ToString()
        {
            return kontoNummer.ToString() + ", " + kontoInhaber;
        }

        internal bool überweisen(Konto deinKonto, decimal überweisungsBetrag, object text)
        {
            throw new NotImplementedException();
        }
    }
}
