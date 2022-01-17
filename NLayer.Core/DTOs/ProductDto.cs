namespace NLayer.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
