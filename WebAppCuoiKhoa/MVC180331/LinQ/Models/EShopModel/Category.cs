namespace CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameVN { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
