﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Product.Domain.Shared.Entitys
{
    public partial class ProductAttribute
    {
        public ProductAttribute()
        {
            ProductAttributeValues = new HashSet<ProductAttributeValue>();
            ProductSpecificationAttributeMappings = new HashSet<ProductSpecificationAttributeMapping>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Types { get; set; }
        public bool IsDelete { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual ICollection<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMappings { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
