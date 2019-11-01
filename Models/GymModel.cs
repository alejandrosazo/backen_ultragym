using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_API_UltraGym.Models
{
    public class GymModel
    {
        public int Id_Gym { get; set; }
        public string Gym_Campus { get; set; }
        public string Gym_Address { get; set; }
        public string Gym_Phone { get; set; }
        public int Gym_Income { get; set; }
        public string Gym_Email { get; set; }
    }
}
