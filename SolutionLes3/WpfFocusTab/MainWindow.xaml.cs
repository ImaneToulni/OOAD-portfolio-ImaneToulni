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

namespace WpfFocusTab
{
    /// <summary>
    /// Auteur: Imane Toulni
    /// Datum: week 3 - 02/03/2020
    /// Omschrijving: focus en tab
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // groene kleur meegeven als het tab toets erop zit
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.Background;
            ctrl.Background = Brushes.Green;


        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // kleur kan ook zo gedefinieerd worden
            //geen focus => witte kleur
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.Background = Brushes.White;
            }
        }
    }
}
