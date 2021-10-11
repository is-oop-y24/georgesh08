using NUnit.Framework;
using Shops.Services;
using Shops.Services.Customer;
using Shops.Services.Product;
using Shops.Services.Shop;
using Shops.Tools;

namespace Shops.Tests
{
    public class Tests
    {
        private IShopManagement _management;

        [SetUp]
        public void Setup()
        {
            _management = new ShopManagement();
        }

        [Test]
        public void CustomerMakesPurchase_NotEnoughMoney_ThrowException()
        {
            Assert.Catch<ShopsException>(() =>
            {
                var newCustomer = new Customer("George", 120);
                var newShop = new Shop("Pyaterochka", "Kronva 49");
                var newProduct = new Product("Syr kosichka", 228);
                newProduct.SetAmount(20);
                newShop.AddProduct(newProduct);
                _management.CustomerMakePurchase(newCustomer,newShop,newProduct,10);
            });
        }
        
        [Test]
        public void CustomerBuysProduct_ProductAmountChanges()
        {
            Assert.Catch<ShopsException>(() =>
            {
                var newCustomer = new Customer("George", 120);
                var newShop = new Shop("ITMO.Store", "Kronva 49");
                var newProduct = new Product("Teddy Bear", 20);
                newProduct.SetAmount(20);
                int amountBeforePurchase = newProduct.GetAmount();
                newShop.AddProduct(newProduct);
                _management.CustomerMakePurchase(newCustomer, newShop, newProduct, 5);
                if (amountBeforePurchase != newProduct.GetAmount())
                {
                    Assert.Fail();
                }
            });
        }

        [Test]
        public void AddProductToShop_ShopContainsNewProduct()
        {
            var newShop = new Shop("Magnit", "Kaif");
            var newProduct = new Product("Keks", 55);
            newShop.AddProduct(newProduct);
            Assert.True(newShop.IsInCatalog(newProduct));
        }

        [Test]
        public void BuyMoreProductsThanShopHas_ThrowException()
        {
            Assert.Catch<ShopsException>(() =>
            {
                var newCustomer = new Customer("George", 1200);
                var newShop = new Shop("Pyaterochka", "Kronva 49");
                var newProduct = new Product("Syr kosichka", 5);
                newProduct.SetAmount(20);
                newShop.AddProduct(newProduct);
                _management.CustomerMakePurchase(newCustomer,newShop,newProduct,50);
            });
        }
    }
}