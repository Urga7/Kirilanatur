using Kirilanatur.Server.Database;
using Kirilanatur.Server.Database.Models;
using Kirilanatur.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase {
    
        private readonly KirilanaturDbContext _dbContext;
        private readonly UserManager<KirilanaturUser> _userManager;

        public UsersController(KirilanaturDbContext dbDbContext, UserManager<KirilanaturUser> userManager) {
            _dbContext = dbDbContext;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<ServerResponse> Register([FromBody] UserDto user)
        {
            KirilanaturUser newUser = new KirilanaturUser {
                FirstName = user.Name,
                LastName = user.Surname,
                Email = user.Email,
                UserName = user.Email
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
                return new ServerResponse { Data = "Successfully registered user" };

            return new ServerResponse {
                Data = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

    }
    
}
