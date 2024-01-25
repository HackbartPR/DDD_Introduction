using Domain.Checkout.Entity;

namespace Domain.Checkout.Services
{
    public abstract class OrderService
    {
        public static float CalculateTotalValue(ICollection<Order> orders)
        {
            return orders.Any() ? orders.Aggregate(0f, (result, order) => result + order.Total) : 0;
        }
    }
}
