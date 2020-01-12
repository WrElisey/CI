using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models
{
    public class Product
    {
        public string Name { get; set; }

        public Product(string name)
        {
            this.Name = name;
        }
    }
}
