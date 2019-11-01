using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_API_UltraGym.Business;
using Backend_API_UltraGym.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_API_UltraGym.Controllers
{
    [Route("api/[controller]")]
    public class Users : Controller
    {
        // GET: api/<controller>
        [HttpGet("UserLogin")]
        public JsonResult LoginUser(string Email, string Password)
        {
            UserModel InfoUserLogin = new UserModel();

            InfoUserLogin = Users_Business.LoginUser(Email, Password);

            return Json(InfoUserLogin);
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
