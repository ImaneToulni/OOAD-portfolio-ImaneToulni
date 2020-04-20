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
using System.Net.Mail; // manueel toevoegen

namespace WpfBanking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Customer cust1 = new Customer(); // gebruik eerste constructor
            Customer cust2 = new Customer("Imane", "Toulni"); // gebruik tweede constructor
            Customer cust3 = new Customer("Hatim", "Toulni", 4); // gebruik derde constructor

            Account acc1 = new Account("001-2391224-56", "Imane Toulni", 100);

     

        }


    }
}
