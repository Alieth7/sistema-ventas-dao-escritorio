using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using DAOSisVen.Model;

namespace DAOSisVen.Interfaces
{
    public interface IUsuario:IBase<Usuario>
    {
        DataTable SelectRecaudaciones();
        Usuario Get(byte id);  
        DataTable Login(string nombreUsuario,string contrasenia);
    }
}
