using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Telerik.Windows.Controls;

namespace LibroMaestro.Tesis
{
    /// <summary>
    /// Interaction logic for TesisMgmt.xaml
    /// </summary>
    public partial class TesisMgmt
    {
        int idInstancia, idOrganismo;
        string organismo;

        public TesisMgmt()
        {
            InitializeComponent();
        }

        public TesisMgmt(int idInstancia, int idOrganismo, string organismo)
        {
            InitializeComponent();
            this.idInstancia = idInstancia;
            this.idOrganismo = idOrganismo;
            this.organismo = organismo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UcDatos.TxtOrganismo.Text = organismo;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (BtnGuardar.Content.Equals("Siguiente"))
            {

                UcDatos.Visibility = Visibility.Collapsed;
                UcIntegra.Visibility = Visibility.Visible;
                BtnAnterior.Visibility = Visibility.Visible;
                BtnGuardar.Content = "Guardar";
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            UcDatos.Visibility = Visibility.Visible;
            UcIntegra.Visibility = Visibility.Collapsed;
            BtnAnterior.Visibility = Visibility.Collapsed;
            BtnGuardar.Content = "Siguiente";
        }



        private void ValidaDatosTesis()
        {
            if (String.IsNullOrEmpty(UcDatos.TxtRecibida.Text) || String.IsNullOrWhiteSpace(UcDatos.TxtRecibida.Text))
            {
                MessageBox.Show("Ingresa la clave de control con la que se recibió la tesis");
                return;
            }

            if (String.IsNullOrEmpty(UcDatos.TxtRecibida.Text) || String.IsNullOrWhiteSpace(UcDatos.TxtRecibida.Text))
            {
                MessageBox.Show("Ingresa la clave de control aprobada");
                return;
            }

            if (String.IsNullOrEmpty(UcDatos.TxtPublicado.Text) || String.IsNullOrWhiteSpace(UcDatos.TxtPublicado.Text))
            {
                MessageBox.Show("Ingresa el precedente publicado");
                return;
            }

            if (!UcDatos.TxtPrecedentes.Text.Contains(UcDatos.TxtPublicado.Text))
            {
                MessageBox.Show("El precedente publicado no se encuentra dentro de los precedentes");
                return;
            }

            if (UcDatos.RadPublicada.IsChecked == false)
            {
                if (UcDatos.RadJuris.IsChecked == false && UcDatos.RadAislada.IsChecked == false)
                {
                    MessageBox.Show("Selecciona el tipo de tesis");
                    return;
                }

                if (UcDatos.RadNovena.IsChecked == false && UcDatos.RadDecima.IsChecked == false)
                {
                    MessageBox.Show("Selecciona la época a la que pertenece esta tesis");
                    return;
                }

                if (UcDatos.CbxMateria.SelectedIndex == -1)
                {
                        MessageBox.Show("Selecciona la materia que se le asignó a la tesis");
                        return;
                }

                if (String.IsNullOrEmpty(UcDatos.TxtRubro.Text) || String.IsNullOrWhiteSpace(UcDatos.TxtRubro.Text))
                {
                    MessageBox.Show("Ingresa el rubro de la tesis");
                    return;
                }

                if (String.IsNullOrEmpty(UcDatos.TxtPrecedentes.Text) || String.IsNullOrWhiteSpace(UcDatos.TxtPrecedentes.Text))
                {
                    MessageBox.Show("Ingresa los precedentes de la tesis");
                    return;
                }

                if (String.IsNullOrEmpty(UcDatos.TxtCIdentificacion.Text) || String.IsNullOrWhiteSpace(UcDatos.TxtCIdentificacion.Text))
                {
                    MessageBox.Show("Ingresa el precedente publicado");
                    return;
                }
            }
        }

        private void ValidaElementosIntegracion()
        {

            if (String.IsNullOrEmpty(UcIntegra.TxtNCarpeta.Text) || String.IsNullOrWhiteSpace(UcIntegra.TxtNCarpeta.Text))
            {
                MessageBox.Show("Ingresa el número de la carpeta en la que se encuentra esta tesis");
                return;
            }

            if (UcIntegra.NumInicio.Value < 1)
            {
                MessageBox.Show("Ingresa el número de tesis con la que inicia esta carpeta");
                return;
            }

            if (UcIntegra.NumInicio.Value > UcIntegra.NumFinal.Value)
            {
                MessageBox.Show("El número de tesis final no puede ser inferior al inicial");
                return;
            }

            if (String.IsNullOrEmpty(UcIntegra.TxtSupportFile.Text) || String.IsNullOrWhiteSpace(UcIntegra.TxtSupportFile.Text))
            {
                MessageBox.Show("Ingresa el número de la carpeta en la que se encuentra esta tesis");
                return;
            }

            var sinChecar = from n in UcIntegra.ListaElementos
                            where n.IsSelected = false
                            select n;

            if (sinChecar.Count() > 1 && (String.IsNullOrEmpty(UcIntegra.TxtObservaciones.Text) || String.IsNullOrWhiteSpace(UcIntegra.TxtObservaciones.Text)))
            {
                MessageBox.Show("Indica la razón por la cual este expediente no contiene todos los elementos");
                return;
            }


        }

    }
}
