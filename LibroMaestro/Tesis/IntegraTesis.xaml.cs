using LibroMaestro.Dto;
using LibroMaestro.Model;
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

namespace LibroMaestro.Tesis
{
    /// <summary>
    /// Interaction logic for IntegraTesis.xaml
    /// </summary>
    public partial class IntegraTesis : UserControl
    {
        
        #region Propiedades

        private List<Integracion> listaElementos;

        public List<Integracion> ListaElementos
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
                listaElementos = new IntegracionModel().GetElementosIntegracion(0);

            LstIntegracion.DataContext = listaElementos;
        }

        private void ChkEjecutoria_Unchecked(object sender, RoutedEventArgs e)
        {
            LblNumEjec.Visibility = Visibility.Collapsed;
            LblNumVotos.Visibility = Visibility.Collapsed;
            NumEjec.Visibility = Visibility.Collapsed;
            NumVotos.Visibility = Visibility.Collapsed;

            NumEjec.Value = 0;
            NumVotos.Value = 0;

            listaElementos = new IntegracionModel().GetElementosIntegracion(1);
            LstIntegracion.DataContext = listaElementos;
        }

        private void ChkEjecutoria_Checked(object sender, RoutedEventArgs e)
        {
            LblNumEjec.Visibility = Visibility.Visible;
            LblNumVotos.Visibility = Visibility.Visible;
            NumEjec.Visibility = Visibility.Visible;
            NumVotos.Visibility = Visibility.Visible;

            NumEjec.Value = 1;
            NumVotos.Value = 0;

            listaElementos = new IntegracionModel().GetElementosIntegracion(0);
            LstIntegracion.DataContext = listaElementos;
        }

        private void BtnSearchFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.InitialDirectory = String.Format(@"C:\Users\{0}\Documents", Environment.UserName);
            dialog.Filter = "PDF Files (*.pdf)|*.pdf";
            dialog.Title = "Selecciona el archivo escaneado";
            dialog.RestoreDirectory = true;
            ;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tesisContext.FileName = dialog.FileName;
            }
        }


        

       

        
    }
}
