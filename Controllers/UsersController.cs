using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new();
        private static int id = 1;

        [HttpGet]
        public IActionResult GetAll() => Ok(users);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = id++;
            users.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updated)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            user.Name = updated.Name;
            user.Email = updated.Email;
            user.Age = updated.Age;

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            users.Remove(user);
            return Ok("Deleted");
        }
    }
}