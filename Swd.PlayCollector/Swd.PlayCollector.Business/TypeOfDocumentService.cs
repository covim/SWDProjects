using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;

namespace Swd.PlayCollector.Business
{
    public class TypeOfDocumentService
    {
        private ITypeOfDocumentRepository _IRepository;

        public TypeOfDocumentService()
        {
            _IRepository = new TypeOfDocumentRepository();
        }

        public async Task AddAsync(TypeOfDocument typeOfDocument)
        {
            await _IRepository.AddAsync(typeOfDocument);
        }

        public async Task UpdateAsync(TypeOfDocument item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TypeOfDocument>> GetAllAsync()
        {
            var resultList = await _IRepository.GetAllAsync();
            return resultList;
        }

        public async Task<IQueryable<TypeOfDocument>> GetAllInklusiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}