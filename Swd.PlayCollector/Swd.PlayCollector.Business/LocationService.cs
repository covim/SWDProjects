using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;

namespace Swd.PlayCollector.Business
{
    public class LocationService
    {
        private ILocationRepository _IRepository;

        public LocationService()
        {
            _IRepository = new LocationRepository();
        }

        public async Task<IQueryable<Location>> GetAllAsync()
        {
            
            var resultList = await _IRepository.GetAllAsync();
            return resultList;
        }
    }
}