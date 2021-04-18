using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Business.Abstract;
using Project.Entities.ViewModel;
using Project.Web.Models;
using Project.Web.Models.PageModels;
using Project.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Controllers {
    public class HomeController : Controller {
        private readonly IProductOperations _productOperations;
        private IMapper _mapper;

        public HomeController(IProductOperations productOperations, IMapper mapper) {
            _productOperations = productOperations;
            _mapper = mapper;
        }

        public IActionResult Index(ProductSearchModel searchModel) {
            var response = _productOperations.GetProductListByFilters(searchModel);

            ProductPageModel products = new ProductPageModel {
                Products = _mapper.Map<List<ProductViewModel>>(response.Data)
            };

            return View(products);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Search(SearchViewModel model) {
            if (!ModelState.IsValid) {
                return RedirectToAction("Index");
            }

            var response = _productOperations.GetProductsBySearchTittle(model.SearchTitle);

            SearchListPageModel viewModel = new SearchListPageModel {
                Products = _mapper.Map<List<ProductViewModel>>(response.Data)
            };
            return View(viewModel);
        }
    }
}
