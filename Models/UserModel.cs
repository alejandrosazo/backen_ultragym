using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_API_UltraGym.Models
{
    public class UserModel
    {
        public int Id_User { get; set; }
        public int Id_Status { get; set; }
        public int Id_Payment { get; set; }
        public string LargeName { get; set; }
        public string User_FirstName { get; set; }
        public string User_SecondName { get; set; }
        public string User_FirstLastname { get; set; }
        public string User_SecondLastname { get; set; }
        public int User_Age { get; set; }
        public string User_Adress { get; set; }
        public string User_Dpi { get; set; }
        public string User_Phone { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        

    }
}
