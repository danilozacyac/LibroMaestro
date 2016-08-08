﻿using MantesisVerIusCommonObjects.Dto;
using MantesisVerIusCommonObjects.Model;
using MantesisVerIusCommonObjects.Utilities;
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
    /// Interaction logic for DatosTesis.xaml
    /// </summary>
    public partial class DatosTesis : UserControl
    {
        

        public DatosTesis()
        {
            InitializeComponent();
        }

       

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CbxMateria.DataContext = from n in new DatosCompModel().GetCompartidosMateria()
                                     where n.IdDato < 7
                                     select n;
            

        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            TesisDto tesis = new NumIusModel().BuscaTesis(Convert.ToInt64(TxtIus.Text));

            if (tesis == null)
            {
                MessageBox.Show("No existe alguna tesis con el número de registro digital especificado, favor de verificar");
                return;
            }

            TxtRubro.Text = tesis.Rubro;
            TxtCIdentificacion.Text = tesis.Tesis;
            CbxMateria.SelectedValue = tesis.Materia1;

            if (tesis.TaTj == 1)
                RadJuris.IsChecked = true;
            else
                RadAislada.IsChecked = true;

            if (ValuesMant.Epoca == 100)
                RadDecima.IsChecked = true;
            else if (ValuesMant.Epoca == 5)
                RadNovena.IsChecked = true;
            else
            {
                MessageBox.Show("El número de registro digital ingresado no pertenece a novena o décima época");
                return;
            }

            this.GetPrecedentes(tesis.Precedentes);
        }




        private void GetPrecedentes(string precedente)
        {
            string[] precs = precedente.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> pre = new List<string>();

            foreach (string p in precs)
            {
                if (p.StartsWith("Nota:"))
                    break;

                int index = p.IndexOf('.');

                pre.Add(p.Substring(0, index));
            }

            TxtPrecedentes.Text = string.Join(",\r\n", pre);
            TxtPublicado.Text = pre[0];
        }

        /// <summary>
        /// Habilita o deshabilita los controles señalados tomando en cuenta si la tesis fue publicada o no
        /// </summary>
        /// <param name="isEnable"></param>
        private void DoControlsEnable(bool isEnable)
        {
            RadJuris.IsEnabled = isEnable;
            RadAislada.IsEnabled = isEnable;
            RadNovena.IsEnabled = isEnable;
            RadDecima.IsEnabled = isEnable;
            CbxMateria.IsEnabled = isEnable;
            TxtCIdentificacion.IsEnabled = isEnable;
            TxtRubro.IsEnabled = isEnable;
            TxtPrecedentes.IsEnabled = isEnable;

            TxtIus.IsEnabled = !isEnable;
            BtnBuscar.IsEnabled = !isEnable;
        }

        private void RadPublicada_Checked(object sender, RoutedEventArgs e)
        {
            this.DoControlsEnable(false);
        }

        private void BtnCancelada_Checked(object sender, RoutedEventArgs e)
        {
            this.DoControlsEnable(true);
        }
    }
}
