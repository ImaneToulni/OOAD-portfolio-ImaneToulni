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

namespace WpfFormChecking
{
    /// <summary>
    /// Auteur: Imane Toulni
    /// Datum: week 1 - 10/02/2020
    /// Omschrijving: form check
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        //*********************************************************************************************************************************************

        //                                                  ****   WISSEN    ******
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            // wanneer er op verwijderen gedrukt wordt, worden alle velden leeg 
            // textbox leeg maken 
            txtNaam.Clear();
            txtRijkregisterNr.Clear();
            txtGeboortedatum.Clear();
            txtEmail.Clear();
            txtBtw.Clear();

            // radiobutton leeg maken
            rBtnMan.IsChecked = false;
            rBtnVrouw.IsChecked = false;

            // checkbox leeg maken
            checkboxProgrammeren.IsChecked = false;
            checkboxNetwerken.IsChecked = false;
            checkboxBusiness.IsChecked = false;

            //wis foutmeldingen van alle labels
            lblMessageName.Content = "";
            lblMessageMail.Content = "";
            lblMessageRijkregisterNr.Content = "";
            lblMessageBtw.Content = "";
            lblMessageGeboortedatum.Content = "";
            lblMessageGeslacht.Content = "";
            lblMessageInteresse.Content = "";
            lblAantalFouten.Content = "";
        }


        //*********************************************************************************************************************************************

        //                                                  ****   REGISTRATIE    *****
        private void btnRegistreren_Click_1(object sender, RoutedEventArgs e)
        {
            //aantal fouten
            int aantalFouten = 0;

            // ****   CHECK NAAM    ***** 
            txtNaam.Text = txtNaam.Text.ToUpper(); // naam in hoofdletters zetten
            if (txtNaam.Text == "")
            {
                //Label lblMessageName = new Label();
                lblMessageName.Content = "naam moet ingevuld zijn";
                aantalFouten++; // increment aantal fouten wordt aan het einde in de label getoond

                //rode foreground meegeven in de label
                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblMessageName.Foreground = rodeKleur;
            }


            // ****   CHECK MAIL    ***** 
            char amperstand = '@';
            int resultaat;
            resultaat = txtEmail.Text.IndexOf(amperstand); // indexOf is een string methode
             
            if (resultaat == -1) // indexof geeft -1 terug als het niet gevonden wordt, maw een false
            {
                lblMessageMail.Content = "email moet een @ bevatten";
                aantalFouten++;

                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblMessageMail.Foreground = rodeKleur;
            }


            // ****   CHECK RIJKREGISTERNUMMER    ***** 
            if (txtRijkregisterNr.Text.Length != 11)
            {
                lblMessageRijkregisterNr.Content = "moet 11 cijfers bevatten";
                aantalFouten++;

                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblMessageRijkregisterNr.Foreground = rodeKleur;    
            }


            // ****   CHECK BTW    ***** 
            string btw = "BE";
            int output;
            output = txtBtw.Text.IndexOf(btw);  // geprobeerd met startswith maar kreeg error

            if (output == -1) // indexof geeft -1 terug als het niet gevonden wordt, maw een false
            {
                lblMessageBtw.Content = "moet met een BE beginnen";
                aantalFouten++;

                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblMessageBtw.Foreground = rodeKleur;
            }


            // ****   CHECK GEBOORTEDATUM    ***** 
            string inputString = txtGeboortedatum.Text;
            DateTime datum;

            if (DateTime.TryParse(inputString, out datum))
            {
                String.Format("{0:d/MM/yyyy}", datum); // formaat moet dd/MM/yyyy => MM in hoofdletters want mm betekent minuten
            }
            else
            {
                lblMessageGeboortedatum.Content = "datum is incorrect";
                aantalFouten++;

                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblMessageGeboortedatum.Foreground = rodeKleur;
            }


            // ****   CHECK GESLACHT (radiobuttons)   ***** 
            if (rBtnMan.IsChecked == false && rBtnVrouw.IsChecked == false) // als beide radiobuttons niet aangevinkt zijn, voer het volgende uit
            {
                lblMessageGeslacht.Content = "kies een geslacht";
                aantalFouten++;

                //rode foreground meegeven in de label
                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblMessageGeslacht.Foreground = rodeKleur;
            }


            // ****   CHECK INTERESSE (checkbox)   ***** 
            if (checkboxBusiness.IsChecked == false && checkboxNetwerken.IsChecked == false && checkboxProgrammeren.IsChecked == false)
            {
                lblMessageInteresse.Content = "kies minstens één interesse";
                aantalFouten++;

                //rode foreground meegeven in de label
                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblMessageInteresse.Foreground = rodeKleur;
            }


            // ****   AANTAL FOUTEN TONEN   ***** 
            //lblAantalFouten.Content = "dit formulier bevat " + aantalFouten + " fouten"; // kan ook op deze manier
            lblAantalFouten.Content = ($"dit formulier bevat {aantalFouten} fouten"); // interpolatie met $ en {} 
            {
                // rode foreground meegeven in de label
                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                lblAantalFouten.Foreground = rodeKleur;

                lblAantalFouten.FontStyle = FontStyles.Italic; // fontstyle van de label naar italic zetten
            }
            return; // 1 return voor alle velden binnen de btnResgistreren + zorgt ervoor dat alles gecontroleerd wordt en niet enkel de eerste veld
        }
    }
}



