using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Domain
{
    public class Category : BaseEntity
    {
        [MaxLength(100)]
        [MinLength(1)]
        [Required]
        public string CategoryName { get; set; }
        
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public List<ChangeInCategory> ChangesInCategory { get; set; }

        public List<ProductInCategory> ProductsInCategory { get; set; }

        public string CategoryAndOwnerName => $"{CategoryName} ({Organization?.OrganizationName ?? "Error. Categories' Organization not loaded"})";
    }
}