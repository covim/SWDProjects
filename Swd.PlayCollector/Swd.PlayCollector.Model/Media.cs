using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Swd.PlayCollector.Model
{
    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }

        //public int TypeOfDocumentId { get; set; }
        public TypeOfDocument TypeOfDocument { get; set; }

        //public int CollectionItemId { get; set; }
        public CollectionItem CollectionItem { get; set; }

        public string ImagePath
        {
            get
            {
                // TODO: string durch config wert ersetzen
                string rootDir = @"C:\\SwDeveloper2022\\SWDData\\PlayCollector";
                return Path.Combine(rootDir, Uri, Name);
            }
        }
    }
}