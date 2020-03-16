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
using System.IO; // toevoegen 
using Microsoft.Win32; // toevoegen 

namespace WpfNotePad
{
    /// <summary>
    /// Auteur: Imane Toulni
    /// Datum: 09/03/2020
    /// Omschrijving: notepad oefening
    /// </summary>
    
    public partial class MainWindow : Window
    {
        // declareren
        private string startMap = "";
        private string huidigBestand = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = false; // inactief (menu items)
            SaveAs.IsEnabled = false;

            //Cut.IsEnabled = false;
            //Copy.IsEnabled = false;
            //Paste.IsEnabled = false;
        }

        string begintext = "";
        string eindtext = "";


        //                    *** EXIT ***
        private void menuExit(object sender, RoutedEventArgs e)
        {
            // view > properties windows > bliksem > dubbel click op exit 
            Environment.Exit(0); // 0 wilt zeggen dat er niets is fout gelopen 
        }

        //                    *** ABOUT ***
        private void MenuAbout(object sender, RoutedEventArgs e)
        {
                AboutWindow win2 = new AboutWindow();
                win2.Show();
        }


        //                    *** LABEL & TEXTBOX => aantal karakters optellen ***
        private void Label_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            int count = 0;
            string st = "";
            foreach (char c in st)
            {
                if (char.IsLetter(c))
                {
                    count++;
                }
           
            }
            lblCharTeller.Content = count.ToString();

        }

        // properties > textchanged > dubbelclick 
        private void txtAantalKarakters_TextChanged(object sender, TextChangedEventArgs e)
        {
            int aantalChar = txtAantalKarakters.Text.Length;
            lblCharTeller.Content = aantalChar;

            // save moet inactief blijven zolang er geen wijzigingen zijn
            eindtext = txtAantalKarakters.Text;
            if (begintext != eindtext)
            {
                Save.IsEnabled = true; // bij wijzigingen wordt het actief 
                SaveAs.IsEnabled = true;
            }
            else
            {
                Save.IsEnabled = false; // inactief 
            }
        }

        //                    *** OPEN ***
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            StreamReader inputStream;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = startMap;
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";

            if (dialog.ShowDialog() == true)
            {
                huidigBestand = dialog.FileName;
                inputStream = File.OpenText(huidigBestand);
                txtAantalKarakters.Text = inputStream.ReadToEnd(); // bestand lezen 
            }
        }


        //                    *** SAVE ***
        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = startMap;
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT"; // formaat van de bestanden

            dialog.InitialDirectory = startMap;
            dialog.FileName = tabName + ".txt"; // extentie
            if (dialog.ShowDialog() == true)
            {
                huidigBestand = dialog.FileName;
                StreamWriter outputStream = File.CreateText(huidigBestand);
                outputStream.Write(txtAantalKarakters.Text);
                outputStream.Close();
                txtAantalKarakters.Text = "";
            }
        }

        //                    *** SAVE AS ***
        private void menuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = startMap;
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT"; 

            if (dialog.ShowDialog() == true)
            {
                huidigBestand = dialog.FileName;
                StreamWriter outputStream = File.CreateText(huidigBestand);
                outputStream.Write(txtAantalKarakters.Text);
                outputStream.Close();
            }
        }


        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            txtAantalKarakters.Cut();
            Clipboard.SetText(txtAantalKarakters.SelectedText);

            if (txtAantalKarakters.SelectedText != "" )
            {
                Cut.IsEnabled = true;
            }
            else
            {
                Cut.IsEnabled = false;
            }
        }



        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            txtAantalKarakters.Copy();
            Clipboard.SetText(txtAantalKarakters.SelectedText);
            if (txtAantalKarakters.SelectionLength > 0)
            {
                Copy.IsEnabled = true;
            }
            else
            {
                Copy.IsEnabled = false;
            }
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            txtAantalKarakters.Paste();
            Clipboard.GetText(TextDataFormat.Text);

            if (txtAantalKarakters.SelectedText != "")
            {
                Paste.IsEnabled = true;
            }
            else
            {
                Paste.IsEnabled = false;
            }
        }


        private void txtFileContent_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

