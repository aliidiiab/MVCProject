using eCommerceApp.Models;
using System.Collections.Generic;

namespace eCommerceApp.Repos
{
    public interface ICategoryRepository
    {
        int Delete(int id);
        List<Category> getallCategories();
        Category getbyID(int id);
        int Insert(Category _category);
        int Update(int id, Category _category);
    }
}