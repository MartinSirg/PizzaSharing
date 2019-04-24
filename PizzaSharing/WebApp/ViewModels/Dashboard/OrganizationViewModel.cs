using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApp.ViewModels.Dashboard
{
    public class OrganizationViewModel
    {
        public BLLOrganizationMinDTO OrganizationMin { get; set; }
        public List<BLLCategoryDTO> Categories { get; set; }
        public List<BLLProductDTO> Products { get; set; }
        public List<BLLChangeDTO> Changes { get; set; }
    }
}