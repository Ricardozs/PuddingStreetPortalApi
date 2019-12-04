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
    [Route("api/competencies")]
    [ApiController]
    public class CompetenciesController : ControllerBase
    {
        private readonly ISqlRepository SqlRepository;

        public CompetenciesController(ISqlRepository sqlRepository)
        {
            SqlRepository = sqlRepository;
        }

        [Route("GetCompetencies")]
        [HttpGet(Name = "GetCompetencies")]
        public CompetenciesTotal[] GetCompetencies()
        {
            try
            {
                return SqlRepository.GetCompetencies().ToArray();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}