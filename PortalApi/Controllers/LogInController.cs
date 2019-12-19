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
        private readonly ISqlRepository SqlRepository;

        public LogInController(ISqlRepository sqlRepository)
        {
            SqlRepository = sqlRepository;
        }
        [HttpPost(Name = "Validate")]
        [Route("Validate")]
        public async Task<bool> ValidateUser([FromBody]LogInData logInData)
        {

            try
            {
                var response = await SqlRepository.ValidatePassword(logInData);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}