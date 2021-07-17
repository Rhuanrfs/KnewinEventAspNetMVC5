using KnewinEventAsp.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnewinEventAsp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {

        private readonly ITeste _testeService;

        public TesteController(ITeste iTeste)
        {
            _testeService = iTeste;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Teste", " OK" };
        }
    }
}
