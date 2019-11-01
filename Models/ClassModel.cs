using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_API_UltraGym.Models
{
    public class ClassModel
    {
        public int Id_Class { get; set; }
        public int Id_Coach_Class { get; set; }
        public int Class_Limit { get; set; }
        public int Class_Inscribed { get; set; }
        public string Class_Name { get; set; }
        public int Class_Duration { get; set; }
        public string Class_Hour { get; set; }
    }
}
