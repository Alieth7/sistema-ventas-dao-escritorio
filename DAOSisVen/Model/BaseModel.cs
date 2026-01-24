using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOSisVen.Model
{
    public class BaseModel
    {
       

        public byte Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public byte IdUsuario { get; set; } 

        public BaseModel() { }

        public BaseModel(byte estado,DateTime fechaRegistro, DateTime fechaActualizacion, byte idUsuario)
        {
            Estado = estado;
            FechaRegistro = DateTime.Now;    
            FechaActualizacion = DateTime.Now;
        }

        public BaseModel(byte idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}
