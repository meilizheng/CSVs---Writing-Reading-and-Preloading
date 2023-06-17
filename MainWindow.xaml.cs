using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using CsvHelper;
using MyClassLibary;


namespace CSVs___Writing_Reading_and_Preloading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string filePath = "students.csv";
        List<Student> loadedStudents =new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
    

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                loadedStudents = csv.GetRecords<Student>().ToList();
            }

            lvStudents.ItemsSource = loadedStudents;

        }


        public void Preload()
        {
            List<Student> students = new List<Student>
            {
                new Student( "Will", "Cram", 57, 93),
                new Student( "Josh", "Emery", 101, 105)
            };

            SaveCSVFile(filePath, students);
        }

        public void SaveCSVFile<T>(string filePath, List<T> list)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
       

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csvWriter = new CsvWriter(writer, ci))
                    {
                        csvWriter.WriteRecords(list);
                        writer.Flush();
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            int csi = int.Parse(txtCSI.Text);
            int genEd = int.Parse(txtGenEn.Text);

            loadedStudents.Add(new Student( firstName, lastName, csi, genEd));
            lvStudents.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveCSVFile(filePath, loadedStudents);
        }
    }
}
