using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoyectoCRUD_2_6.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public float Precio { get; set; }
    }
}