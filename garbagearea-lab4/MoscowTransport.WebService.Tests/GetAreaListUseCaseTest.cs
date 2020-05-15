using GarbageArea.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using GarbageArea.ApplicationServices.GetRouteListUseCase;
using System.Linq.Expressions;
using GarbageArea.ApplicationServices.Ports;
using GarbageArea.DomainObjects.Ports;
using GarbageArea.ApplicationServices.Repositories;

namespace GarbageArea.WebService.Core.Tests
{
    public class GetAreaListUseCaseTest
    {
        private InMemoryAreaRepository CreateAreaRepository(InMemoryAreaTypenRepository areaTypenRepository)
        {
            var transavtoliz = areaTypenRepository.GetAreaType(2).Result;
            var mosgortrans = areaTypenRepository.GetAreaType(1).Result;
            var repo = new InMemoryAreaRepository(new List<Area> {
                new Area { Id = 1, Number = "591", Name = "Метро \"Войковская\" - Станция Ховрино", Organization = transavtoliz, Type = TransportType.Bus },
                new Area { Id = 2, Number = "191", Name = "Метро \"Селигерская\" - Станция Ховрино", Organization = transavtoliz, Type = TransportType.Bus },
                new Area { Id = 3, Number = "215к", Name = "Метро \"Селигерская\" - Станция Ховрино", Organization = mosgortrans, Type = TransportType.Bus },
                new Area { Id = 4, Number = "56", Name = "Тверская Застава - Базовская улица", Organization = mosgortrans, Type = TransportType.Trolley },
            });
            return repo;
        }

        private InMemoryAreaTypenRepository CreateTransportOrganizationRepository()
            => new InMemoryAreaTypenRepository(new List<TransportOrganization> {
                new TransportOrganization
                { Id = 1, Name = "Мосгортранс", TimeZone = "Europe/Moscow", WebSite = "http://mosgortrans.ru" },
                new TransportOrganization
                { Id = 2, Name = "Трансавтолиз", TimeZone = "Europe/Moscow", WebSite = "http://avtoline.ru" }
               });

        [Fact]
        public void TestGetAllRoutes()
        {
            var useCase = new GetRouteListUseCase(CreateAreaRepository(CreateTransportOrganizationRepository()));
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetRouteListUseCaseRequest.CreateAllRoutesRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Routes.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Routes.Select(r => r.Id));
        }

        [Fact]
        public void TestGetAllRoutesFromEmptyRepository()
        {
            var useCase = new GetRouteListUseCase(new InMemoryAreaRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRouteListUseCaseRequest.CreateAllRoutesRequest(), outputPort).Result);
            Assert.Empty(outputPort.Routes);
        }

        [Fact]
        public void TestGetRoute()
        {
            var useCase = new GetRouteListUseCase(CreateAreaRepository(CreateTransportOrganizationRepository()));
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRouteListUseCaseRequest.CreateRouteRequest(2), outputPort).Result);
            Assert.Single(outputPort.Routes, r => 2 == r.Id);
        }

        [Fact]
        public void TestTryGetNotExistingRoute()
        {
            var useCase = new GetRouteListUseCase(CreateAreaRepository(CreateTransportOrganizationRepository()));
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRouteListUseCaseRequest.CreateRouteRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Routes);
        }

        [Fact]
        public void TestGetOrganizationRoutes()
        {
            var useCase = new GetRouteListUseCase(CreateAreaRepository(CreateTransportOrganizationRepository()));
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRouteListUseCaseRequest.CreateOrganizationRoutesRequest(1), outputPort).Result);
            Assert.Equal<int>(2, outputPort.Routes.Count());
            Assert.Equal(new long[] { 3, 4 }, outputPort.Routes.Select(r => r.Id));
        }

        [Fact]
        public void TestGetNonExistingOrganizationRoutes()
        {
            var useCase = new GetRouteListUseCase(CreateAreaRepository(CreateTransportOrganizationRepository()));
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetRouteListUseCaseRequest.CreateOrganizationRoutesRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Routes);
        }
    }

    class OutputPort : IOutputPort<GetRouteListUseCaseResponse>
    {
        public IEnumerable<Area> Routes { get; private set; }

        public void Handle(GetRouteListUseCaseResponse response)
        {
            Routes = response.Routes;
        }
    }
}
