using GarbageArea.DomainObjects;
using GarbageArea.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageArea.ApplicationServices.GetRouteListUseCase
{
    public class GetRouteListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Area> Routes { get; }

        public GetRouteListUseCaseResponse(IEnumerable<Area> routes) => Routes = routes;
    }
}
