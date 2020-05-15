using GarbageArea.DomainObjects;
using GarbageArea.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageArea.ApplicationServices.GetAreaListUseCase
{
    public class GetAreaListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Area> Areas { get; }

        public GetAreaListUseCaseResponse(IEnumerable<Area> routes) => Areas = routes;
    }
}
