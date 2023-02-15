using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Name = "Anna Nass", Alter=34},
            new Person(){Name = "Rainer Zufall", Alter=65},
            new Person(){Name = "Maria Meier", Alter=12},
        };

        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            Person person = Spl_DataContextBsp.DataContext as Person;

            MessageBox.Show(person.Name + " (" + person.Alter + ")");
        }

        private void Btn_Altern_Click(object sender, RoutedEventArgs e)
        {
            (Spl_DataContextBsp.DataContext as Person).Alter++;
        }

        private void Btn_NewDay_Click(object sender, RoutedEventArgs e)
        {
            Person person = Spl_DataContextBsp.DataContext as Person;
            person.WichtigeTage.Add(new DateTime(2022, 12, 3));
            person.UpdateGUI();
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            Personenliste.Add(new Person() { Name = "Hugo Müller", Alter = 98 });
        }

        private void Btn_Löschen_Click(object sender, RoutedEventArgs e)
        {
            if (LstV_Personen.SelectedItem != null)
                Personenliste.Remove(LstV_Personen.SelectedItem as Person);
        }
    }
}
