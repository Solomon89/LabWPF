using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWPF.Models
{
    [Serializable]
    public class Line
    {
        public int Id { get; set; }
        public int TrasformatorA_id => TransformatorA.Id;
        public int TrasformatorB_id => TransformatorB.Id;
        public Transformator TransformatorA { get; set; }
        public Transformator TransformatorB { get; set; }

    }
}
