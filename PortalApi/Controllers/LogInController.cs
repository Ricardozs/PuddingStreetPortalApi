using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalApi.DTO;
using PortalApi.Interfaces;

namespace PortalApi.Controllers
{
    [Route("api/logIn")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly IDbContext DbContext;

        public LogInController(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
        [HttpPost(Name = "Validate")]
        [Route("Validate")]
        public bool ValidateUser(string user, string password)
        {

            try
            {
                var response = DbContext.ValidatePassword(user, password);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}