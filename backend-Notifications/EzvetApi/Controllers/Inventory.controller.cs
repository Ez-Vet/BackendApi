using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EzvetApi.Models;


namespace EzvetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, FullName = "Diego Bastidas", Password = "Hola123", Speciality = "Groomer", Dni = "453212365", Email = "diego@correo.com", Phone = "980552320" },
            new User { Id = 2, FullName = "Carlos Rojas", Password = "password123", Speciality = "Medicina Interna", Dni = "12345678", Email = "carlosr@correo.com", Phone = "987654321" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers() => Ok(_users);

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User newUser)
        {
            newUser.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            user.FullName = updatedUser.FullName;
            user.Password = updatedUser.Password;
            user.Speciality = updatedUser.Speciality;
            user.Dni = updatedUser.Dni;
            user.Email = updatedUser.Email;
            user.Phone = updatedUser.Phone;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            _users.Remove(user);
            return NoContent();
        }   
    }

}