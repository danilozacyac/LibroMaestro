using LibroMaestro.Dto;
using LibroMaestro.Model;
using LibroMaestro.Tesis;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace LibroMaestro
{
    /// <summary>
    /// Interaction logic for MainWin.xaml
    /// </summary>
    public partial class MainWin
    {
        List<CircuitoLibro> circuitos;
        OrganismoLibro selectedOrganismo;
        TesisLibro selectedTesis;

        public MainWin(List<CircuitoLibro> circuitos)
        {
            InitializeComponent();
            this.circuitos = circuitos;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            treeCircuito.ItemsSource = circuitos;
        }

        private void RBtnAddTesis_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOrganismo == null)
            {
                MessageBox.Show("Selecciona el organismo donde se dará de alta la tesis");
                return;
            }

            TesisMgmt tesis = new TesisMgmt(selectedOrganismo) { Owner = this };
            tesis.ShowDialog();

        }

        private void treeCircuito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (treeCircuito.SelectedItem.GetType() == typeof(CircuitoLibro))
            {
                selectedOrganismo = null;
                selectedTesis = null;
                GrpTesis.IsEnabled = false;
                GTesis.DataContext = null;
            }
            else if (treeCircuito.SelectedItem.GetType() == typeof(OrganismoLibro))
            {
                selectedOrganismo = treeCircuito.SelectedItem as OrganismoLibro;

                if (selectedOrganismo.Tesis == null)
                    selectedOrganismo.Tesis = new TesisLibroModel().GetTesisByOrganismo(selectedOrganismo);

                GTesis.DataContext = selectedOrganismo.Tesis;
                GrpTesis.IsEnabled = true;
            }
        }

        private void RBtnVerLibro_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTesis == null)
            {
                MessageBox.Show("Selecciona la tesis de la cual deseas ver su libro electrónico");
                return;
            }

            Process.Start(selectedTesis.FileName);
        }

        private void GTesis_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            selectedTesis = GTesis.SelectedItem as TesisLibro;
        }
    }
}
