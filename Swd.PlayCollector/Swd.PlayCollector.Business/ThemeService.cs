using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;

namespace Swd.PlayCollector.Business
{
    public class ThemeService
    {
        private IThemeRepository _IRepository;

        public ThemeService()
        {
            _IRepository = new ThemeRepository();
        }

        public async Task<IQueryable<Theme>> GetAllAsync()
        {
            
            var resultList = await _IRepository.GetAllAsync();
            return resultList;
        }
    }
}