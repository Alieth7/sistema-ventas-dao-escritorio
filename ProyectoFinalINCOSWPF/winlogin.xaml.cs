using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//
using DAOSisVen;
using DAOSisVen.Implementation;
using DAOSisVen.Model;

namespace ProyectoFinalINCOSWPF
{
    /// <summary>
    /// Lógica de interacción para winlogin.xaml
    /// </summary>
    public partial class winlogin : Window
    {
        public winlogin()
        {
            InitializeComponent();

            txtNombreUsuario.Focus();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UsuarioImpl implUsuario = new UsuarioImpl();
                DataTable table=implUsuario.Login(txtNombreUsuario.Text,txtContrasenia.Password);
                                                                                                     
                if (table.Rows.Count > 0)                                                            
                {  
                    SesionClass.SessionID = byte.Parse(table.Rows[0][0].ToString());
                    SesionClass.SessionFullName = table.Rows[0][1].ToString();
                    SesionClass.SessionRole = table.Rows[0][2].ToString();
                    SesionClass.SessionUserName = table.Rows[0][3].ToString();

                    SesionClass.SessionPassword = table.Rows[0][4].ToString();

                    if (SesionClass.SessionRole=="Administrador") {

                        MainWindow win = new MainWindow();
                        win.Show();

                        this.Visibility = Visibility.Hidden;
                        
                    }
                    else
                    {
                        if (SesionClass.SessionRole == "Cajero")
                        {
                            winCajero wincajero = new winCajero();
                            wincajero.Show();
                            this.Visibility = Visibility.Hidden;

                        }
                        else
                        {
                            MessageBox.Show("Rol no identificado, o no registrado");
                        }
                    }
                    
                }
                 else
                 {
                    lblInfo.Content="Nombre de usuario y/o contrasenia incorrectos";
                 }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void txtNombreUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIngresar_Click(sender, e);
            }
        }

        private void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIngresar_Click(sender, e);
            }
        }
    }
}
