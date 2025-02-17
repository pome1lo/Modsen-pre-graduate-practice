namespace DataAccessLayer.Models
{
    public class Orders : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
