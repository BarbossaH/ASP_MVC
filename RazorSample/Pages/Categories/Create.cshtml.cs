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
	public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category SingleCategory { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(SingleCategory);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";

            return RedirectToPage("Index");
        }
    }
}
