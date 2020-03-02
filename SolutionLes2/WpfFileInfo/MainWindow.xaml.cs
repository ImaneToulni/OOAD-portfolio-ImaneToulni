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
using System.IO; // om geen error te hebben met StreamReader
using Microsoft.Win32; // om geen error te hebben met OpenFileDialog

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
            bool? dialogResult = dialog.ShowDialog(); // bool? heeft nullable bool als returntype
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


                lblInfoBestand.Content = info; // info eerst declareren en dan tonen
            }
        }

    }
}

