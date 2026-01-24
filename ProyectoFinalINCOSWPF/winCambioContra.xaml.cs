using DAOSisVen.Implementation;
using DAOSisVen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// Lógica de interacción para winCambioContra.xaml
    /// </summary>
    public partial class winCambioContra : Window
    {
        MessageBoxPerso mensajePer;
        public winCambioContra()
        {
            InitializeComponent();
        }
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            if (SesionClass.SessionRole == "Administrador")
            {

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
                    mensajePer = new MessageBoxPerso("Rol no identificado, o no registrado");
                    mensajePer.ShowDialog();
                }
            }
            this.Close();

        }

        private void btnCambiarContra_Click(object sender, RoutedEventArgs e)
        {
            UsuarioImpl implusuario = new UsuarioImpl();
            winlogin winlogin = new winlogin();

            string  contrActual = SesionClass.SessionPassword;
            string contrNueva = txtNewPassword.Password;      
            string contrNueva2 = txtNewPassword2.Password;      
           
            try
            {
                if (txtPassword.Password.Length != 0 && txtNewPassword.Password.Length != 0 && txtNewPassword2.Password.Length != 0)
                { 

                    if (txtPassword.Password == SesionClass.SessionPassword)
                    {
                        
                        if (esValido(contrNueva) && contrNueva == contrNueva2)
                        {
                            implusuario.cambiarContrasenia(contrNueva);
                            winlogin.Show();
                            this.Close();
                            mensajePer = new MessageBoxPerso("La contraseña fue actualizada");
                            mensajePer.ShowDialog();
                        }
                        else
                        {
                            if (esValido(contrNueva2) == false)
                            {
                                mensajeCard("Por favor ingrese una contraseña nueva valida.");
                                                                                             
                            }
                            else
                            {
                                mensajeCard("Las contraseñas no coinciden.");
                            }
                        }
                    }
                    else { mensajeCard("Las contraseña actual no coincide con la ingresada."); }
                }
                else { mensajeCard("Por favor, llene todos los campos"); }

            }
            catch (Exception ex)
            {
                mensajePer = new MessageBoxPerso(ex.Message);
                mensajePer.ShowDialog();
            }
        }
        
        public bool esValido(string contraseniaNueva)
        {
           
            bool numero = false;
            bool caracter = false;
            bool minuscula = false;
            bool mayuscula = false;


            for ( int i =0;i<contraseniaNueva.Length;i++) {

                if (Char.IsDigit(contraseniaNueva[i]))
                {
                    numero = true;
                }
                else
                {
                    if (Char.IsLower(contraseniaNueva[i])) {
                        minuscula = true;
                    }
                    else
                    {
                        if (Char.IsUpper(contraseniaNueva[i])) {
                            mayuscula= true;
                        }
                        else
                        {
                            caracter = true;
                        }
                    }
                }
            }

            if (contraseniaNueva.Length > 8 && numero && minuscula && mayuscula && caracter==true)
            {
                return true;
            }
             return false;
        }
        public void mensajeCard(string mensaje)
        {
            cardCambios.Content=mensaje;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnCambiarContra_Click(sender, e);
            }
        }

        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnCambiarContra_Click(sender, e);
            }
        }

        private void txtNewPassword2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnCambiarContra_Click(sender, e);
            }
        }
    }
}
