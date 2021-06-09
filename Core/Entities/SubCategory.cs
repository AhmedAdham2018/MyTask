using System.Collections.Generic;

namespace Core.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public Category  Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}