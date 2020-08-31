using System.Collections.Generic;
using Biblioteka.Domain.Dto;
using Biblioteka.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvidencijaDugovanjaController : ControllerBase
    {
        private readonly IEvidencijaDugovanjaService _evidencijaDugovanjaService;

        public EvidencijaDugovanjaController(IEvidencijaDugovanjaService evidencijaDugovanjaService)
        {
            _evidencijaDugovanjaService = evidencijaDugovanjaService;
        }

        [HttpGet]
        public ActionResult<IList<EvidencijaDugovanjaDto>> Get()
        {
            return Ok(_evidencijaDugovanjaService.GetAll());
        }

        [HttpGet("gettrenutnozaduzeno")]
        public ActionResult<IList<EvidencijaDugovanjaDto>> GetTrenutnoZaduzeno()
        {
            return Ok(_evidencijaDugovanjaService.GetTrenutnoZaduzeno());
        }


        [HttpGet("getbyclan/{id}")]
        public ActionResult<IList<EvidencijaDugovanjaDto>> GetByIdClan(string id)
        {
            int idClan = int.Parse(id);
            return Ok(_evidencijaDugovanjaService.GetByIdClan(idClan));
        }

        [HttpGet("getbynaslov/{id}")]
        public ActionResult<IList<EvidencijaDugovanjaDto>> GetByIdNaslov(string id)
        {
            int idClan = int.Parse(id);
            return Ok(_evidencijaDugovanjaService.GetByIdNaslov(idClan));
        }


        [HttpGet("get/{id}")]
        public ActionResult<EvidencijaDugovanjaDto> Get(string id)
        {
            int idEvidencije = int.Parse(id);
            return Ok(_evidencijaDugovanjaService.GetById(idEvidencije));
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public ActionResult Add(EvidencijaDugovanjaDto value)
        {
                _evidencijaDugovanjaService.Add(value);
                return Ok();
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public ActionResult Update(EvidencijaDugovanjaDto value)
        {
            _evidencijaDugovanjaService.Update(value);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public ActionResult Delete(EvidencijaDugovanjaDto value)
        {
            _evidencijaDugovanjaService.Delete(value);
            return Ok();
        }
    }//class
}//namespace