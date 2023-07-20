using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorSample.Context;
using RazorSample.Models;

namespace RazorSample.Pages.Categories
{
	public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }

        public IndexModel(ApplicationDbContext db) {
            _db = db;
        }


        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
