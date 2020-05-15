using GarbageArea.ApplicationServices.GetRouteListUseCase;
using System.Net;
using Newtonsoft.Json;
using GarbageArea.ApplicationServices.Ports;

namespace GarbageArea.InfrastructureServices.Presenters
{
    public class AreaListPresenter : IOutputPort<GetAreaListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public AreaListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetAreaListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Routes) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
