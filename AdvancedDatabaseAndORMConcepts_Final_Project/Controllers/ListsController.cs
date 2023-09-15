using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedDatabaseAndORMConcepts_Final_Project.Data;
using AdvancedDatabaseAndORMConcepts_Final_Project.Models;

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Controllers
{
    public class ListsController : Controller
    {
        private readonly AdvancedDatabaseAndORMConcepts_Final_ProjectContext _context;

        public ListsController(AdvancedDatabaseAndORMConcepts_Final_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title")] List list)
        {
            if (ModelState.IsValid)
            {
                _context.Add(list);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = list.ListId });
            }
            return View(list);
        }

        public IActionResult Details(int id)
        {
            if (id == null || _context.List == null)
            {
                return NotFound();
            }

            List list = _context.List.Include(l => l.Items).FirstOrDefault(l => l.ListId == id);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || _context.List == null)
            {
                return NotFound();
            }

            List list = _context.List.Include(l => l.Items).FirstOrDefault(m => m.ListId == id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }

        [HttpPost, ActionName("Delete")]



         [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.List == null)
            {
                return Problem("Entity set 'FirstDbMVCAppContext.Course'  is null.");
            }
            List list = _context.List.Find(id);
            if (list != null)
            {
                _context.List.Remove(list);
            }

            _context.SaveChanges();
            return RedirectToAction("index", "home");
        }

        public IActionResult AddItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List list = _context.List.Include(l => l.Items).FirstOrDefault(l => l.ListId == id);

            if (list == null)
            {
                return NotFound();
            }

            ViewBag.ListId = id;

            Item item = new Item
            {
                List = list,
            };
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem([Bind("ItemId, Title, Priority, Description, IsCompleted, ListId")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.CreatedDate = DateTime.Now;
                _context.Add(item);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = item.ListId });
            }

            ViewBag.ListId = item.ListId;
            return View(item);

        }

        [HttpPost]
        public IActionResult IsCompleted(int id, bool isCompleted) 
        { 
            Item? item = _context.Item.FirstOrDefault(i => i.ItemId == id);

            if (item != null)
            {
                item.IsCompleted = isCompleted;
                _context.SaveChanges();
            }

            return RedirectToAction($"Details", new { id = item.ListId });
        }

        public IActionResult ShowCompletedItem(int id)
        {

            HashSet<Item> completedItems = _context.Item.Include(i => i.List).Where(i => i.ListId == id).Where(i => i.IsCompleted).ToHashSet();
            
            if (completedItems.Count == 0) 
            {
                return RedirectToAction("Details", new { id = id });
            }

            ViewBag.id = id;
            return View(completedItems);
        }

       
    }
}
