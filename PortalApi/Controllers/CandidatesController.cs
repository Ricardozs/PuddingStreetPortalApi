using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PortalApi.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController : ControllerBase
    {
        

        [HttpPost(Name = "AddCandidate")]
        [Route("AddCandidate")]
        public bool UploadPdf()
        {
            return true;
        }

    }
    
}
