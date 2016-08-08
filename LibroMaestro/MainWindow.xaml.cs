using LibroMaestro.Dto;
using LibroMaestro.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows;
using Telerik.Windows.Controls;

namespace LibroMaestro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CircuitoLibro> circuitos;

        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if (UsuariosModel.ObtenerUsuarioContraseña())
            //{
                StyleManager.ApplicationTheme = new Windows8Theme();

                this.LaunchBusyIndicator();

                string path = ConfigurationManager.AppSettings["ErrorPath"].ToString();

                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

            //}
        }

        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            circuitos = new CircuitoLibroModel().GetCircuito();
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
            MainWin main = new MainWin(circuitos);
            main.Show();
            this.Close();
        }

        private void LaunchBusyIndicator()
        {
            if (!worker.IsBusy)
            {
                this.BusyIndicator.IsBusy = true;
                worker.RunWorkerAsync();
            }
        }

        #endregion
    }
}
