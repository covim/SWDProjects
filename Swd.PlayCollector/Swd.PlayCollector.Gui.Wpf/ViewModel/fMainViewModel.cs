using CommunityToolkit.Mvvm.ComponentModel;
using Swd.PlayCollector.Business;
using Swd.PlayCollector.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.PlayCollector.Gui.Wpf.ViewModel
{
    public partial class fMainViewModel : ObservableObject
    {
		private string _searchValue;
		private string _statusBarText;
        private CollectionItem _selectedCollectionItem;
        private ObservableCollection<CollectionItem> _collectionItemsList;
        private ObservableCollection<CollectionItem> _locationList;
        private ObservableCollection<CollectionItem> _themeList;


        public CollectionItem SelectedCollectionItem
        {
            get { return _selectedCollectionItem; }
            set { SetProperty(ref _selectedCollectionItem, value); }
        }

        public ObservableCollection<CollectionItem> ThemeList
        {
            get { return _themeList; }
            set { SetProperty(ref _themeList, value); }
        }

        public ObservableCollection<CollectionItem> LocationList
        {
            get { return _locationList; }
            set { SetProperty(ref _locationList, value); }
        }

        public ObservableCollection<CollectionItem> CollectionItemsList
        {
            get { return _collectionItemsList; }
            set { SetProperty(ref _collectionItemsList, value); }
        }

        public string  StatusBartext
		{
			get { return GetStatusBarText(); }
			set { SetProperty(ref _statusBarText, value); }
		}

		public string SearchValue
		{
			get { return _searchValue; }
			set { SetProperty(ref _searchValue, value); }
		}

        public fMainViewModel()
        {
            this.StatusBartext = string.Empty;
            this.SearchValue = "...Search";
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            CollectionItemService collectionItemService = new CollectionItemService();

            Task<IQueryable<CollectionItem>> getColectionItemTask = collectionItemService.GetAllAsync();

            this.CollectionItemsList = new ObservableCollection<CollectionItem>(await getColectionItemTask);

        }

        private string GetStatusBarText()
        {
            return string.Format("{0} items found", this.CollectionItemsList.Count);
        }


    }
}
