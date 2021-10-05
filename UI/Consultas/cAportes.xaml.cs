using P1_AP1_Pedro_2018_0613.BLL;
using P1_AP1_Pedro_2018_0613.DAL;
using P1_AP1_Pedro_2018_0613.Entidades;
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
using System.Windows.Shapes;

namespace P1_AP1_Pedro_2018_0613.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cConsultas.xaml
    /// </summary>

    public partial class cAportes : Window
    {
        public cAportes()
        {
            InitializeComponent();
        }
           
        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Aportes>();


            if (filtroComboBox.Text.Trim().Length > 0)
            {
                switch (filtroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = AportesBLL.GetList(e => e.Persona.ToLower().Contains(filtroComboBox.Text.ToLower()));
                        break;



                    case 1:
                        listado = AportesBLL.GetList(e => e.Concepto.ToLower().Contains(filtroComboBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = AportesBLL.GetList(c => true);
            }

            if (desdeDatePicker.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.Fecha.Date >= desdeDatePicker.SelectedDate);


            if (hastaDatePicker.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.Fecha.Date <= hastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
    

