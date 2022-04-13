using eCommerceApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceApp.Repos
{
    public class ProductRepository : IProductRepository
    {
        eCommerceAppEntities context;
        public ProductRepository(eCommerceAppEntities _context)
        {
            context = _context;
        }
        public List<Product> getallproducts()
        {
            return context.Products.ToList();
        }
        public Product getbyID(int id)
        {
            return context.Products.FirstOrDefault(s => s.ProductID == id);
        }
        public Product getbyName(string name)
        {
            return context.Products.FirstOrDefault(s => s.ProductName == name);
        }
        public int Insert(Product _product)
        {
            context.Products.Add(_product);
            return context.SaveChanges();
        }
        public int Update(int id, Product _product)
        {
            Product orgproduct = getbyID(id);
            if (orgproduct != null)
            {
                orgproduct.ProductName = _product.ProductName;
                orgproduct.ProductPrice = _product.ProductPrice;
                orgproduct.ProductDescreption = _product.ProductDescreption;
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            context.Products.Remove(getbyID(id));
            int flag = context.SaveChanges();
            return flag;
        }
    }
}
