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
    /// Lógica de interacción para MessageBoxPerso.xaml
    /// </summary>
    public partial class MessageBoxPerso : Window
    {
        public MessageBoxPerso(string mensajePer)
        {
            InitializeComponent();
            txt_Mensaje.Text = mensajePer;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
