using System.Collections.Generic;
using Biblioteka.Domain.Dto;
using Biblioteka.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NaslovController : ControllerBase
    {
        private readonly INaslovService _naslovService;

        public NaslovController(INaslovService naslovService)
        {
            _naslovService = naslovService;
        }

        [HttpGet()]
        public ActionResult<IList<NaslovDto>> Get()
        {
            return Ok(_naslovService.GetAll());
        }

        [HttpGet("get/{id}")]
        public ActionResult<NaslovDto> Get(string id)
        {
            int idNaslova = int.Parse(id);
            return Ok(_naslovService.GetById(idNaslova));
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public ActionResult Add(NaslovDto value)
        {
            _naslovService.Add(value);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public ActionResult Update(NaslovDto value)
        {
            _naslovService.Update(value);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public ActionResult Delete(NaslovDto value)
        {
            _naslovService.Delete(value);
            return Ok();
        }
    }//class
}//namespace