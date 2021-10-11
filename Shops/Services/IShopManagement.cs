using System.Collections.ObjectModel;

namespace Shops.Services
{
    public interface IShopManagement
    {
        Shop.Shop AddShop(string name, string address);
        Customer.Customer CreateNewCustomer(string name, int balance);
        void CustomerMakePurchase(Customer.Customer customer, Shop.Shop shop, Product.Product product, int amount);
        void DeliverProducts(Shop.Shop shop, ReadOnlyCollection<Product.Product> productList);
        void AddProduct(Shop.Shop shop, Product.Product product);
        Product.Product FindProductWithMinPrice();
        Product.Product FindProductWithMaxPrice();
    }
}