using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseWpfWithAuth.DbLib.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [ForeignKey(nameof(Garage))]
        public int? GarageId { get; set; }

        public  Garage? Garage { get; set; }
    }
}
