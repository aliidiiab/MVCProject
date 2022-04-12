using eCommerceApp.Models;
using System.Collections.Generic;

namespace eCommerceApp.Repos
{
    public interface IProductRepository
    {
        int Delete(int id);
        List<Product> getallproducts();
        Product getbyID(int id);
        Product getbyName(string name);
        int Insert(Product _product);
        int Update(int id, Product _product);
    }
}