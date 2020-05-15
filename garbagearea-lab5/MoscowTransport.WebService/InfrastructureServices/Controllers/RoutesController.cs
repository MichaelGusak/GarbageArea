using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GarbageArea.DomainObjects;
using GarbageArea.ApplicationServices.GetRouteListUseCase;
using GarbageArea.InfrastructureServices.Presenters;

namespace GarbageArea.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ILogger<RoutesController> _logger;
        private readonly IGetRouteListUseCase _getRouteListUseCase;

        public RoutesController(ILogger<RoutesController> logger,
                                IGetRouteListUseCase getRouteListUseCase)
        {
            _logger = logger;
            _getRouteListUseCase = getRouteListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoutes()
        {
            var presenter = new RouteListPresenter();
            await _getRouteListUseCase.Handle(GetRouteListUseCaseRequest.CreateAllRoutesRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetRoute(long routeId)
        {
            var presenter = new RouteListPresenter();
            await _getRouteListUseCase.Handle(GetRouteListUseCaseRequest.CreateRouteRequest(routeId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult> GetOrganizationRoutes(long organizationId)
        {
            var presenter = new RouteListPresenter();
            await _getRouteListUseCase.Handle(GetRouteListUseCaseRequest.CreateOrganizationRoutesRequest(organizationId), presenter);
            return presenter.ContentResult;
        }
    }
}
