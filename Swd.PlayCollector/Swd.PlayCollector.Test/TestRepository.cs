using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;
using System.Data;
using System.Data.Common;


namespace Swd.PlayCollector.Test
{
    [TestClass]
    public class TestRepository
    {
        public TestRepository()
        {
            //EmptyDatabase();
        }



        [TestMethod]
        public void Add_CollectionItem()
        {

            CollectionItemRepository repo = new CollectionItemRepository();
            CollectionItem item = GetCollectionItem();
            repo.Add(item);

            Assert.AreNotEqual(0, item.Id);
        }

        [TestMethod]
        public async Task Add_CollectionItemAsync()
        {
            CollectionItem item = GetCollectionItem();

            CollectionItemRepository repo = new CollectionItemRepository();
            await repo.AddAsync(item);
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        [DataRow(0.0)]
        [DataRow(-10.0)]
        [DataRow(10.0)]
        public void Add_CollectionItemWithPrice(double price)
        {
            CollectionItem item = GetCollectionItem();
            item.Price = Convert.ToDecimal(price);
            
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);
            Assert.AreNotEqual(0, item.Id);
        }



        [TestMethod]
        public void Update_CollectionItem()
        {
            CollectionItemRepository repo = new CollectionItemRepository();

            CollectionItem item = GetCollectionItem();
            string itemName = item.Name;

            repo.Add(item);

            CollectionItem addedItem = repo.GetById(item.Id);
            addedItem.Name = String.Format("Testitem{0}", DateTime.Now);
            repo.Update(addedItem, addedItem.Id);

            CollectionItem updatedItem = repo.GetById(item.Id);

            Assert.AreNotEqual(itemName, updatedItem.Name);
        }

        [TestMethod]
        public async Task Update_CollectionItemAsync()
        {
            CollectionItemRepository repo = new CollectionItemRepository();

            CollectionItem item = GetCollectionItem();
            string itemName = item.Name;

            await repo.AddAsync(item);

            CollectionItem addedItem = await repo.GetByIdAsync(item.Id);
            addedItem.Name = String.Format("Testitem_UpdateAsync{0}", DateTime.Now);
            await repo.UpdateAsync(addedItem, addedItem.Id);

            CollectionItem updatedItem = await repo.GetByIdAsync(item.Id);

            Assert.AreNotEqual(itemName, updatedItem.Name);
        }


        [TestMethod]
        public void Delete_CollectionItem()
        {
            CollectionItemRepository repo = new CollectionItemRepository();

            CollectionItem item = GetCollectionItem();

            repo.Add(item);
            int id = item.Id;
            repo.Delete(id);

            CollectionItem deletedItem = repo.GetById(id);
            Assert.IsNull(deletedItem);
        }


        [TestMethod]
        public async Task Delete_CollectionItemAsync()
        {
            CollectionItemRepository repo = new CollectionItemRepository();

            CollectionItem item = GetCollectionItem();

            await repo.AddAsync(item);
            int id = item.Id;
            await repo.DeleteAsync(id);

            CollectionItem deletedItem = await repo.GetByIdAsync(id);
            Assert.IsNull(deletedItem);
        }





        [TestMethod]
        public void GetAll_CollectionItem()
        {
            CollectionItem item = GetCollectionItem();
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            int itemCount = repo.GetAll().Count();
            Assert.AreNotEqual(0, itemCount);
        }

        [TestMethod]
        public async Task GetAllAsync_CollectionItem()
        {
            CollectionItem item = GetCollectionItem();
            CollectionItemRepository repo = new CollectionItemRepository();
            repo.Add(item);

            int itemCount = await repo.GetAllAsync().Result.CountAsync();
            Assert.AreNotEqual(0, itemCount);
        }


        [TestMethod]
        public void Add_Location()
        {
            Location item = new Location();
            item.Name = "Testlocation";
            item.CreatedDate = DateTime.Now;
            item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            LocationRepository repo = new LocationRepository();
            repo.Add(item);
            Assert.AreNotEqual(0, item.Id);
        }

        [TestMethod]
        public async Task Add_LocationAsync()
        {
            Location item = new Location();
            item.Name = "Testlocation";
            item.CreatedDate = DateTime.Now;
            item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            LocationRepository repo = new LocationRepository();
            await repo.AddAsync(item);
            Assert.AreNotEqual(0, item.Id);
        }









        public static CollectionItem GetCollectionItem()
        {
            CollectionItem item = new CollectionItem();            
            item.Name = "Testitem";
            item.CreatedDate = DateTime.Now;
            item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return item;
        } 

        

        
        private static void EmptyDatabase()
        {
            PlayCollectorContext testContext = new PlayCollectorContext();
            var command = testContext.Database.GetDbConnection().CreateCommand();

            command.CommandText = "spEmptyDatabase";   // name der stored procedure auf der Datenbank
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //Beispiel für einen Parameter der an die Sp übergeben wird
            //command.Parameters.Add(new SqlParameter("parametername", "parametervalue"));

            testContext.Database.OpenConnection();
            command.ExecuteNonQuery(); //Wir auf der Datenbank ausgeführt ohne einen Rückgabewert zu liefern

            // Beispiel um Rückgabwert zu verarbeiten
            //
            //var result = command.ExecuteReader();
            //var dataTable = new DataTable();
            //dataTable.Load(result);

        }


    }
}