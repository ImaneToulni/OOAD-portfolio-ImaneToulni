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
    /// Datum: week 1 - 10/02/2020
    /// Omschrijving: timer oefening (min en seconden)
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer(); // DispatcherTimer is een klasse die gebruikt maak van Tick
        private int count = 0; // standaard seconden op nul zetten
        int minuten = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        //*********************************************************************************************************************************************

        //                                                  ****   TIIMER    ******
        private void timer_Tick(object sender, EventArgs e)
        {
            count++; // toenemen van min en sec
            rectangleSec.Height += 3; // bij runnen gaat het automatisch beneden vergroten => aangepast in XAML VerticalAlignment="Bottom" 
                                      // hoogte van 10 naar 3 veranderd => ging op de timer (textbox)

            if (count == 6) // 60 sec = 1 min => kleiner gezet om geen één min lang te zitten wachten
            {
                count = 0;
                minuten++;
                rectangleMin.Height = (10 * minuten); 
                rectangleSec.Height = 0;
            }

            // basic if-statement om kleuren te veranderen van de rechthoek 
            if (count <= 4) // onder 30 sec (1/2 van 6 = 3) moet het groen zijn
            {
                // groene kleur meegeven 
                SolidColorBrush groeneKleur = new SolidColorBrush();
                groeneKleur.Color = Colors.Green;
                rectangleSec.Fill = groeneKleur;
            }
            else
            {
                // rode kleur meegeven 
                SolidColorBrush rodeKleur = new SolidColorBrush();
                rodeKleur.Color = Colors.Red;
                rectangleSec.Fill = rodeKleur;
            }
            lblMinutenEnSeconden.Content = $"{minuten} minuten {count} seconden"; // aantal min en seconden automatisch toenemen
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
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
            btnReset.IsEnabled = true;
        }

        // wanneer er op STOP gedrukt wordt, wordt er effectief gestopt
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            btnReset.IsEnabled = true;
        }

        // RESET min en seconden 
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

            // ervoor zorgen datde timer terug op 0 staat 
            count = 0;
            minuten = 0;
            lblMinutenEnSeconden.Content = 0;  // na reset moet het vanaf nul starten 

            rectangleMin.Height = 0;           // rechtehoeken moeten ook gereset worden
            rectangleSec.Height = 0;

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = true;
            btnReset.IsEnabled = false;
        }
    }
}