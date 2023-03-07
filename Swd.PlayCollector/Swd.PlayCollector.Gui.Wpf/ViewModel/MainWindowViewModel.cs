using Swd.PlayCollector.Business;
using Swd.PlayCollector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Gui.Wpf.ViewModel
{
    public class MainWindowViewModel
    {
        private string _searchCriteria;
        private List<CollectionItem> _collectionItems;
        private string _serchCriteriaHelpText;

        public string SearchCriteriaHelpText
        {
            get { return _serchCriteriaHelpText; }
            set { _serchCriteriaHelpText = value; }
        }

        public string SearchCriteria
        {
            get { return _searchCriteria; }
            set { _searchCriteria = value; }
        }

        public List<CollectionItem> CollectionItems
        {
            get { return _collectionItems; }
            set { _collectionItems = value; }
        }

        public MainWindowViewModel()
        {
            SearchCriteriaHelpText = "Bitte Suchbegriff eingeben ... ";
            Init();
        }

        private async Task Init()
        {
            CollectionItemService service = new CollectionItemService();
            CollectionItems= new List<CollectionItem>(await service.GetAllAsync());
        }






    }

}
