namespace Swd.PlayCollector.Model
{
    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }

        public int TypeOfDocumentId { get; set; }
        //public TypeOfDocument TypeOfDocument { get; set; }

        public int CollectionItemId { get; set; }
        //public CollectionItem CollectionItem { get; set; }
    }
}