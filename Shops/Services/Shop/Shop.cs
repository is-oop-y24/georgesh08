using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shops.Services.Shop
{
    public class Shop
    {
        private readonly List<Product.Product> _catalog = new List<Product.Product>();
        private readonly string _name;
        private readonly int _id;
        private readonly string _address;

        public Shop(string name, string address)
        {
            _name = name;
            _address = address;
            _id = ShopIdGenerator.GenerateNewShopId();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Shop)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_catalog, _name, _id, _address);
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetAddress()
        {
            return _address;
        }

        public ReadOnlyCollection<Product.Product> GetCatalog()
        {
            return _catalog.AsReadOnly();
        }

        public void AddProduct(Product.Product newProduct)
        {
            if (IsInCatalog(newProduct))
            {
                int newAmount = _catalog[_catalog.IndexOf(newProduct)].GetAmount() + newProduct.GetAmount();
                _catalog[_catalog.IndexOf(newProduct)].SetAmount(newAmount);
                return;
            }

            _catalog.Add(newProduct);
        }

        public bool IsInCatalog(Product.Product product)
        {
            return _catalog.Any(prod => prod.GetId() == product.GetId());
        }

        public Product.Product FindProduct(Product.Product product)
        {
            return _catalog.IndexOf(product) == -1 ? null : _catalog[_catalog.IndexOf(product)];
        }

        private bool Equals(Shop other)
        {
            return Equals(_catalog, other._catalog) && _name == other._name && _id == other._id &&
                   _address == other._address;
        }
    }
}