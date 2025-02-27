namespace DataAccessLayer.Models
{
    public class Orders : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; } 
        public virtual User User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
