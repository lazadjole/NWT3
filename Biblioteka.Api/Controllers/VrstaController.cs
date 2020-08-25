using System.Collections.Generic;
using Biblioteka.Domain.Dto;
using Biblioteka.Service;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VrstaController : ControllerBase
    {
        private readonly IVrstaService _vrstaService;

        public VrstaController(IVrstaService vrstaService)
        {
            _vrstaService = vrstaService;
        }


        [HttpGet()]
        public ActionResult<IList<VrstaDto>> Get()
        {
            return Ok(_vrstaService.GetAll());
        }
    }//class
}//namespace