using System;
using System.Linq;
using LmazonBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LmazonBookStore.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public TypesViewComponent (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }


    }
}
