using System.Collections.Generic;
using Biblioteka.Domain.Dto;
using Biblioteka.Service;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JezikController : ControllerBase
    {
        #region Fields

        private readonly IJezikService _jezikService;

        #endregion

        public JezikController(IJezikService jezikService)
        {
            _jezikService = jezikService;
        }

        [HttpGet()]
        public ActionResult<IList<JezikDto>> Get()
        {
            return Ok(_jezikService.GetAll());
        }
    }//class
}//namespace