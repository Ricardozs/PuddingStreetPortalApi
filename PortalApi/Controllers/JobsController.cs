using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalApi.DTO;
using PortalApi.Interfaces;
using PortalApi.Requests;

namespace PortalApi.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ISqlRepository SqlRepository;
        private readonly IMapper Mapper;

        public JobsController(ISqlRepository sqlRepository, IMapper mapper)
        {
            SqlRepository = sqlRepository;
            Mapper = mapper;
        }

        [Route("AddJob")]
        [HttpPost(Name = "AddJob")]
        public async Task<bool> AddJob([FromBody]JobRequest job)
        {
            try
            {
                var newJob = Mapper.Map<Job>(job);
                var result = await SqlRepository.AddJob(newJob);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("GetJobs")]
        [HttpGet(Name = "GetJobs")]
        public async Task<string[]> GetJobs()
        {
            var jobs = new List<string>();
            try
            {
                jobs = await SqlRepository.GetJobs();
                return jobs.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}