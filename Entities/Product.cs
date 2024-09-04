namespace FureaApp.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid SubCategoryId { get; set; }
        //public string? ImagesId { get; set; }
    }
}