using System.Collections.Generic;

namespace DAL.App.DTO
{
    public class ProductDTO
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }

        public int? OrganizationId { get; set; }
        public List<int> Categories { get; set; }
    }
}