using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LibroMaestro.Dto;
using LibroMaestro.Model;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls;

namespace LibroMaestro.Tesis
{
    /// <summary>
    /// Interaction logic for IntegraTesis.xaml
    /// </summary>
    public partial class IntegraTesis : UserControl
    {
        
        #region Propiedades

        private ObservableCollection<Integracion> listaElementos;

        public ObservableCollection<Integracion> ListaElementos
        {
            get
            {
                return this.listaElementos;
            }
            set
            {
                this.listaElementos = value;
            }
        }


        private TesisLibro tesisContext;

        public void GetContext(ref TesisLibro tesisContext)
        {
            this.tesisContext = tesisContext;
            this.DataContext = tesisContext;
        }
        #endregion

        public IntegraTesis()
        {
            InitializeComponent();
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (listaElementos == null)
                listaElementos = new IntegracionModel().GetElementosIntegracion(2,1);

            LstIntegracion.DataContext = listaElementos;
        }

        private void BtnSearchFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.InitialDirectory = String.Format(@"C:\Users\{0}\Documents", Environment.UserName);
            dialog.Filter = "PDF Files (*.pdf)|*.pdf";
            dialog.Title = "Selecciona el archivo escaneado";
            dialog.RestoreDirectory = true;
            

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tesisContext.FileName = dialog.FileName;
            }
        }

        private void OrdenaLista()
        {
            listaElementos = new ObservableCollection<Integracion>(from n in listaElementos
                                                                   orderby n.Orden
                                                                   select n);
        }

        private void AgregaElementos(int tipoElemento)
        {
            foreach (Integracion integra in new IntegracionModel().GetElementosIntegracion(2, tipoElemento))
                listaElementos.Add(integra);

            this.OrdenaLista();
        }

        private void EliminaElementos(int tipoElemento)
        {
            listaElementos = new ObservableCollection<Integracion>(from n in listaElementos
                                                                   where n.Tipo != tipoElemento
                                                                   orderby n.Orden
                                                                   select n);
            this.OrdenaLista();
        }

        private void Elements_Checked(object sender, RoutedEventArgs e)
        {
            ToggleSwitch switchy = (ToggleSwitch)sender ;
            int elementId = Convert.ToInt16(switchy.Uid);

            if (elementId == 2)
            {
                LblNumEjec.Visibility = Visibility.Visible;
                NumEjec.Visibility = Visibility.Visible;
                NumEjec.Value = 1;
            }
            else if (elementId == 3)
            {
                LblNumVotos.Visibility = Visibility.Visible;
                NumVotos.Visibility = Visibility.Visible;
                NumVotos.Value = 1;
            }

            this.AgregaElementos(4);
            LstIntegracion.DataContext = listaElementos;

        }

        private void Elements_Unchecked(object sender, RoutedEventArgs e)
        {
            ToggleSwitch switchy = (ToggleSwitch)sender;
            int elementId = Convert.ToInt16(switchy.Uid);

            if (elementId == 2)
            {
                LblNumEjec.Visibility = Visibility.Collapsed;
                NumEjec.Visibility = Visibility.Collapsed;
                NumEjec.Value = 0;
            }
            else if (elementId == 3)
            {
                LblNumVotos.Visibility = Visibility.Collapsed;
                NumVotos.Visibility = Visibility.Collapsed;
                NumVotos.Value = 0;
            }

            this.EliminaElementos(4);
            LstIntegracion.DataContext = listaElementos;
        }

        
    }
}
