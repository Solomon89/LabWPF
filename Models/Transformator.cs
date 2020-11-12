using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWPF.Models
{
    [Serializable]
    public class Transformator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Voltage { get; set; }
        public double Resistance { get; set; }



    }
}
