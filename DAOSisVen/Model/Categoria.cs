using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOSisVen.Model
{
    public class Categoria: BaseModel 
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
