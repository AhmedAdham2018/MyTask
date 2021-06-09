using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ItemsWithSubCategorySpcification : BaseSpecification<ProductItem>
    {
        public ItemsWithSubCategorySpcification()
        {
            AddInclude(x => x.SubCategory);
            AddInclude(x => x.SubCategory.Category);
        }

        public ItemsWithSubCategorySpcification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.SubCategory);
            AddInclude(x => x.SubCategory.Category);
        }
    }
}