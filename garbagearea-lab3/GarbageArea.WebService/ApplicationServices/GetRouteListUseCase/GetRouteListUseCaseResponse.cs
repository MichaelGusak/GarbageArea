using MoscowTransport.DomainObjects;
using MoscowTransport.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowTransport.ApplicationServices.GetRouteListUseCase
{
    public class GetRouteListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Route> Routes { get; }

        public GetRouteListUseCaseResponse(IEnumerable<Route> routes) => Routes = routes;
    }
}
