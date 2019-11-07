using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_API_UltraGym.Models
{
    public class UserClassModel
    {
        public int Id_Class { get; set; }
        public int Id_Gym { get; set; }
        public int Id_User { get; set; }
        public int Id_Coach { get; set; }
        public string Class_Name { get; set; }
        public int Class_Inscribed { get; set; }
        public string Class_Hour { get; set; }
        public string Coach_Name { get; set; }
        public string Gym_Campus { get; set; }
        public string Gym_Address { get; set; }
        public string Gym_Phone { get; set; }
    }
}
