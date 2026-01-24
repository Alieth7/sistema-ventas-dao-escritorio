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
using DAOSisVen;
using DAOSisVen.Model;
using DAOSisVen.Implementation;
using System.Data;


namespace ProyectoFinalINCOSWPF
{
    /// <summary>
    /// Lógica de interacción para winAdmUsuario.xaml
    /// </summary>
    public partial class winAdmUsuario : Window
    {
        byte opcion = 0;
        Usuario t;
        UsuarioImpl implUsuario;

        MessageBoxPerso mensajePersonalizado ;
        MessageBoxAlerta mensajeAlerta;


        public winAdmUsuario()
        {
            InitializeComponent();
            txtCi.Focus();
            DisableSave();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            MainWindow winmain = new MainWindow();
            winmain.Show();
        }

        void EnableSave()
        {
            btnInsert.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnUpdate.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;

            txtCi.IsEnabled = true;
            txtNombres.IsEnabled = true;
            txtPrimerAp.IsEnabled = true;
            txtSegundoAp.IsEnabled = true;
            txtFechaNacimiento.IsEnabled = true;
            txtSexo.IsEnabled = true;
            txtRol.IsEnabled = true;

            txtNombreUsuario.IsEnabled = false; 
            txtContrasenia.IsEnabled = false; 

            txtCi.Focus();
        }

