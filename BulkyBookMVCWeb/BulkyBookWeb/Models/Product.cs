using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBookWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
