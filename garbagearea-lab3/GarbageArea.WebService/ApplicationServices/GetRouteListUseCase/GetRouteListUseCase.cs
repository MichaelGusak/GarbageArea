using System.Threading.Tasks;
using System.Collections.Generic;
using MoscowTransport.DomainObjects;
using MoscowTransport.DomainObjects.Ports;
using MoscowTransport.ApplicationServices.Ports;

namespace MoscowTransport.ApplicationServices.GetRouteListUseCase
{
    public class GetRouteListUseCase : IGetRouteListUseCase
    {
        private readonly IReadOnlyRouteRepository _readOnlyRouteRepository;

        public GetRouteListUseCase(IReadOnlyRouteRepository readOnlyRouteRepository) 
            => _readOnlyRouteRepository = readOnlyRouteRepository;

        public async Task<bool> Handle(GetRouteListUseCaseRequest request, IOutputPort<GetRouteListUseCaseResponse> outputPort)
        {
            IEnumerable<Route> routes = null;
            if (request.RouteId != null)
            {
                var route = await _readOnlyRouteRepository.GetRoute(request.RouteId.Value);
                routes = (route != null) ? new List<Route>() { route } : new List<Route>();
                
            }
            else if (request.OrganizationId != null)
            {
                routes = await _readOnlyRouteRepository.QueryRoutes(new TransportOrganizationCriteria(request.OrganizationId.Value));
            }
            else
            {
                routes = await _readOnlyRouteRepository.GetAllRoutes();
            }
            outputPort.Handle(new GetRouteListUseCaseResponse(routes));
            return true;
        }
    }
}
