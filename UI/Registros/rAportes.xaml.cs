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
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        private Aportes Aporte = new Aportes();
        public rAportes()
        {
            InitializeComponent();
            this.DataContext = Aporte;
        }
        public void Limpiar()
        {
            this.Aporte = new Aportes();
            this.DataContext = Aporte;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (FechaDatePicker.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte la fecha", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (PersonaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el nombre de la persona", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte el concepto", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var aportes = AportesBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));
            if (aportes != null)
            {
                this.Aporte = aportes;
            }
            else
            {
                this.Aporte = new Aportes();
                MessageBox.Show("No se ha encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DataContext = this.Aporte;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var paso = AportesBLL.Guardar(this.Aporte);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Se ha guardado exitosamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se ha guardado exitosamente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Se ha eliminado exitosamente", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se ha eliminado exitosamente", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
