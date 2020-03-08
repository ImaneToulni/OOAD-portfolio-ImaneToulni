using Microsoft.Win32; // om geen error te hebben met OpenFileDialog
using System;
using System.IO; // om geen error te hebben met StreamReader
using System.Windows;

namespace WpfFileInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnKiesBestand_Click(object sender, RoutedEventArgs e)
        {
            // bestand kiezen 
            string chosenFileName;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
            bool? dialogResult = dialog.ShowDialog(); // bool? heeft nullable bool als returntype (bevestigs, geannuleerd nog steeds open)
            
            if (dialogResult == true)
            {
                // user picked a file and pressed OK
                chosenFileName = dialog.FileName;

                // info teruggeven over bestand die geselecteerd werd
                FileInfo fi = new FileInfo(chosenFileName); 
                string info = "";
                info += $"bestandsnaam: {fi.Name}{Environment.NewLine}";
                info += $"extensie: {fi.Extension}{Environment.NewLine}";
                info += $"gemaakt op: {fi.CreationTime.ToString()}{Environment.NewLine}";
                info += $"mapnaam: {fi.Directory.Name}{Environment.NewLine}";


                // berekening aantal woorden
                StreamReader sr = new StreamReader(chosenFileName);

                int counter = 0;
                string delim = "' ' , ."; //maybe some more delimiters like ?! and so on
                string[] fields = null;
                string line = null;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();//each time you read a line you should split it into the words
                    line.Trim();
                    fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    counter += fields.Length; //and just add how many of them there is
                }

                sr.Close();
                info += $"aantal woorden: {counter}{Environment.NewLine}";


                // meest voorkomende woorden
                // nog niet klaar => join nodig 
                
                lblInfoBestand.Content = info; // info eerst declareren en dan tonen

            }
        }

    }
}

