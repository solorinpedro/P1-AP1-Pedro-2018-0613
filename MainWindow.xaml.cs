using P1_AP1_Pedro_2018_0613.Entidades;
using P1_AP1_Pedro_2018_0613.UI.Consultas;
using P1_AP1_Pedro_2018_0613.UI.Registros;
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

namespace P1_AP1_Pedro_2018_0613
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

        private void AportesName_Click(object sender, RoutedEventArgs e)
        {
            rAportes aporte = new rAportes();
            aporte.Show();
        }

        private void ConsultarAportes_Click(object sender, RoutedEventArgs e)
        {
            cAportes consultas = new cAportes();
            consultas.Show();
        }
    }
}
