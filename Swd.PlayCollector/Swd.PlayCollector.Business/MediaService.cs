using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;

namespace Swd.PlayCollector.Business
{
    public class MediaService
    {
        private IMediaRepository _IRepository;

        public MediaService()
        {
            _IRepository = new MediaRepository();
        }

        public async Task AddAsync(Media media)
        {
            await _IRepository.AddAsync(media);
        }

        public async Task UpdateAsync(Media item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Media>> GetAllAsync()
        {
            var resultList = await _IRepository.GetAllAsync();
            return resultList;
        }

        public async Task<IQueryable<Media>> GetAllInklusiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}