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

namespace WpfCarConfigurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        // declareren en initialiseren van variabels
        int previousModel = 0;
        int previousColor = 0;
        int previousAccessoires = 0;
        int model = 0;
        int color = 0;
        int accessoires = 0;
  

        public MainWindow()
        {
            InitializeComponent();
        }


        // *******  MODEL   *******

        private void cmbContinental_Selected(object sender, RoutedEventArgs e)
        {
            previousModel = model;
            model = 85000;
            methodeBerekenPrijs(previousModel, model);
        }

        private void cmbConvertible_Selected(object sender, RoutedEventArgs e)
        {
            previousModel = model;
            model = 72000;
            methodeBerekenPrijs(previousModel, model);
        }

        private void cmbMulsanne_Selected(object sender, RoutedEventArgs e)
        {
            previousModel = model;
            model = 65300;
            methodeBerekenPrijs(previousModel, model);
        }



        // *******  KLEUR   *******

        private void rbtnBlauw_Checked(object sender, RoutedEventArgs e)
        {
            previousColor = color;
            color = 0;
            methodeBerekenPrijs(previousColor, color);
        }

        private void rbtnGroen_Checked(object sender, RoutedEventArgs e)
        {
            previousColor = color;
            color = 250;
            methodeBerekenPrijs(previousColor, color);
        }

        private void rbtnRood_Checked(object sender, RoutedEventArgs e)
        {
            previousColor = color;
            color = 700;
            methodeBerekenPrijs(previousColor, color);

        }



        // *******  ACCESOIRES   *******

        private void chxSpeakers_Checked(object sender, RoutedEventArgs e)
        {
            if (chxSpeakers.IsChecked == false)
            {
                previousAccessoires = 1250;
                accessoires = 0;
                methodeBerekenPrijs(previousAccessoires, accessoires);
                imgAudio.Opacity = 0.3;
                
            }
            else
            {
                previousAccessoires = 0;
                accessoires = 1250;
                methodeBerekenPrijs(previousAccessoires, accessoires);
                imgAudio.Opacity = 1;
            }
        }

        private void chxMatjes_Checked(object sender, RoutedEventArgs e)
        {
            if (chxMatjes.IsChecked == false)
            {
                previousAccessoires = 450;
                accessoires = 0;
                methodeBerekenPrijs(previousAccessoires, accessoires);
                imgMatjes.Opacity = 0.3;
            }
            else
            {
                previousAccessoires = 0;
                accessoires = 450;
                methodeBerekenPrijs(previousAccessoires, accessoires);
                imgMatjes.Opacity = 1;
            }
        }

        private void chxVelgen_Checked(object sender, RoutedEventArgs e)
        {
            if (chxVelgen.IsChecked == false)
            {
                previousAccessoires = 300;
                accessoires = 0;
                methodeBerekenPrijs(previousAccessoires, accessoires);
                imgVelgen.Opacity = 0.3;

            }
            else
            {
                previousAccessoires = 0;
                accessoires = 300;
                methodeBerekenPrijs(previousAccessoires, accessoires);
                imgVelgen.Opacity = 1;
            }
        }



        // *******  BEREKENING   *******

        public void methodeBerekenPrijs(int x, int y)
        {
            int previous = x;
            int newPrice = y;
            int totalprice = Convert.ToInt32(lblTotaalPrijs.Content);
            totalprice = totalprice - previous + newPrice;
            lblTotaalPrijs.Content = totalprice;
        }

        
        public void UpdateUI(string x)
        {
            
        }
    }
}
