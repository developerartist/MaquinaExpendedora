using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Models
{
    public class Pieza
    {
        [Key]
        public int Id_Pieza { get; set; }
        public int total_piezas { get; set; }
        public int Id_producto { get; set; }
    }
}
