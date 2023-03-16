using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;

namespace Swd.PlayCollector.Business
{
    public class CollectionItemService
    {
        private ICollectionItemRepository _IRepository;

        public CollectionItemService()
        {
            _IRepository = new CollectionItemRepository();
        }

        public async Task AddAsync(CollectionItem item)
        {
            await _IRepository.AddAsync(item);
        }

        public async Task UpdateAsync(CollectionItem item)
        {
            await _IRepository.UpdateAsync(item, item.Id);
        }

        public async Task DeleteAsync(int id)
        {
            await _IRepository.DeleteAsync(id);
        }

        public async Task<IQueryable<CollectionItem>> GetAllAsync()
        {

            var resultList = await _IRepository.GetAllAsync();
            return resultList;
        }

        public async Task<IQueryable<CollectionItem>> GetAllInklusiveAsync()
        {
            //CollectionItemRepository repository = new CollectionItemRepository();
            var resultList = await _IRepository.GetAllInklusiveAsync();
            return resultList;
        }

        public async Task AddMediaItems(IEnumerable<string> sourceFilePathes, CollectionItem collectionItem)
        {

            if (collectionItem != null)
            {
                foreach (var sourceFilePath in sourceFilePathes)
                {
                    string trargetFile = await CopyFile(sourceFilePath, collectionItem.Id);
                    string fileExtension = Path.GetExtension(trargetFile);
                    TypeOfDocumentService typeOfDocumentService = new TypeOfDocumentService();

                    Media media = new Media
                    {
                        Name = Path.GetFileName(trargetFile),
                        Uri = string.Format("{0}", collectionItem.Id),
                        TypeOfDocument = await typeOfDocumentService.GetTypeOfDocumentByFileExtension(fileExtension),
                        CollectionItem = collectionItem
                    };
                    _IRepository.AddMedia(collectionItem, media);

                }
            }
        }

        private async Task<string> CopyFile(string sourceFilePath, int id)
        {
            // TODO: string durch config wert ersetzen
            string rootDir = @"C:\\SwDeveloper2022\\SWDData\\PlayCollector";
            string targetFilePath = Path.Combine(rootDir, id.ToString(), Path.GetFileName(sourceFilePath));
            FileHelper.CopyFile(sourceFilePath, targetFilePath);
            return targetFilePath;
        }

    }
}