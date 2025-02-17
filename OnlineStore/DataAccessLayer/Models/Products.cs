namespace DataAccessLayer.Models
{
    public class Products : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
