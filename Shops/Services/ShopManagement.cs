using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Shops.Services.Product;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManagement : IShopManagement
    {
        private readonly List<Shop.Shop> _database = new List<Shop.Shop>();

        public Shop.Shop AddShop(string name, string address)
        {
            var newShop = new Shop.Shop(name, address);
            _database.Add(newShop);
            return newShop;
        }

        public void CustomerMakePurchase(Customer.Customer customer, Shop.Shop shop, Product.Product product, int amount)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            if (shop.IsInCatalog(product))
            {
                throw new ProductExistenceException("No such product in catalog.");
            }

            customer.MakePurchase(product, amount);
            new PurchaseHandler().SetNewAmount(product, amount);
        }

        public void AddProduct(Shop.Shop shop, Product.Product product)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            _database[_database.IndexOf(shop)].AddProduct(product);
        }

        public void DeliverProducts(Shop.Shop shop, ReadOnlyCollection<Product.Product> productList)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            foreach (Product.Product newProduct in productList)
            {
                if (shop.IsInCatalog(newProduct))
                {
                    int newAmount = newProduct.GetAmount() + shop.FindProduct(newProduct).GetAmount();
                    shop.FindProduct(newProduct).SetAmount(newAmount);
                }
                else
                {
                    GetShopFromDatabase(shop).AddProduct(newProduct);
                }
            }
        }

        public Product.Product FindProductWithMinPrice()
        {
            float min = float.MaxValue;
            Product.Product foundProduct = null;
            foreach (Product.Product product in from shop in _database from product in shop.GetCatalog() where product.GetPrice() < min select product)
            {
                foundProduct = product;
                min = product.GetPrice();
            }

            return foundProduct;
        }

        public Product.Product FindProductWithMaxPrice()
        {
            float max = float.MinValue;
            Product.Product foundProduct = null;
            foreach (Product.Product product in from shop in _database from product in shop.GetCatalog() where product.GetPrice() > max select product)
            {
                foundProduct = product;
                max = product.GetPrice();
            }

            return foundProduct;
        }

        public Customer.Customer CreateNewCustomer(string name, int balance)
        {
            return new Customer.Customer(name, balance);
        }

        private bool IsShopInDatabase(Shop.Shop shop)
        {
            return _database.Contains(shop);
        }

        private ReadOnlyCollection<Product.Product> GetShopCatalogFromDatabase(Shop.Shop shop)
        {
            return GetShopFromDatabase(shop).GetCatalog();
        }

        private Shop.Shop GetShopFromDatabase(Shop.Shop shop)
        {
            if (!IsShopInDatabase(shop))
            {
                throw new ShopsException("No such shop in database.");
            }

            return _database[_database.IndexOf(shop)];
        }
    }
}