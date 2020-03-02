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
using System.IO;
using Microsoft.Win32;

namespace WpfCopyVs2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Auteur: Imane Toulni
    /// Datum: 17/02/2020
    /// Omschrijving: les 2 - PATH gebruik maken van OpenFileDialog en SaveFileDialog
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()

        {
            InitializeComponent();
        }

        // Button kies
        // gebruik gemaakt van OpenFileDialog om een venster te openen en van hieruit een bestand te kezen in txt-formaat 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // bestand bevindt zich bij mijn documenten
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            string chosenFileName;
            bool? dialogResult = dialog.ShowDialog(); // bool? heeft nullable bool als returntype
            if (dialogResult == true)
            {
                // user picked a file and pressed OK
                chosenFileName = dialog.FileName;
                // volledige path tonen in de txtIN
                string path = dialog.FileName.ToString(); // dialog werd gedeclareerd bij OpenFileDialog regel 38
                txtIn.Text = path;

            }
        }

        // button GO! 
        // gebruik gemaakt van SaveFileDialog 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            dialog.FileName = "savedfileVs2.txt";
            if (dialog.ShowDialog() == true)
            {
                using (StreamWriter writer = File.CreateText(dialog.FileName))
                {
                    writer.WriteLine("Dit is lijn 1");
                    writer.WriteLine("Dit is lijn 2");
                    writer.WriteLine("Dit is lijn 3");
                    writer.WriteLine("Dit is lijn 4"); // tekst in de file
                }

                lblMessage.Content = "bestand is overgezet";

            }
            else
            {
                // user pressed Cancel or escaped dialog window
                lblMessage.Content = "er is een fout opgetreden";

            }

        }
    }
}
