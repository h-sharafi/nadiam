namespace Domain.Orders
{
    public class Order: Entity<short>
    {
        public AppUser AppUser { get; set; }
    }
}