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

namespace Controls
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

        //Event-Handler für das Click-Event des Buttons
        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            //Übertrag des TextBox-Texts in den Label-Content
            Lbl_Output.Content = Tbx_Input.Text;

            //Prüfung, ob die Checkbox abgehakt ist
            if (Cbx_Haken.IsChecked == true)
                //Neuzuweisung der Titel-Eigenschaft des Windows mit dem ausgewählten Inhalt der ComboBox
                this.Title = (Cbb_Auswahl.SelectedItem as ComboBoxItem)?.Content.ToString();

            //Übertrag des Slider-Values in den Button-Content
            Btn_KlickMich.Content = Sdr_Wert.Value.ToString();
        }

        //Event, das auf einen Tastendruck reagiert (wenn Cursor in TextBox)
        private void Tbx_Input_KeyDown(object sender, KeyEventArgs e)
        {
            //Prüfung, welche Taste gedrückt wurde
            if (e.Key == Key.F12)
                //Ändern der TextWrappuing-Eigenschaft
                Tbx_Input.TextWrapping = TextWrapping.NoWrap;
        }

        private void Schließen_Click(object sender, RoutedEventArgs e)
        {
            //Anzeigen einer MessageBox und Abfrage des geklickten Buttons
            if (MessageBox.Show
                (
                    "Soll das Programm wirklich geschlossen werden?",
                    "Programm beenden",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                ) == MessageBoxResult.Yes)

                //Schließen des Fensters
                this.Close();

            //Beenden der Applikation
            //Application.Current.Shutdown();
        }

        private void Fenster_Click(object sender, RoutedEventArgs e)
        {
            Window wnd = new MainWindow();

            wnd.Title = "Neues Fenster";

            //Öffen eines neuen Fensters als gleichberechtigtes Fenster
            wnd.Show();
        }

        private void Dialog_Click(object sender, RoutedEventArgs e)
        {
            Window wnd = new MainWindow();

            wnd.Title = "Neues Dialog-Fenster";

            //Öffnen eines neuen Fensters als Dialogfenster mit Rückgabe des DialogResults
            if (wnd.ShowDialog() == true)
                Lbl_Output.Content = "OKAY wurde geklickt";
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            //Setzen des DialogResults (NUR IN DIALOGFENSTERN) und automatisches Schließen des Fensters
            this.DialogResult = true;
            this.Close();
        }
    }
}
