using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ROBO")]
    public class Robot
    {
        public int Id { get; set; }
        public int HeadRotation { get; set; }
        public int HeadInclination { get; set;}
        public int LeftElbow { get; set; }
        public int LeftFist { get; set; }
        public int RightElbow { get; set; }
        public int RightFist { get; set; }

    }
}
