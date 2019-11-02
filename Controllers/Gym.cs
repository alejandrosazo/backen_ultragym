using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_API_UltraGym.Business;
using Backend_API_UltraGym.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_API_UltraGym.Controllers
{
    [Route("api/[controller]")]
    public class Gym : Controller
    {
        // GET: api/<controller>
        [HttpGet("ReadAllGym")]
        public JsonResult ReadAllGym()
        {
           List<GymModel> InfoUserLogin = new List<GymModel>();

            InfoUserLogin = Gyms_Business.ReadAllGyms();

            return Json(InfoUserLogin);
        }

        // GET api/<controller>/5
        [HttpGet("ReadOneGym")]
        public JsonResult ReadOneGym(int IdGym)
        {
            var Values = Gyms_Business.ReadOneGyms(IdGym);

            List<GymModel> Gym = Values.Item1;
            List<CoachModel> Coach = Values.Item2;
            List<ClassModel> Class = Values.Item3;


            return Json((Gym, Coach, Class));
        }


        //METODOS POST
        // POST api/<controller>
        [HttpPost("RegisterClass")]
        public string RegisterClass([FromBody] ClassModel classe)
        {
            var Connection = new Gyms_Business();
            bool result = Connection.RegisterClass(classe);
            if (result == true)
            {
                return "Almacenado Correctamente";
            }
            else
            {
                return "Error al Amacenar";
            }

        }



        [HttpGet("ReadClaseGym")]
        public JsonResult ReadClaseGym(int idClase, int idUser)
        {
            ClassModel Clase = new ClassModel();

            Clase = Gyms_Business.ReadClassGym(idClase, idUser);

            return Json(Clase);
        }



        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
