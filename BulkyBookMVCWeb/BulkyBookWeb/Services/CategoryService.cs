using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyBookWeb.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Category> GetCategory()
        {
            return _db.Categories;
        }

        public void CreateCategory(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
        }

        // ToFix
        public void FindCategory(int? id)
        {
            _db.Categories.Find(id);
        }

        public void UpdateCategory(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
        }
        public void RemoveCategory(Category obj)
        {
            _db.Categories.Remove(obj);
            _db.SaveChanges();
        }
    }
}
