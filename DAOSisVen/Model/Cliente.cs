using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOSisVen.Model
{
    public class Cliente:BaseModel 
    {
        public short Id { get; set; }
        public string Nit {  get; set; }
        public string RazonSocial { get; set; }
    }
}
