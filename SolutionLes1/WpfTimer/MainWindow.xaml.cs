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
using System.Windows.Threading; // toevoegen om gebruik te maken van de DispatcherTimer


    namespace WpfTimer
{
    /// <summary>
    /// Auteur: Imane Toulni
    /// Datum: 10/02/2020
    /// Omschriijving: timer oefeniing (min en seconden)
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer(); // DispatcherTimer is een klasse die gebruikt maak van Tick
        private int count = 0; // standaard op nul zetten
        int minuten = 0; // variabel standaard op nul zetten 


        public MainWindow()
        {
            InitializeComponent();
          
        }

        //*********************************************************************************************************************************************

        //                                                  ****   TIIMER    ******
        private void timer_Tick(object sender, EventArgs e)
        {
            count++; // toenemen van min en sec
            rectangleSec.Height += 10; // bij runnen gaat het automatisch beneden vergroten => aangepast in XAML VerticalAlignment="Bottom"
            if (count == 3) // 60 sec = 1 min
            {
                count = 0;
                minuten++;
                rectangleMin.Height = (10 * minuten);
                rectangleSec.Height = 0;
            }
            lblMinutenEnSeconden.Content = $"{minuten} minuten {count} seconden"; // in de label zal het aantal min en seconden automatiisch toenemen
        }

        // toevoegen om geen error melding te hebben
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }


        //*********************************************************************************************************************************************

        //                                                  ****   ALLE KNOPPEN    ****
        // wanneer er op START gedrukt wordt, zullen de min en sec toenemen
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblMinutenEnSeconden.Content = count; 
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        // wanneer er op STOP gedrukt wordt, wordt er effectief gestopt
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        // RESET min en seconden 
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lblMinutenEnSeconden.Content = "";
            rectangleMin.Height = 0;
            rectangleSec.Height = 0;
         
        }
    }
}
