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


using System.IO;   //<-- deze moet je toevoegen om gebruik te kunnen maken van StreamReader en StreamWritter
using System.Data;  // <-- deze moet je toevoegen om gebruik te kunnen maken van DataTable , DataView , ...
using Microsoft.VisualBasic; //<-- om gebruik te maken van 




namespace WpfApp1
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

        DataTable dt = new DataTable();

        private void StartWaarde()
        {
            
        }

        private void btnDatagridOpslaan_csv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLeesBestand_csv_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resaltaat = MessageBox.Show("het lijkt erop dat de file al bestaat wil je het vervangen ? ", "vervangen ? ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MessageBoxResult.Yes == resaltaat)
            {
                int aantalColumns_int;
                string aantalColumns_string;
                aantalColumns_string = Interaction.InputBox("wat is je naam ? ", "heyy daar");
               
                if (!string.IsNullOrEmpty(aantalColumns_string)
                { 
                    
                   
                    
                }
            }




        }


        private void CsvBestandInlezen()
        {
            string pad = "KommaBestand.csv";
            FileInfo fi = new FileInfo(pad);
            if (fi.Exists) // enkel bestand lezen als het bestaat
            {
                using (StreamReader sr = new StreamReader(pad))
                {

                    while (!sr.EndOfStream)
                    {
                        // Splits ingelezen regel op volgens ;
                        string[] items = sr.ReadLine().Split(';');
                        foreach (string item in items)
                        {


                        }


                    }
                    MessageBox.Show("klaar");
                }



            }
            else
            {
                MessageBox.Show("file niet gevonden");
            }
        }




        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
