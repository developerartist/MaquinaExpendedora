using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Models
{
    public class Producto
    {
        public int Id_producto { get; set; }
        public string nombre_producto { get; set; }
        public float tamaño_producto { get; set; }
        public string marca_producto { get; set; }
        public float precio_producto { get; set; }
        public List<Pieza>? Piezas  { get; set; }

    }
}
