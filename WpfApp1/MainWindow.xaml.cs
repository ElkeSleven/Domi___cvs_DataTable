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
using Microsoft.VisualBasic; //<-- om gebruik te maken van  Interaction.InputBox

using System.Windows.Threading; // 
using System.Windows.Forms; // DataGridViewColumnCollection
using MessageBox = System.Windows.MessageBox;

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
        List<string> alleRijen = new List<string>();


        private void btnDatagridOpslaan_csv_Click(object sender, RoutedEventArgs e)
        {
            string pad = "OUTKommaBestand.txt";    // je kan als extestie .txt of .csv megeven 
            FileInfo fi = new FileInfo(pad);
            if (!fi.Exists)
            {

                using (StreamWriter sw = new StreamWriter(pad))
                {
                    // Gegevens wegschrijven

                    string inhoudCsv = "";
                    var headers = dt.Columns;
                    
                    for (int i = 0; i < headers.Count; i++)
                    {
                        var header = headers[i];       //var col = dt.Columns[i];  // header
                        inhoudCsv += $"{header.ToString()}";
                        if(i == headers.Count - 1)
                        {
                            inhoudCsv += $"\n";
                        }
                        else
                        {
                            inhoudCsv += $";";
                        }
                    }


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = dt.Rows[i];
                        var indexRow = row.ItemArray;
                        for(int j = 0; j < indexRow.Length; j++)
                        {
                            var item = indexRow[j];
                            inhoudCsv += $"{item.ToString()}"; // row 
                            if (j == indexRow.Length - 1)
                            {
                                inhoudCsv += $"\n"; // row 
                            }
                            else
                            {
                                inhoudCsv += $";"; // row 
                            }
                        }
                        

                    }
 


                    sw.WriteLine(inhoudCsv);



                }
                MessageBox.Show("klaar");
            }
            else
            {
                fi.Delete();
            }











           


 



        }

        private void btnLeesBestand_csv_Click(object sender, RoutedEventArgs e)
        {
            string pad = "KommaBestand.csv";
            FileInfo fi = new FileInfo(pad);
            if (fi.Exists) // enkel bestand lezen als het bestaat
            {
                CsvBestandInlezen(pad);
            }
            else
            {
                MessageBox.Show("file niet gevonden");
            }

        }


        //**datagrid vullen met de info wat we krijgen van het csv bestand 
        private void CsvBestandInlezen(string pad)
        {
            
            // Splits ingelezen regel op volgens ;
            dt = new DataTable();
            string[] rijen = File.ReadAllLines(pad);
            string[] headers = rijen[0].Split(';');

            //** pakt de eerte rij van de file en gebruit deze waarden als headers 
            for (int i = 0; i < headers.Length; i++)
            {
                dt.Columns.Add(headers[i], typeof(string));
            }

            //** data inlezen  
            rijen.Skip(1).ToList().ForEach(rij =>
            {

                string[] data = rij.Split(';'); ;
                for (int i = 0; i < data.Length; i++)
                {
                    data = rij.Split(';');
                    if (string.IsNullOrEmpty(data[i]))         /// rij inhoud controlleren op null waarden 
                    {
                        data[i] = null;   
                    }
                    if (!string.IsNullOrEmpty(data[i])) 
                    {
                        data[i] = data[i].Trim();   // Trim : geen White Space

                    }

                }
                dt.Rows.Add(data);

            });

            datagridOpXaml.ItemsSource = dt.AsDataView();

        }

    }
}
