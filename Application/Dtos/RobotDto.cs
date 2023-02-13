using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class RobotDto
    {
        public int Id { get; set; }
        public int HeadRotation { get; set; }
        public int HeadInclination { get; set; } 
        public int LeftElbow { get; set; }
        public int LeftFist { get; set; } 
        public int RightElbow { get; set; }
        public int RightFist { get; set; }
    }
}
