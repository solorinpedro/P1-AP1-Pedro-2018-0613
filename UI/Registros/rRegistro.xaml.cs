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

namespace P1_AP1_Pedro_2018_0613.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRegistro.xaml
    /// </summary>
    public partial class rRegistro : Window
    {
        private Aportes Aporte = new Aportes();

        public rRegistro()
        {
            InitializeComponent();
            this.DataContext = Aporte;
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            {
                var encontradoo = AportesBLL.Buscar(Utilidades.ToInt(AporteIdTextBox.Text));

                if (encontradoo != null)
                {
                    this.Aporte = encontradoo;
                }
                else
                {
                    this.Aporte = new Aportes();
                    MessageBox.Show("No encontrado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                this.DataContext = this.Aporte;
            }
        }

        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
            Clean();
        }

        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            bool paso = AportesBLL.Guardar(this.Aporte);

            if (paso)
            {
                Clean();
                MessageBox.Show("Transaccion Exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBLL.Eliminar(Utilidades.ToInt(AporteIdTextBox.Text)))
            {
                Clean();
                MessageBox.Show("Registro Eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No Fue Posible Eliminar el Registro! :(", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Clean()
        {
            this.Aporte = new Aportes();
            this.DataContext = this.Aporte;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (AporteIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Favor de llenar todo los campo", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
    }
}
