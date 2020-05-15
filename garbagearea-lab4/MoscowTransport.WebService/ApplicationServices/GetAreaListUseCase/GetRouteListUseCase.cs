using System.Threading.Tasks;
using System.Collections.Generic;
using GarbageArea.DomainObjects;
using GarbageArea.DomainObjects.Ports;
using GarbageArea.ApplicationServices.Ports;

namespace GarbageArea.ApplicationServices.GetRouteListUseCase
{
    public class GetRouteListUseCase : IGetRouteListUseCase
    {
        private readonly IReadOnlyRouteRepository _readOnlyRouteRepository;

        public GetRouteListUseCase(IReadOnlyRouteRepository readOnlyRouteRepository) 
            => _readOnlyRouteRepository = readOnlyRouteRepository;

        public async Task<bool> Handle(GetRouteListUseCaseRequest request, IOutputPort<GetRouteListUseCaseResponse> outputPort)
        {
            IEnumerable<Area> routes = null;
            if (request.RouteId != null)
            {
                var route = await _readOnlyRouteRepository.GetRoute(request.RouteId.Value);
                routes = (route != null) ? new List<Area>() { route } : new List<Area>();
                
            }
            else if (request.OrganizationId != null)
            {
                routes = await _readOnlyRouteRepository.QueryRoutes(new TransportOrganizationCriteria(request.OrganizationId.Value));
            }
            else
            {
                routes = await _readOnlyRouteRepository.GetAllAreas();
            }
            outputPort.Handle(new GetRouteListUseCaseResponse(routes));
            return true;
        }
    }
}
