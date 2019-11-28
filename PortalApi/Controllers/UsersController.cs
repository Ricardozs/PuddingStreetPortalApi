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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISqlRepository SqlRepository;

        public UsersController(ISqlRepository sqlRepository)
        {
            SqlRepository = sqlRepository;
        }

        [Route("NewUser")]
        [HttpPost(Name = "NewUser")]
        public bool NewUser(User user)
        {

            try
            {
                var response = SqlRepository.CreateUser(user);
                return response;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}