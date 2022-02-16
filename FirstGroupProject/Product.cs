using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGroupProject
{
    internal class Product
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product (string _name, string _description, string _category, decimal _price)
        {
            Name = _name;
            Description = _description;
            Category = _category;
            Price = _price;
        }


        public override string ToString()
        {
            return $"{Name} {Description} {Category} {Price}";
        }
    }
}