        void DisableSave()
        {
            btnInsert.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;


            txtCi.Text = "";
            txtNombres.Text = "";
            txtPrimerAp.Text = "";
            txtSegundoAp.Text = "";
            txtFechaNacimiento.Text = "";
            txtSexo.Text = "";
            txtRol.Text = "";

            txtNombreUsuario.Text = "";
            txtContrasenia.Text = "";


            txtCi.IsEnabled = false;
            txtNombres.IsEnabled = false;
            txtPrimerAp.IsEnabled = false;
            txtSegundoAp.IsEnabled = false;
            txtFechaNacimiento.IsEnabled = false;
            txtSexo.IsEnabled = false;
            txtRol.IsEnabled = false;

            txtNombreUsuario.IsEnabled = false;
            txtContrasenia.IsEnabled = false;

            txtCi.Focus();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
           
            EnableSave();
            this.opcion = 1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {   
            EnableSave();
            this.opcion = 2;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DisableSave();
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {   
            switch (this.opcion) {
                case 1:

                    if (ciValido(txtCi.Text))
                    {
                        if (sonValidos(txtNombres.Text, txtPrimerAp.Text, txtSegundoAp.Text))
                        {
                            t = new Usuario(txtCi.Text, txtNombres.Text, txtPrimerAp.Text, txtSegundoAp.Text, DateTime.Parse(txtFechaNacimiento.Text), Char.Parse(txtSexo.Text), txtRol.Text, txtNombreUsuario.Text, txtContrasenia.Text);

                            try
                            {
                                implUsuario = new UsuarioImpl(); 
                                int n = implUsuario.Insert(t);   
                                if (n > 0)
                                {

                                    mensajePersonalizado = new MessageBoxPerso("Registro insertado con exito");
                                    mensajePersonalizado.ShowDialog();

                                    
                                    Select(); //refrescamos
                                    DisableSave();
                                }
                            }
                            catch (Exception ex)
                            {

                                mensajePersonalizado = new MessageBoxPerso(ex.Message);
                                mensajePersonalizado.ShowDialog();
                            }
                        }
                        else
                        {
                            mensajePersonalizado = new MessageBoxPerso("Por favor ingrese valores validos.");
                            mensajePersonalizado.ShowDialog();
                        }
                    }
                    else { 
                             mensajePersonalizado = new MessageBoxPerso("Por favor ingrese un CI valido.");
                             mensajePersonalizado.ShowDialog();
                    }

                     break;




                case 2:


                        try
                        {

                        if (t != null && dgvDatos.SelectedItem != null)
                            {

                            t.Ci = txtCi.Text;
                            t.Nombres = txtNombres.Text;
                            t.PrimerApellido = txtPrimerAp.Text;
                            t.SegundoApellido = txtSegundoAp.Text;
                            t.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                            t.Sexo = Char.Parse(txtSexo.Text);
                            t.Rol = txtRol.Text;
                            t.FechaActualizacion = DateTime.Now;


                            implUsuario = new UsuarioImpl();
                                int n = implUsuario.Update(t);
                                if (n > 0)
                                {
                                    mensajePersonalizado = new MessageBoxPerso("Registro actualizado con exito.");
                                    mensajePersonalizado.ShowDialog();

                                    Select();
                                    DisableSave();
                                }
                            }
                            else
                            { 

                                mensajePersonalizado = new MessageBoxPerso("Debe elegir el registro a actualizar");
                                mensajePersonalizado.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }

                    
                        break;
                    
            }
        }

        void Select()
        {
            try
            {
                implUsuario = new UsuarioImpl();
                dgvDatos.ItemsSource=null;
                dgvDatos.ItemsSource = implUsuario.Select().DefaultView;

                //ocultamos la columna del id
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed;

                //capturaremos el id

            }
            catch (Exception ex)
            {

                mensajePersonalizado = new MessageBoxPerso(ex .Message);
                mensajePersonalizado.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }


        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            if(dgvDatos.Items.Count>0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    DataRowView row = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(row.Row.ItemArray[0].ToString());

                    t = null;
                    implUsuario = new UsuarioImpl();
                    t = implUsuario.Get(id);

                    if (t != null)
                    {
                        txtCi.Text =        t.Ci;
                        txtNombres.Text =   t.Nombres;
                        txtPrimerAp.Text =  t.PrimerApellido;
                        txtSegundoAp.Text = t.SegundoApellido;
                        txtFechaNacimiento.Text = t.FechaNacimiento.ToString(); 
                        txtSexo.Text =      t.Sexo.ToString();
                        txtRol.Text=        t.Rol;

                        txtNombreUsuario.Text =  t.NombreUsuario;
                        txtContrasenia.Text=     t.Contrasenia;
                    }
                }
                catch (Exception ex)
                {

                    mensajePersonalizado = new MessageBoxPerso(ex.Message);
                    mensajePersonalizado.ShowDialog();
                }
                
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(t!=null &&dgvDatos.SelectedItem!=null){

                mensajeAlerta = new MessageBoxAlerta("Esta segur@ de eliminar el registro seleccionado?");
                mensajeAlerta.ShowDialog();

                if (mensajeAlerta.resultado){ 
                        
                    try
                    {
                        implUsuario = new UsuarioImpl(); 
                        int n = implUsuario.Delete(t);
                        if (n > 0)
                        {
                            mensajePersonalizado = new MessageBoxPerso("Registro eliminado con exito");
                            mensajePersonalizado.ShowDialog();

                            Select();

                            txtCi.Text = "";
                            txtNombres.Text = "";
                            txtPrimerAp.Text = "";
                            txtSegundoAp.Text = "";
                            txtFechaNacimiento.Text = "";
                            txtSexo.Text = "";
                            txtRol.Text = "";

                            txtCi.Focus();
                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else {
                       }
                
            }
            else { mensajePersonalizado = new MessageBoxPerso("Debe elegir el registro a eliminar");
                mensajePersonalizado.ShowDialog();
            }
        }

        private void btnGenerarUsuContra_Click(object sender, RoutedEventArgs e)
        {
            String nombre=txtNombres.Text;
            String apPaterno = txtPrimerAp.Text;
            String apMaterno = txtSegundoAp.Text;
            String fechaNac = txtFechaNacimiento.Text.ToString();
            String ci       =txtCi.Text;

            String nomUsuarioGene;
            String contrUsuarioGene;

            
            if (nombre.Length>=2 && apPaterno.Length>=2 && apMaterno.Length>=2 && fechaNac.Length>0) {
                nomUsuarioGene = nombre + apPaterno.Substring(0,1)+apMaterno.Substring(0,1)+ fechaNac.Substring(0,1);
                txtNombreUsuario.Text = nomUsuarioGene;
            }
            else
            {
                if(nombre.Length >= 3 && apPaterno.Length >= 3 && fechaNac.Length > 3)
                {
                    nomUsuarioGene = nombre + apPaterno.Substring(0, 1) + fechaNac.Substring(0,1);
                    txtNombreUsuario.Text = nomUsuarioGene;
                }
                else {
                    mensajePersonalizado = new MessageBoxPerso("Debe ingresar los datos para generar nombre de Usuario");
                    mensajePersonalizado.ShowDialog();
                }
            }

            if(nombre.Length >= 3 && ci.Length>=7 && fechaNac.Length > 0)
            {
                contrUsuarioGene = nombre.Substring(0, 1) + ci.Substring(0, 2) + fechaNac.Substring( 3, 2) + ci.Substring( 5, 2) + '-' + nombre.Substring(1,1);
                txtContrasenia.Text = contrUsuarioGene;
            }
            
            else {
                
                mensajePersonalizado = new MessageBoxPerso("Debe ingresar los datos del usuario, porfavor revise que sean correctos");
                mensajePersonalizado.ShowDialog();
            }
        }

        public bool ciValido(string ci)
        {
            if (ci.Length < 8)
            {
                return false;
            }

            for (int i = 0; i < ci.Length; i++)
            {
                if (i < 8 && !char.IsDigit(ci[i])) // Primeros 8 deben ser dígitos
                {
                    return false;
                }
                else if (i >= 8 && !char.IsLetter(ci[i])) // Resto debe ser letras o caracteres
                {
                    return false;
                }
            }

            return true;
        }


        public bool sonValidos(string nombres, string apPaterno, string apMaterno)
        {
            return ValidarSoloLetras(nombres) && ValidarSoloLetras(apPaterno) && ValidarSoloLetras(apMaterno);
        }
        


        private bool ValidarSoloLetras(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                if (!char.IsLetter(texto[i]))
                {
                    return false; // Si encuentra un carácter que no es letra retorna false
                }
            }
            return true; // Retorna true si todos los caracteres son letras solamente
        }
    }
}
