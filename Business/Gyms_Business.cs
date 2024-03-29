﻿using Backend_API_UltraGym.Connection;
using Backend_API_UltraGym.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_API_UltraGym.Business
{
    public class Gyms_Business
    {


        //METODO PARA LEER EN LA BASE DE DATOS

        //LEER LISTADO DE TODOS LOS GIMNASIOS
        public static List<GymModel> ReadAllGyms()
        {
           
            var Connect = Db_Connection.ConexionSQL();
            //ABRIMOS LA CONEXION
            Connect.Open();

            //QUERY QUE SE EJECUTARA EN LA BASE DE DATOS
            var QueryC = new SqlCommand("EXECUTE ReadAllGyms;", Connect);
            //CREAMOS UN ADAPTADOR PARA LA CONSULTA

            SqlDataReader ResultSet = QueryC.ExecuteReader(); ;
            //INICIAMOS EL MODELO

            List<GymModel> resultGym = new List<GymModel>();

            while (ResultSet.Read())
            {

                GymModel InfoGym = new GymModel();
                //LLENAMOS EL MODELO CON LOS DATOS EXTRAIDOS
                InfoGym.Id_Gym = int.Parse(ResultSet["Id_Gym"].ToString());
                InfoGym.Gym_Campus = ResultSet["Gym_Campus"].ToString();
                InfoGym.Gym_Address = ResultSet["Gym_Address"].ToString();
                InfoGym.Gym_Phone = ResultSet["Gym_Phone"].ToString();
                InfoGym.Gym_Income = int.Parse(ResultSet["Gym_Income"].ToString());
                InfoGym.Gym_Email = ResultSet["Gym_Email"].ToString();

                resultGym.Add(InfoGym);
            }
            Connect.Close();
            return resultGym;
        }



        public static ClassModel ReadClassGym(int idClas, int idUser, int idGym)
        {
            string Query = "EXECUTE ReadClassUser '" + idUser + "','" + idClas + "','" + idGym + "';";

            //CREAMOS UN ADAPTADOR PARA LA CONSULTA

            var ResultSet = Db_Connection.ReaderDatabase(Query); ;
            //INICIAMOS EL MODELO
            ClassModel Clase = new ClassModel();

            //LLENAMOS EL MODELO CON LOS DATOS EXTRAIDOS
            Clase.Id_Class = int.Parse(ResultSet.Rows[0]["Id_UserClass"].ToString());
           


            return Clase;
        }



        public static List<UserClassModel> ReadClassUserGym(int idUser)
        {
            var Connect = Db_Connection.ConexionSQL();
            //ABRIMOS LA CONEXION
            Connect.Open();

            //QUERY QUE SE EJECUTARA EN LA BASE DE DATOS
            var QueryC = new SqlCommand("EXECUTE ReadClassGymUser '" + idUser + "';", Connect);
            //CREAMOS UN ADAPTADOR PARA LA CONSULTA

            SqlDataReader ResultSet = QueryC.ExecuteReader(); ;
            //INICIAMOS EL MODELO

            List<UserClassModel> result = new List<UserClassModel>();
           
            while (ResultSet.Read())
            {

                UserClassModel UserClass = new UserClassModel();

                //LLENAMOS EL MODELO CON LOS DATOS EXTRAIDOS
                UserClass.Id_Class = int.Parse(ResultSet["Id_Class"].ToString());
                UserClass.Id_Gym = int.Parse(ResultSet["Id_Gym"].ToString());
                UserClass.Id_User = int.Parse(ResultSet["Id_User"].ToString());
                UserClass.Id_Coach = int.Parse(ResultSet["Id_Coach"].ToString());
                UserClass.Class_Name = ResultSet["Class_Name"].ToString();
                UserClass.Class_Inscribed = int.Parse(ResultSet["Class_Inscribed"].ToString());
                UserClass.Class_Hour = ResultSet["Class_Hour"].ToString();
                UserClass.Coach_Name = ResultSet["Coach_Name"].ToString();
                UserClass.Gym_Campus = ResultSet["Gym_Campus"].ToString();
                UserClass.Gym_Address = ResultSet["Gym_Address"].ToString();
                UserClass.Gym_Phone = ResultSet["Gym_Phone"].ToString();
                
                result.Add(UserClass);
            }
            Connect.Close();
            return result;
        }




        //LEER GIMNASIO SELECCIONADO
        public static Tuple<List<GymModel>, List<CoachModel>, List<ClassModel>> ReadOneGyms(int IdGym)
        {

            var Connect = Db_Connection.ConexionSQL();
            //ABRIMOS LA CONEXION
            Connect.Open();

            //QUERY QUE SE EJECUTARA EN LA BASE DE DATOS
            var QueryC = new SqlCommand("EXECUTE ReadOneGym '" + IdGym + "';" , Connect);
            //CREAMOS UN ADAPTADOR PARA LA CONSULTA

            SqlDataReader ResultSet = QueryC.ExecuteReader(); ;
            //INICIAMOS EL MODELO

            List<GymModel> resultGym = new List<GymModel>();
            List<CoachModel> resultCoach = new List<CoachModel>();
            List<ClassModel> resultClass = new List<ClassModel>();

            while (ResultSet.Read())
            {

                GymModel InfoGym = new GymModel();
                CoachModel InfoCoach = new CoachModel();
                ClassModel InfoClass = new ClassModel();

                //LLENAMOS EL MODELO CON LOS DATOS EXTRAIDOS
                InfoGym.Id_Gym = int.Parse(ResultSet["Id_Gym"].ToString());
                InfoGym.Gym_Campus = ResultSet["Gym_Campus"].ToString();
                InfoGym.Gym_Address = ResultSet["Gym_Address"].ToString();
                InfoGym.Gym_Phone = ResultSet["Gym_Phone"].ToString();
                InfoGym.Gym_Income = int.Parse(ResultSet["Gym_Income"].ToString());
                InfoGym.Gym_Email = ResultSet["Gym_Email"].ToString();
                
                InfoClass.Id_Class = int.Parse(ResultSet["Id_Class"].ToString());
                InfoClass.Id_Coach_Class = int.Parse(ResultSet["Id_Coach_Class"].ToString());
                InfoClass.Class_Name = ResultSet["Class_Name"].ToString();
                InfoClass.Class_Limit = int.Parse(ResultSet["Class_Limit"].ToString());
                InfoClass.Class_Inscribed = int.Parse(ResultSet["Class_Inscribed"].ToString());
                InfoClass.Class_Hour = ResultSet["Class_Hour"].ToString();
                InfoClass.Class_Duration = int.Parse(ResultSet["Class_Duration"].ToString());

                InfoCoach.Id_Coach = int.Parse(ResultSet["Id_Coach"].ToString());
                InfoCoach.Coach_Name = ResultSet["Coach_Name"].ToString();

                resultGym.Add(InfoGym);
                resultClass.Add(InfoClass);
                resultCoach.Add(InfoCoach);
            }
            Connect.Close();
            return Tuple.Create(resultGym, resultCoach, resultClass);
        }



        //REGISTRAR CLASE
        public bool RegisterClass(ClassModel classe)
        {
            //CREAMOS LA CONEXION A LA BASE DE DATOS
            var Connect = Db_Connection.ConexionSQL();

            //QUERY QUE SE EJECUTARA EN LA BASE DE DATOS
            var Query = new SqlCommand("EXECUTE InscribedClass '" + classe.Id_Class + "','" +  classe.Id_Coach_Class + "','" + classe.Class_Limit + "';", Connect);

            try
            {
                //ABRIMOS LA CONEXION
                Connect.Open();
                Query.ExecuteNonQuery();
                Connect.Close();
                return true;
            }
            catch (SqlException ex)
            {
                var exc = ex;
                Connect.Close();
                return false;
            }
        }

    }
}

