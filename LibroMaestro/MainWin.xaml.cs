using LibroMaestro.Dto;
using LibroMaestro.Model;
using LibroMaestro.Tesis;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Linq;
using System;
using System.Windows.Media.Imaging;

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
            this.ShowInTaskbar(this, "Libros electrónicos");
        }

        /// <summary>
        /// Permite mostrar las ventanas de tipo RadWindow el Taskbar
        /// además permite asignar el icono de la aplicación y el nombre de la ventana
        /// </summary>
        /// <param name="control"></param>
        /// <param name="title"></param>
        private void ShowInTaskbar(RadWindow control, string title)
        {
            control.Show();
            var window = control.ParentOfType<Window>();
            window.ShowInTaskbar = true;
            window.Title = title;
            var uri = new Uri("pack://application:,,,/Resources/bookcase_128.png");
            window.Icon = BitmapFrame.Create(uri);
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

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearch.Text))
            {
                treeCircuito.ItemsSource = circuitos;
            }
            else
            {
                List<CircuitoLibro> filteredCircuito = new List<CircuitoLibro>();

                foreach (CircuitoLibro circuitoFilter in circuitos)
                {
                    CircuitoLibro newCircuito = new CircuitoLibro();
                    newCircuito.IdCircuito = circuitoFilter.IdCircuito;
                    newCircuito.Descripcion = circuitoFilter.Descripcion;

                    newCircuito.OrganismosLibro = (from n in circuitoFilter.OrganismosLibro
                                                   where n.Organismo.Contains(TxtSearch.Text.ToUpper())
                                                   select n).ToList();
                    if (newCircuito.OrganismosLibro != null && newCircuito.OrganismosLibro.Count > 0)
                        filteredCircuito.Add(newCircuito);
                }
                treeCircuito.ItemsSource = filteredCircuito;
            }
        }
    }
}
