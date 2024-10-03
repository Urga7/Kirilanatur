using Kirilanatur.Server.Database;
using Kirilanatur.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kirilanatur.Server.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase {
    
        private readonly KirilanaturDbContext _dbContext;

        public UsersController(KirilanaturDbContext dbDbContext) {
            _dbContext = dbDbContext;
        }
        
        [HttpPost("AddUser"), Authorize]
        public async Task<ServerResponse> AddUser() {
            return new ServerResponse {
                Data = "Sucessfully added user",
            };
        }

        [HttpPost("Register")]
        public async Task<ServerResponse> Register() {
            return new ServerResponse {
                Data = "Sucessfully registered user",
            };
        }

    }
    
}
