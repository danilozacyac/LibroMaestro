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


        

       

        
    }
}
