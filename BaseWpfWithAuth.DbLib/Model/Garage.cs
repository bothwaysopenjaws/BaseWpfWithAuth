using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseWpfWithAuth.DbLib.Model
{
    public class Garage
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public  ObservableCollection<Car> Cars { get; set; }

        public Garage() => Cars = new();
    }
}
