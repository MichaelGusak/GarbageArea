using GarbageArea.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageArea.ApplicationServices.GetRouteListUseCase
{
    public class GetAreaListUseCaseRequest : IUseCaseRequest<GetAreaListUseCaseResponse>
    {
        public long? TypeId { get; private set; }
        public long? AreaId { get; private set; }

        private GetAreaListUseCaseRequest()
        { }

        public static GetAreaListUseCaseRequest CreateAllRoutesRequest()
        {
            return new GetAreaListUseCaseRequest();
        }

        public static GetAreaListUseCaseRequest CreateRouteRequest(long routeId)
        {
            return new GetAreaListUseCaseRequest() { AreaId = routeId };
        }
        public static GetAreaListUseCaseRequest CreateOrganizationRoutesRequest(long organizationId)
        {
            return new GetAreaListUseCaseRequest() { OrganizationId = organizationId };
        }
    }
}
