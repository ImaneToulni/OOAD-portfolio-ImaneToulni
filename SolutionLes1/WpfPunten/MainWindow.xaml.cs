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
    /// Datum: 10/02/2020
    /// Omschriijving: Puntenscore in een lijstje kunnen toevoegen en verwijderen
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            // Alle inputs verwijderen wanneer er op btn verwijderen gedrukt wordt
            txtNaam.Clear();
            txtPunten.Clear();
            txtFilter.Clear();
            lstbx.Items.Clear(); // om listbox te verwijderen, wordt items gebruikt
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            // items telkens toevoegen in een listbox
            lstbx.Items.Add(txtNaam.Text + " - " + txtPunten.Text + " /100");


            // input verwijderen wanneer naam en punten toegevoegd wordt, zodat men direct een tweede naam en punt kan invoeren
            txtNaam.Clear();
            txtPunten.Clear();
        }

        
        // ********************************************* FILTER NOG NIET GEDAAN 

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

    }

}
