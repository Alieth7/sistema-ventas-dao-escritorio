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
    /// Lógica de interacción para MessageBoxAlerta.xaml
    /// </summary>
    public partial class MessageBoxAlerta : Window
    {
        public bool resultado { get; private set; }
        public MessageBoxAlerta(string mensaje)
        {
            InitializeComponent();
            txt_AlertaSiNo.Text = mensaje;
        }

        private void btn_Si_Click(object sender, RoutedEventArgs e)
        {
            resultado = true;
            this.Close();
        }

        private void btn_No_Click(object sender, RoutedEventArgs e)
        {
            resultado = false;
            this.Close();
        }

        private void btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
