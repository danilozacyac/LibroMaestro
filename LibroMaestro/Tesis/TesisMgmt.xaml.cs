using LibroMaestro.Dto;
using LibroMaestro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LibroMaestro.Tesis
{
    /// <summary>
    /// Interaction logic for TesisMgmt.xaml
    /// </summary>
    public partial class TesisMgmt
    {
        int idInstancia, idOrganismo, validaSiguiente = 0,validaGuardar = 0;
        OrganismoLibro organismo;

        TesisLibro tesis;

        public TesisMgmt()
        {
            InitializeComponent();
        }

        public TesisMgmt(OrganismoLibro organismo)
        {
            InitializeComponent();
            this.organismo = organismo;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tesis = new TesisLibro();

            UcDatos.TxtOrganismo.Text = organismo.Organismo;
            tesis.IdInstancia = organismo.IdInstancia;
            tesis.IdOrganismo = organismo.IdOrganismo;
            UcDatos.GetContext(ref tesis);
            UcIntegra.GetContext(ref tesis);
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (BtnGuardar.Content.Equals("Siguiente"))
            {
                this.ValidaDatosTesis();
                if (validaSiguiente == 0)
                {
                    MessageBox.Show("Revisa que todos los campos contengan la información solicitada");
                    return;
                }

                UcDatos.Visibility = Visibility.Collapsed;
                UcIntegra.Visibility = Visibility.Visible;
                BtnAnterior.Visibility = Visibility.Visible;
                BtnGuardar.Content = "Guardar";
            }
            else
            {
                this.ValidaElementosIntegracion();
                if (validaGuardar == 0)
                {
                    MessageBox.Show("Revisa que todos los campos contengan la información solicitada");
                    return;
                }

                tesis.IdMateria = Convert.ToInt16(UcDatos.CbxMateria.SelectedValue);
                tesis.Tatj = (UcDatos.RadAislada.IsChecked == true) ? 0 : 1;
                tesis.IdEpoca = (UcDatos.RadNovena.IsChecked == true) ? 5 : 100;

                bool exito = new TesisLibroModel().InsertaTesis(tesis);

                if (exito)
                {
                    organismo.Tesis.Add(tesis);
                    this.Close(); //Agregar la tesis al listado principal
                }
                else
                {
                    MessageBox.Show("No se pudo completar la operación. Favor de volver a intentar");
                    return;
                }
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
            validaSiguiente = 0;
        }



        private void ValidaDatosTesis()
        {
            if (UcDatos.RadPublicada.IsChecked == false && UcDatos.RadCancelada.IsChecked == false)
            {
                MessageBox.Show("Indica si la tesis fue publicada o su publicación fue cancelada");
                return;
            }

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

            validaSiguiente = 1;
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

            List<Integracion> sinChecar = (from n in UcIntegra.ListaElementos
                                           where n.IsSelected == false
                                           select n).ToList();

            if (sinChecar.Count() >= 1 && (String.IsNullOrEmpty(UcIntegra.TxtObservaciones.Text) || String.IsNullOrWhiteSpace(UcIntegra.TxtObservaciones.Text)))
            {
                MessageBox.Show("Indica la razón por la cual este expediente no contiene todos los elementos");
                return;
            }
            else
            {
                foreach (Integracion integra in UcIntegra.ListaElementos)
                {
                    if (integra.IsSelected)
                        tesis.Elementos += integra.BinaryValue;
                }
            }

            validaGuardar = 1;
        }

    }
}
