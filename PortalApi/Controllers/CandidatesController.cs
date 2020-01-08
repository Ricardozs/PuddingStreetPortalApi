using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalApi.DTO;
using PortalApi.Interfaces;
using PortalApi.Requests;

namespace PortalApi.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController : ControllerBase
    {
        private readonly ISqlRepository SqlRepository;
        private readonly IMapper Mapper;

        public CandidatesController(ISqlRepository sqlRepository, IMapper mapper)
        {
            SqlRepository = sqlRepository;
            Mapper = mapper;
        }

        [HttpPost(Name = "AddCandidate")]
        [Route("AddCandidate")]
        public async Task<bool> AddCandidate(CandidateRequest candidate)
        {
            try
            {
                var newCandidate = Mapper.Map<Candidate>(candidate);
                var result = await SqlRepository.AddCandidate(newCandidate);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "GetCandidates")]
        [Route("GetCandidates")]
        public async Task<Candidate[]> GetCandidates()
        {
            try
            {
                var candidates = await SqlRepository.GetCandidates();
                return candidates.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    
}
