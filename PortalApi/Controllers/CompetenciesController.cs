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
        public async Task<CompetenciesTotal[]> GetCompetencies()
        {
            try
            {
                var result = await SqlRepository.GetCompetencies();
                return result.ToArray();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Route("AddCompetency")]
        [HttpPost(Name = "AddCompetency")]
        public async Task<bool> AddCompetency([FromBody] Competency competency)
        {
            try
            {
                var result = await SqlRepository.AddCompetency(competency.Name);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}