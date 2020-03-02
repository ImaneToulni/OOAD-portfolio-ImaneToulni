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



namespace WpfCopyVs1
{
    /// <summary>
    /// Auteur: Imane Toulni
    /// Datum: 17/02/2020
    /// Descrptiion/ Les 2 - oefeningen (copy/past) - werken met IO.Exception
    /// </summary>
    public partial class MainWindow : Window
    {
        // geen event gebruiken, manueel txt typen
 
        public MainWindow()
        {
            InitializeComponent();
            string content;
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = System.IO.Path.Combine(folderPath, "test.txt");

            if (!File.Exists(filePath)) return; // simple check without the need of Exception handling
            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (IOException e)
            { // be specific: use IOException instead of Exception
                lblMessage.Content = "Error reading " + filePath;
            }
        }


        // Button GO! 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // prepare
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = System.IO.Path.Combine(folderPath, "savedfileVs1.txt"); // naam bestand van nieuwe file 
            // open stream and start writing
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine("Dit is lijn 1");
                writer.WriteLine("Dit is lijn 2");
                writer.WriteLine("Dit is lijn 3");
                writer.WriteLine("Dit is lijn 4");
                lblMessage.Content = "bestand is overgezet";
            } // stream closes automatically
        }
    }
}
