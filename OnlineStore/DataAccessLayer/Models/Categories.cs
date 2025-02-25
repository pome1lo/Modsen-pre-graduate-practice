namespace DataAccessLayer.Models;

public class Categories : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Products> Products { get; set; }
}
