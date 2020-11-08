using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Konto meinKonto;
        Konto deinKonto;

        public MainWindow()
        {
            InitializeComponent();
            meinKonto = new Konto("Alen");
            deinKonto = new Konto("Johann");
            updateKontostand();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            meinKonto.einzahlen(1000);
            meinKonto.auszahlen(1100);

            foreach (Transaktion transaktion in meinKonto.Transaktionen)
            {
                MessageBox.Show(transaktion.ToString());
            }
        }

        private void updateKontostand()
        {
            labelKontostand.Content = meinKonto.Kontostand.ToString();
            updateListbox();
        }

        private void updateListbox()
        {
            listBoxTransaktionen.Items.Clear();
            foreach (Transaktion transaktion in meinKonto.Transaktionen)
            {
                TextBlock listEntry = new TextBlock();
                listEntry.Text = transaktion.ToString();
                listEntry.Foreground = transaktion.TextFarbe;
                int newIndex = listBoxTransaktionen.Items.Add(listEntry);
                //ListBoxItem newItem = (ListBoxItem)listBoxTransaktionen.Items[newIndex];
            }
        }

        private bool validiereBetrag(decimal betrag)
        {
            if (betrag <= 0)
            {
                MessageBox.Show("Bitte einen gültigen Wert eingeben.");
                return false;
            }
            else
                return true;
        }

        private void fehlerZeigen()
        {
            MessageBox.Show("Unzureichende Verfügung!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            decimal abhebeBetrag = Decimal.Parse(textBoxBetrag.Text);
            if (validiereBetrag(abhebeBetrag))
            {
                if (meinKonto.auszahlen(abhebeBetrag))
                {
                    //MessageBox.Show(abhebeBetrag.ToString() + " abgehoben.");
                    updateKontostand();
                }
                else
                    fehlerZeigen();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            decimal einzahlBetrag = Decimal.Parse(textBoxBetrag.Text);
            if (validiereBetrag(einzahlBetrag))
            {
                meinKonto.einzahlen(einzahlBetrag);
                //MessageBox.Show(einzahlBetrag.ToString() + " eingezahlt.");
                updateKontostand();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            decimal überweisungsBetrag = Decimal.Parse(textBoxBetrag.Text);
            if (validiereBetrag(überweisungsBetrag))
            {
                if (meinKonto.überweisen(deinKonto, überweisungsBetrag, textBoxVerwendungszweck.Text))
                    updateKontostand();
                else
                    fehlerZeigen();
            }
        }
    }
}
