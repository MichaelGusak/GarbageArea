using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GarbageArea.DomainObjects;

namespace GarbageArea.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly ILogger<AreasController> _logger;

        public AreasController(ILogger<AreasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DomainObjects.GarbageArea> GetArea()
        {
            return new List<DomainObjects.GarbageArea>() 
            { 
                new DomainObjects.GarbageArea()
                {
                    Id = 1,
                    AreaNumber = "Контейнерная площадка №1987645",
                    AreaType = "Контейнерная площадка",
                    AreaSize = 18
                   }
            };
        }
    }
}
