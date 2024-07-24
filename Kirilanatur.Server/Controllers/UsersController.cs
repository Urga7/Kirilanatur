using Microsoft.AspNetCore.Mvc;

namespace Kirilanatur.Server.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase {

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto user) {
            
            // Logic to add user
            string message = $"User {user.Name} {user.Surname} added successfully";
            return Ok(new { message });
            
        }
        
    }

    public class UserDto {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    
}
