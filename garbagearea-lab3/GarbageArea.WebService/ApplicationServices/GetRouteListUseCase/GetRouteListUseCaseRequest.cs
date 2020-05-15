using MoscowTransport.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowTransport.ApplicationServices.GetRouteListUseCase
{
    public class GetRouteListUseCaseRequest : IUseCaseRequest<GetRouteListUseCaseResponse>
    {
        public long? OrganizationId { get; private set; }
        public long? RouteId { get; private set; }

        private GetRouteListUseCaseRequest()
        { }

        public static GetRouteListUseCaseRequest CreateAllRoutesRequest()
        {
            return new GetRouteListUseCaseRequest();
        }

        public static GetRouteListUseCaseRequest CreateRouteRequest(long routeId)
        {
            return new GetRouteListUseCaseRequest() { RouteId = routeId };
        }
        public static GetRouteListUseCaseRequest CreateOrganizationRoutesRequest(long organizationId)
        {
            return new GetRouteListUseCaseRequest() { OrganizationId = organizationId };
        }
    }
}
