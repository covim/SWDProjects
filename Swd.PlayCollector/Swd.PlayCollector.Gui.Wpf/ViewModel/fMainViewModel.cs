using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GongSolutions.Wpf.DragDrop;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Swd.PlayCollector.Business;
using Swd.PlayCollector.Model;
using Syncfusion.PMML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Converters;

namespace Swd.PlayCollector.Gui.Wpf.ViewModel
{
    public partial class fMainViewModel : ObservableObject, IDropTarget
    {
        private string _searchValue;
        private string _statusBarText;
        private CollectionItem _selectedCollectionItem;
        private ObservableCollection<CollectionItem> _collectionItemsList;
        private ObservableCollection<Location> _locationList;
        private ObservableCollection<Theme> _themeList;
        private ICollectionView _collectionItemsView;


        public CollectionItem SelectedCollectionItem
        {
            get { return _selectedCollectionItem; }
            set { SetProperty(ref _selectedCollectionItem, value);
                this.DeleteCollectionItemCommand.NotifyCanExecuteChanged();
                this.SaveCollectionItemCommand.NotifyCanExecuteChanged();
            }
        }
        public ICollectionView CollectionItemsView
        {
            get { return _collectionItemsView; }
            set { SetProperty(ref _collectionItemsView, value);
                
            }
        }
        public ObservableCollection<Theme> ThemeList
        {
            get { return _themeList; }
            set { SetProperty(ref _themeList, value); }
        }
        public ObservableCollection<Location> LocationList
        {
            get { return _locationList; }
            set { SetProperty(ref _locationList, value); }
        }
        public ObservableCollection<CollectionItem> CollectionItemsList
        {
            get { return _collectionItemsList; }
            set { SetProperty(ref _collectionItemsList, value); }
        }
        public string StatusBartext
        {
            get { return GetStatusBarText(); }
            set { SetProperty(ref _statusBarText, value); }
        }
        public string SearchValue
        {
            get { return _searchValue; }
            set
            {
                SetProperty(ref _searchValue, value);
                SearchForCollectionItem();
            }
        }

        public IAsyncRelayCommand ExitCommand { get; }
        public IAsyncRelayCommand ImportCommand { get; }
        public IAsyncRelayCommand SearchForCollectionItemCommand { get; }
        public IAsyncRelayCommand AddCollectionItemCommand { get; }
        public IAsyncRelayCommand DeleteCollectionItemCommand { get; }
        public IAsyncRelayCommand SaveCollectionItemCommand { get; }

        public IAsyncRelayCommand CancelCommand { get; }


        public fMainViewModel()
        {
            this.StatusBartext = string.Empty;
            //this.SearchValue = "";
            LoadDataAsync();


            ExitCommand = new AsyncRelayCommand(Exit, CanExitExecuted);
            ImportCommand = new AsyncRelayCommand(Import, CanImportExecuted);
            SearchForCollectionItemCommand = new AsyncRelayCommand(SearchForCollectionItem);
            AddCollectionItemCommand = new AsyncRelayCommand(AddCollectionItem, CanAddCollectionItemExecuted);
            DeleteCollectionItemCommand = new AsyncRelayCommand(DeleteCollectionItem, CanDeleteCollectionItemExecuted);
            SaveCollectionItemCommand = new AsyncRelayCommand(SaveCollectionItem, CanSaveCollectionItemExecuted);
            CancelCommand = new AsyncRelayCommand(CancelOperation);


            CollectionItemsView = CollectionViewSource.GetDefaultView(CollectionItemsList);
            CollectionItemsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        private async Task Import()
        {
            
        }

        private bool CanImportExecuted()
        {
            return false;
        }

        private async Task Exit()
        {
            
        }

        private bool CanExitExecuted()
        {
            return false;
        }

        private async Task CancelOperation()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            CollectionItemService collectionItemService = new CollectionItemService();
            LocationService locationService = new LocationService();
            ThemeService themeService = new ThemeService();

            //Task<IQueryable<CollectionItem>> getColectionItemTask = collectionItemService.GetAllAsync();  //lädt MediaSet nicht mit
            Task<IQueryable<CollectionItem>> getColectionItemTask = collectionItemService.GetAllInklusiveAsync();
            Task<IQueryable<Location>> getLocationTask = locationService.GetAllAsync();
            Task<IQueryable<Theme>> getThemeTask = themeService.GetAllAsync();


            this.CollectionItemsList = new ObservableCollection<CollectionItem>(await getColectionItemTask);
            this.LocationList = new ObservableCollection<Location>(await getLocationTask);
            this.ThemeList = new ObservableCollection<Theme>(await getThemeTask);

        }

