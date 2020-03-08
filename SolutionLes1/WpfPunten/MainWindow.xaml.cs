

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

namespace WpfPunten
{
    /// <summary>
    /// Auteur: Imane Toulni
    /// Datum: week 1 - 10/02/2020
    /// Omschrijving: Puntenscore in een lijstje kunnen toevoegen en verwijderen
    /// </summary>
    
    public partial class MainWindow : Window
    {

        //kan ook in een dictionarry gemaakt worden

        public MainWindow()
        {
            InitializeComponent();
        }

        //*********************************************************************************************************************************************

        //                                                  ****   KNOPPEN    ******

        // Alle textboxen en label verwijderen
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            // Alle inputs verwijderen wanneer er op btn verwijderen gedrukt wordt
            txtNaam.Clear();
            txtPunten.Clear();
            txtFilter.Clear();
            lstbx.Items.Clear(); // om listbox te verwijderen, wordt items gebruikt
        }

        // naam en punt toevoegen van labels => listbox met juiste formaat
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            // items telkens toevoegen in een listboxlist
            // om problemen te voorkomen 


            ListBoxItem resultaat = new ListBoxItem();
            resultaat.Content = txtNaam.Text + " - " + txtPunten.Text + " /100".ToString();
            lstbx.Items.Add(resultaat);

            // input verwijderen wanneer naam en punten toegevoegd wordt, zodat men direct een tweede naam en punt kan invoeren
            txtNaam.Clear();
            txtPunten.Clear();
        }


        //*********************************************************************************************************************************************

        //                                                  ****   FILTER    ******
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (ListBoxItem resultaat in lstbx.Items)
            {
                string content = Convert.ToString(resultaat.Content).ToLower(); // omzetten naar kleine letters dmv ToLower();
                if (content.Contains(txtFilter.Text.ToLower()))
                {
                    resultaat.Background = Brushes.LightCoral;
                }
                else
                {
                    resultaat.Background = Brushes.White;
                }
            }
        }
    }
}
