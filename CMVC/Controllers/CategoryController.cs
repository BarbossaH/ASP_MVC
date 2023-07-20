using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMVC.Context;
using CMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMVC.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		// GET: /<controller>/
		public IActionResult Index()
		{
			//in postgrsql, there is model named Categories, it can be seen in applicationdbcontext file
			List<Category> categories = _db.Categories.ToList();
			return View(categories);
		}

		//get the view
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category obj)
		{

			if (obj.Name == obj.DisplayOrder.ToString())
			{
				//the first paramter determine which field will show the error infromation
				ModelState.AddModelError("name", "Name cannot match order");
			}
			//         if (obj.Name !=null && obj.Name.ToLower() == "test")
			//         {
			//             //the first paramter determine which field will show the error infromation
			//             ModelState.AddModelError("name", "Name cannot be test");
			//         }

			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
			//return RedirectToAction("Index","ControllerName");
            return RedirectToAction("Index");
			}

			return View();
		}


        //get the view
        public IActionResult Edit(int? id)
        {
			if (id == null || id == 0)
			{
				return NotFound();
			}

			//Category? category1 = _db.Categories.Find(id);
			Category ?category = _db.Categories.FirstOrDefault(u => u.Id == id);
			//Category ?category2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

			if (category == null)
			{
				return NotFound();
			}

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
			//notice: make sure obj contain the Id is that I want, because the defaut value of Id is 0
			//so even though we don't set the value, it won't report the error, so we should be careful
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //the first paramter determine which field will show the error infromation
                ModelState.AddModelError("name", "Name cannot match order");
            }
            //         if (obj.Name !=null && obj.Name.ToLower() == "test")
            //         {
            //             //the first paramter determine which field will show the error infromation
            //             ModelState.AddModelError("name", "Name cannot be test");
            //         }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";

                //return RedirectToAction("Index","ControllerName");
                return RedirectToAction("Index");
            }

            return View();
        }


        //get the view
        public IActionResult Delete(int ?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category ?obj = _db.Categories.Find(id);

			if (obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}

