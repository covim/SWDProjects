using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swd.PlayCollector.Helper;

namespace Swd.PlayCollector.Model
{
    public class Media: ObservableValidator
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
                PlayCollectorConfiguration playCollectorConfiguration = new PlayCollectorConfiguration();
                string rootDir = playCollectorConfiguration.PathToMediaFiles;
                return Path.Combine(rootDir, Uri, Name);
            }
        }
    }
}