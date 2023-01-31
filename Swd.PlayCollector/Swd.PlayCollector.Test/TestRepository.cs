using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;

namespace Swd.PlayCollector.Test;

[TestClass]
public class TestRepository
{
    [TestMethod]
    public void Add_CollectionItem()
    {
        CollectionItem item = new CollectionItem();
        item.Name = "TestItem_Add_CollectionItem";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        CollectionItemRepository repo = new CollectionItemRepository();
        repo.Add(item);

        Assert.AreNotEqual(0, item.Id);
    }

    [TestMethod]
    public async Task Add_CollectionItemAsync()
    {
        CollectionItem item = new CollectionItem();
        item.Name = "TestItem_Add_CollectionItemAsync";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

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
        CollectionItem item = new CollectionItem();
        item.Name = "TestItem_Add_CollectionItemWithPrice";
        item.Price = Convert.ToDecimal(price);
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        CollectionItemRepository repo = new CollectionItemRepository();
        repo.Add(item);

        Assert.AreNotEqual(0, item.Id);
    }



    [TestMethod]
    public void Add_Location()
    {
        Location item = new Location();
        item.Name = "TestLocation_Add_Location";
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
        item.Name = "TestLocation_Add_LocationAsync";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        LocationRepository repo = new LocationRepository();
        await repo.AddAsync(item);

        Assert.AreNotEqual(0, item.Id);


    }

    [TestMethod]
    public void Update_CollectionItem()
    {
        CollectionItemRepository repo = new CollectionItemRepository();
        CollectionItem item = new CollectionItem();
        string itemName = "TestItem_Update_CollectionItem";
        item.Name = itemName;
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        repo.Add(item);

        CollectionItem addeditem = repo.GetById(item.Id);
        addeditem.Name = String.Format("Testitem{0}",DateTime.Now);
        repo.Update(addeditem, addeditem.Id);

        CollectionItem updatedItem= repo.GetById(item.Id);

        Assert.AreNotEqual(itemName, item.Id);
    }


    [TestMethod]
    public void Delete_CollectionItem()
    {
        CollectionItemRepository repo = new CollectionItemRepository();
        CollectionItem item = new CollectionItem();
        string itemName = "TestItem_Delete_CollectionItem";
        item.Name = itemName;
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        repo.Add(item);
        repo.Delete(item.Id);

        CollectionItem deletedItem = repo.GetById(item.Id);

        Assert.IsNull(deletedItem);
    }

    [TestMethod]
    public void GetAll_CollectionItem()
    {
        CollectionItemRepository repo = new CollectionItemRepository();

        int itemCount = repo.GetAll().Count();

        Assert.AreNotEqual(0,itemCount);
    }
}