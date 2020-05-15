using GarbageArea.ApplicationServices.GetRouteListUseCase;
using System.Net;
using Newtonsoft.Json;
using GarbageArea.ApplicationServices.Ports;

namespace GarbageArea.InfrastructureServices.Presenters
{
    public class RouteListPresenter : IOutputPort<GetRouteListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RouteListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetRouteListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Routes) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
