using Backend_API_UltraGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Backend_API_UltraGym.Connection;

namespace Backend_API_UltraGym.Business
{
    public class Users_Business
    {

        //METODO PARA LEER EN LA BASE DE DATOS
        
            //LEER REGISTRO DE USUARIOS LOGEADOS
        public static UserModel LoginUser(string Email, string Password)
        {
            string Query = "EXECUTE LoginUsers '" + Email + "','" + Password + "';";

            //CREAMOS UN ADAPTADOR PARA LA CONSULTA
           
            var ResultSet = Db_Connection.ReaderDatabase(Query); ;
            //INICIAMOS EL MODELO
            UserModel InfoUserLogin = new UserModel();

            //LLENAMOS EL MODELO CON LOS DATOS EXTRAIDOS
            InfoUserLogin.Id_User = int.Parse(ResultSet.Rows[0]["Id_User"].ToString());
            InfoUserLogin.Id_Status = int.Parse(ResultSet.Rows[0]["Id_Status"].ToString());
            InfoUserLogin.Id_Payment = int.Parse(ResultSet.Rows[0]["Id_Payment"].ToString());
            InfoUserLogin.LargeName = ResultSet.Rows[0]["Nombre"].ToString();
            InfoUserLogin.User_Age = int.Parse(ResultSet.Rows[0]["User_Age"].ToString());
            InfoUserLogin.User_Adress = ResultSet.Rows[0]["User_Adress"].ToString();
            InfoUserLogin.User_Dpi = ResultSet.Rows[0]["User_Dpi"].ToString();
            InfoUserLogin.User_Phone = ResultSet.Rows[0]["User_Phone"].ToString();
            InfoUserLogin.User_Email = ResultSet.Rows[0]["User_Email"].ToString();
            InfoUserLogin.User_Password = ResultSet.Rows[0]["User_Password"].ToString();


            return InfoUserLogin;
        }



    }
}
