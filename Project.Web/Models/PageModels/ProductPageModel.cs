using Project.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models.PageModels {
    public class ProductPageModel {
        public List<ProductViewModel> Products { get; set; }
        public SearchViewModel Search { get; set; }

    }
}
