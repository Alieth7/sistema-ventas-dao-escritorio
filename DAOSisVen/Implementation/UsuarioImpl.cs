using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAOSisVen.Interfaces;
using DAOSisVen.Model;
using MySql.Data.MySqlClient;

namespace DAOSisVen.Implementation
{
    
    public class UsuarioImpl : BaseImpl,IUsuario 
    {
        public int Delete(Usuario t)
        {
            query = @"UPDATE usuario SET estado=0,fechaActualizacion=current_timestamp(),idUsuario=@idUsuario
                      WHERE id=@id;";

            
            MySqlCommand command = CreateBasicCommand(query);
            
            command.Parameters.AddWithValue("@idUsuario", SesionClass.SessionID);
            command.Parameters.AddWithValue("@id", t.Id);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public Usuario Get (byte id)
        {
             Usuario t = null;

             query = @" select id,  ci  ,nombres, primerApellido,segundoApellido,fechaNacimiento,sexo,rol,nombreUsuario,contrasenia,estado,IFNULL(fechaRegistro,CURRENT_TIMESTAMP),IFNULL(fechaActualizacion,CURRENT_TIMESTAMP),idUsuario
                         from Usuario
                         where id=@id;";

             MySqlCommand command =CreateBasicCommand(query);
             command.Parameters.AddWithValue("@id",id);
             try
             {
                 DataTable table = ExecuteDataTableCommand(command);

                  if (table.Rows.Count>0) 
                  {
                    
                    t = new Usuario(byte.Parse(table.Rows[0][0].ToString()),
                                    table.Rows[0][1].ToString(),
                                    table.Rows[0][2].ToString(),
                                    table.Rows[0][3].ToString(),
                                    table.Rows[0][4].ToString(),
                      DateTime.Parse(table.Rows[0][5].ToString()),
                          Char.Parse(table.Rows[0][6].ToString()),
                                    table.Rows[0][7].ToString(),
                                    table.Rows[0][8].ToString(),
                                    table.Rows[0][9].ToString(),
                        byte.Parse(table.Rows[0][10].ToString()),
                     DateTime.Parse(table.Rows[0][11].ToString()),
                     DateTime.Parse(table.Rows[0][12].ToString()),
                        byte.Parse(table.Rows[0][13].ToString()));

               }
           }
           catch (Exception ex)
           {

               throw ex;
          }
           return t;
         }

        public int Insert(Usuario t)
        {
            query = @"INSERT INTO usuario (ci,nombres,primerApellido,segundoApellido,fechaNacimiento,sexo,rol,nombreUsuario,contrasenia,idUsuario)
                    values(@ci,@nombres,@primerApellido,@segundoApellido,@fechaNacimiento,@sexo,@rol,@nombreUsuario,@contrasenia,@idUsuario)";
            MySqlCommand command= CreateBasicCommand(query); 
            command.Parameters.AddWithValue("@ci",t.Ci);  
            command.Parameters.AddWithValue("@nombres",t.Nombres);
            command.Parameters.AddWithValue("@primerApellido",t.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido",t.SegundoApellido);
            command.Parameters.AddWithValue("@fechaNacimiento",t.FechaNacimiento);
            command.Parameters.AddWithValue("@sexo",t.Sexo);
            command.Parameters.AddWithValue("@rol",t.Rol);
            command.Parameters.AddWithValue("@nombreUsuario",t.NombreUsuario);
            command.Parameters.AddWithValue("@contrasenia",t.Contrasenia);
            command.Parameters.AddWithValue("@idUsuario", SesionClass.SessionID ); 

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @" SELECT id, ci as Ci, nombres as Nombres, primerApellido as ""Primer Apellido:"", segundoApellido as ""Segundo Apellido:"",fechaNacimiento as ""Fecha de nacimiento:"",
                              sexo as Sexo ,rol as Rol,nombreUsuario as ""Nombre de usuario:"",fechaRegistro as ""Creado en:"",fechaActualizacion as ""Actualizado en:""
                       FROM usuario
                       WHERE estado = 1
                       ORDER BY 2;";
            MySqlCommand command= CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable SelectRecaudaciones()
        {
            throw new NotImplementedException();
        }


        public int Update(Usuario t)
        {
            query = @"UPDATE usuario SET ci=@ci,nombres=@nombres,primerApellido=@primerApellido,
                                         segundoApellido=@segundoApellido,fechaNacimiento=@fechaNacimiento,
                                         sexo=@sexo,rol=@rol,fechaActualizacion=current_timestamp(),idUsuario=@idUsuario
                                     WHERE id=@id;";

            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@nombres", t.Nombres);
            command.Parameters.AddWithValue("@primerApellido", t.PrimerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.SegundoApellido);
            command.Parameters.AddWithValue("@fechaNacimiento", t.FechaNacimiento);
            command.Parameters.AddWithValue("@sexo", t.Sexo);
            command.Parameters.AddWithValue("@rol", t.Rol);
            command.Parameters.AddWithValue("@idUsuario", SesionClass.SessionID);
                                                             
            command.Parameters.AddWithValue("@id",t.Id);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex )
            {

                throw ex;
            }

        }
        public DataTable Login(string nombreUsuario, string contrasenia) 
        {
            query = @" SELECT id, concat(nombres,' ',primerApellido) as Nombres,rol,nombreUsuario,contrasenia
                        FROM usuario
                        WHERE estado= 1 AND nombreUsuario=@nombreUsuario AND contrasenia=@contrasenia;"; 


            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombreUsuario",nombreUsuario);
            command.Parameters.AddWithValue("@contrasenia",contrasenia);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       public int cambiarContrasenia( string contrasenianueva)
        {
            query = @" UPDATE usuario
                       SET contrasenia=@contraseniaNueva
                       WHERE id=@id;";

            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", SesionClass.SessionID);  //al id actual
            command.Parameters.AddWithValue("@contraseniaNueva", contrasenianueva);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public DataTable filtrarRol(string rol)
        {
            query = @"  Select id, ci as Ci, nombres as Nombres, primerApellido as ""Primer Apellido:"", segundoApellido as ""Segundo Apellido:"",fechaNacimiento as ""Fecha de nacimiento:"",
                            sexo as Sexo ,rol as Rol,nombreUsuario as ""Nombre de usuario:"",fechaRegistro as ""Creado en:"",fechaActualizacion as ""Actualizado en:""
                        FROM usuario
                        WHERE rol = @rol;";

            MySqlCommand command = CreateBasicCommand( query);
            command.Parameters.AddWithValue("@rol", rol);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                 throw ex;
            }

        }
        
    }
}
