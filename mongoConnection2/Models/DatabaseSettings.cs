namespace mongoConnection2.Models
{
    public class DatabaseSettings
    {

        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? CategoriesCollectionName { get; set; }
        public string? ProductsCollectionName { get; set; }
        public string? CustomerCollectionName { get; set; }

    }
}
