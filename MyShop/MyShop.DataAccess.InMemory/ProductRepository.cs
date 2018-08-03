using System;
using System.Collections.Generic;

using System.Web;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public  class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        //list<Product> products = new list<Product>();
        List<Product> products;//= new List<Product><Product>();
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }

        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product product) {

            //Product productToUpdate = products.Find(p => p.id == product.id);
            Product productToUpdate = products.Find(p=> p.id==product.id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
        public Product Find(string Id)
        {
             Product product = products.Find(p=>p.id==Id);
              
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Not Editable");
            }
        }
        public IQueryable<Product> Collection()
        {

            return products.AsQueryable();
        }
        public void Delete(string id)
        {
            Product productToDelete = products.Find(p => p.id == id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }
    }
}
