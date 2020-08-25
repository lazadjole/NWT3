using System.Collections.Generic;
using Biblioteka.Domain.Dto;
using Biblioteka.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClanController : ControllerBase
    {
        private readonly IClanService _clanService;

        public ClanController(IClanService clanService)
        {
            _clanService = clanService;
        }

        [HttpGet()]
        public ActionResult<IList<ClanDto>> Get()
        {
            return Ok(_clanService.GetAll());
        }

        [HttpGet("get/{id}")]
        public ActionResult<ClanDto> Get(string id)
        {
            int IdClana = int.Parse(id);
            return Ok(_clanService.GetById(IdClana));
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public ActionResult Add(ClanDto value)
        {
            _clanService.Add(value);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public ActionResult Update(ClanDto value)
        {
            _clanService.Update(value);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public ActionResult Delete(ClanDto value)
        {
            _clanService.Delete(value);
            return Ok();
        }
    }
}