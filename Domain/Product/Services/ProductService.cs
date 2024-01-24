namespace Domain.Product.Services
{
    public class ProductService
    {
        public static void IncreasePrice(ICollection<Entity.Product> products, float porcentage)
        {
            products.ToList().ForEach(product => product.ChangePrice(product.Price * (1 + porcentage / 100)));
        }
    }
}
