using System.Threading.Tasks;
using System.Collections.Generic;
using GarbageArea.DomainObjects;
using GarbageArea.DomainObjects.Ports;
using GarbageArea.ApplicationServices.Ports;

namespace GarbageArea.ApplicationServices.GetAreaListUseCase
{
    public class GetAreaListUseCase : IGetAreaListUseCase
    {
        private readonly IReadOnlyAreaRepository _readOnlyAreaRepository;

        public GetAreaListUseCase(IReadOnlyAreaRepository readOnlyAreaRepository) 
            => _readOnlyAreaRepository = readOnlyAreaRepository;

        public async Task<bool> Handle(GetAreaListUseCaseRequest request, IOutputPort<GetAreaListUseCaseResponse> outputPort)
        {
            IEnumerable<Area> areas = null;
            if (request.AreaId != null)
            {
                var area = await _readOnlyAreaRepository.GetArea(request.AreaId.Value);
                areas = (area != null) ? new List<Area>() { area } : new List<Area>();
                
            }
            else if (request.AreaTypeId != null)
            {
                areas = await _readOnlyAreaRepository.QueryAreas(new AreaTypeCriteria(request.TypeId.Value));
            }
            else
            {
                areas = await _readOnlyAreaRepository.GetAllAreas();
            }
            outputPort.Handle(new GetAreaListUseCaseResponse(areas));
            return true;
        }
    }
}
