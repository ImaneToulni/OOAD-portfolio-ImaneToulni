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

namespace WpfNotePad
{
    /// <summary>
    /// Auteur: Imane Toulni
    /// Datum: 09/03/2020
    /// Omschrijving: notepad oefening
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitItem_Click(object sender, RoutedEventArgs e)
        {
            // view > properties windows > bliksem > dubbel click op exit 
            Environment.Exit(0); // 0 wilt zeggen dat er niets is fout gelopen 
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
                AboutWindow win2 = new AboutWindow();
                win2.Show();
        }

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
        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            int aantalChar = txt1.Text.Length;
            lblCharTeller.Content = aantalChar;
        }
    }
}