        private async Task SearchForCollectionItem()
        {
            CollectionItemsView = CollectionViewSource.GetDefaultView(CollectionItemsList);
            CollectionItemsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            CollectionItemsView.Filter = CollectionItemFilter;

        }

        private async Task AddCollectionItem()
        {
            this.SelectedCollectionItem = new CollectionItem(true);
        }

        private bool CanAddCollectionItemExecuted()
        {
            return true;
        }

        private async Task DeleteCollectionItem()
        {
            CollectionItem item = this.SelectedCollectionItem;
            if (item != null)
            {
                CollectionItemService service = new CollectionItemService();
                await service.DeleteAsync(item.Id);
                this.SelectedCollectionItem = null;
                await LoadDataAsync();
                this.SelectedCollectionItem = CollectionItemsList.FirstOrDefault();

            }
        }
        private bool CanDeleteCollectionItemExecuted()
        {
            return SelectedCollectionItem != null;
        }

        private async Task SaveCollectionItem()
        {
            CollectionItemService service = new CollectionItemService();
            CollectionItem item = this.SelectedCollectionItem;

            if (item.Id == 0)
            {
                item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                await service.AddAsync(item);
            }
            else
            {
                item.UpdatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                await service.UpdateAsync(item);
            }

            await LoadDataAsync();
        }
        private bool CanSaveCollectionItemExecuted()
        {
            return SelectedCollectionItem != null;
        }



        private string GetStatusBarText()
        {
            return string.Format("{0} items found", this.CollectionItemsList.Count);
        }

        private bool CollectionItemFilter(object item)
        {
            CollectionItem collectionItem = item as CollectionItem;
            bool containsName = collectionItem.Name.Contains(this.SearchValue, StringComparison.CurrentCultureIgnoreCase);
            bool containsId = collectionItem.Id.ToString().Contains(this.SearchValue);
            bool containsSetnumbber = collectionItem.Number.ToString().Contains(this.SearchValue);
            return containsId||containsName||containsSetnumbber;
        }

        public void DragOver(IDropInfo dropInfo)
        {
            var dragFileList = ((DataObject)dropInfo.Data).GetFileDropList().Cast<string>();
            dropInfo.Effects = dragFileList.Any(item =>
            {
                var extension = Path.GetExtension(item);
                return extension != null && extension.Equals(".png");
            }) ? DragDropEffects.Copy: DragDropEffects.None;
        }

        public void Drop(IDropInfo dropInfo)
        {
            string mainFolder = "C:/SwDeveloper2022/SWDData/";




            var dragFileList = ((DataObject)dropInfo.Data).GetFileDropList().Cast<string>();
            dropInfo.Effects = dragFileList.Any(item =>
            {
                var extension = Path.GetExtension(item);
                return extension != null && extension.Equals(".png");
            }) ? DragDropEffects.Copy : DragDropEffects.None;

            
            if(SelectedCollectionItem != null)
            {
                foreach (var item in dragFileList)
                {
                    var filename = Path.GetFileName(item);
                    var newFilePath = mainFolder + SelectedCollectionItem.Id.ToString() + "/";
                    if (Directory.Exists(newFilePath))
                    {
                        File.Copy(item, Path.Combine(newFilePath, filename));
                    }
                    else
                    {
                        Directory.CreateDirectory(newFilePath);
                        //File.Create(newFilePath,);
                        File.Copy(item, Path.Combine(newFilePath, filename));

                    }
                }
            }

            
        }
    }
}
