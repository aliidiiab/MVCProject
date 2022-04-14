using eCommerceApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceApp.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        eCommerceAppEntities context;
        public CategoryRepository(eCommerceAppEntities _context)
        {
            context = _context;
        }
        public Category getbyID(int id)
        {
            return context.Categories.FirstOrDefault(s => s.id == id);
        }
        public List<Category> getallCategories()
        {
            return context.Categories.ToList();
        }
        public int Insert(Category _category)
        {
            context.Categories.Add(_category);
            return context.SaveChanges();
        }
        public int Update(int id, Category _category)
        {
            Category orgcategory = getbyID(id);
            if (orgcategory != null)
            {
                orgcategory.category_name = _category.category_name;
                orgcategory.category_image = _category.category_image;
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            context.Categories.Remove(getbyID(id));
            int flag = context.SaveChanges();
            return flag;
        }
    }
}
