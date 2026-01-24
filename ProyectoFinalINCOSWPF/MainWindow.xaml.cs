using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAOSisVen;
using DAOSisVen.Implementation;
using DAOSisVen.Model;
// los objetitos de menu vistas
using ProyectoFinalINCOSWPF.ViewMenu;
using MaterialDesignThemes.Wpf;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

using System.Windows;

namespace ProyectoFinalINCOSWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = "Bienvenid@: "+SesionClass.SessionFullName +" "+"Rol: "+SesionClass.SessionRole+" ";
        }

        private void lvCambioContra_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            winCambioContra winContrasenia = new winCambioContra(); 
            this.Visibility = Visibility.Hidden;                    
            winContrasenia.Show();

        }

        private void lvUsuarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            winAdmUsuario winmain = new winAdmUsuario();
            this.Visibility = Visibility.Hidden;
            winmain.Show();
        }

        private void btnReporteGeneral_Click(object sender, RoutedEventArgs e)
        {
            Prueba_reporte reporteForms = new Prueba_reporte();
            reporteForms.Show();
        }
    }
}
