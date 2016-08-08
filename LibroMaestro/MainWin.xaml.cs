using LibroMaestro.Dto;
using LibroMaestro.Model;
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

namespace LibroMaestro
{
    /// <summary>
    /// Interaction logic for MainWin.xaml
    /// </summary>
    public partial class MainWin
    {
        List<CircuitoLibro> circuitos;

        public MainWin(List<CircuitoLibro> circuitos)
        {
            InitializeComponent();
            this.circuitos = circuitos;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            treeCircuito.ItemsSource = circuitos;
        }
    }
}
