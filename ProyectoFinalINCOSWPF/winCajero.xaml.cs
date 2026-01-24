using DAOSisVen.Model;
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
using System.Windows.Shapes;

namespace ProyectoFinalINCOSWPF
{
    /// <summary>
    /// Lógica de interacción para winCajero.xaml
    /// </summary>
    public partial class winCajero : Window
    {
        public winCajero()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            txtUsuario.Text = "Bienvenid@: " + SesionClass.SessionFullName + " " + "Rol: " + SesionClass.SessionRole + " ";
        }

        private void lvCambioContra_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            winCambioContra winPassword = new winCambioContra();
            this.Visibility = Visibility.Hidden;
            winPassword.Show();

        }
    }
}
