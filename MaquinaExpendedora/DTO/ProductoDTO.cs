using MaquinaExpendedora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaquinaExpendedora.DTO
{
    public class ProductoDTO
    {
        public string nombre_producto { get; set; }
        public float tamaño_producto { get; set; }
        public string marca_producto { get; set; }
        public float precio_producto { get; set; }
       // public int Pieza { get; set; }
    }
}
