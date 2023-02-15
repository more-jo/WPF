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

namespace PropertyBindings
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Für die explizite Aktualisierung muss eine BindingExpression im CodeBehind erstellt werden und über die Methode UpdateSource() angefordert werden
            //Die BindingExpession wird per Übergabe der (statischen) DependencyProperty an die Methode GetBindingExpression() aus dem bindenen Objekt erhalten
            BindingExpression be = Tbx_Vier.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }
    }
}
