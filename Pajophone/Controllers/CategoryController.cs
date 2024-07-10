using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pajophone.Data.Contexts;
using Pajophone.Models;
using Pajophone.Models.Factory;
using Pajophone.ViewModels;

namespace Pajophone.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ICategoryFactory _factory;

        public CategoryController(ApplicationContext context, ICategoryFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ProductCategories.Include(p => p.ParentCategory);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryModel = await _context.ProductCategories
                .Include(p => p.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategoryModel == null)
            {
                return NotFound();
            }

            return View(productCategoryModel);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            ViewData["ParentCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Id");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _factory.SetViewModel(categoryViewModel);
                var category = _factory.GetCategory();
                var fieldKeys = _factory.GetFieldKeys();
                _context.Add(category);
                _context.AddRange(fieldKeys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryViewModel);
        }
        
        public class TreeNode
        {
            public string label { get; set; }
            public int id { get; set; }
            public List<TreeNode>? children { get; set; }
        }

        public async Task<IActionResult> GetTree()
        {
            var categories = await _context.ProductCategories
                .Include(p => p.ParentCategory)
                .ToListAsync();
            var treeData = BuildTree(categories, null);
            return Json(treeData);
        }
        
        private List<TreeNode> BuildTree(List<ProductCategoryModel> categories, int? parentId)
        {
            var nodes = new List<TreeNode>();
            foreach (var category in categories.Where(c => c.ParentCategoryId == parentId))
            {
                var node = new TreeNode
                {
                    label = category.Name,
                    id = category.Id,
                    children = BuildTree(categories, category.Id)
                };
                nodes.Add(node);
            }
            return nodes;
        }

        public async Task<IActionResult> GetFieldKeys(int categoryId)
        {
            var fields = await _context
                .ProductFieldKeys
                .Where(fk => fk.CategoryId == categoryId)
                .ToListAsync();
            return Json(fields);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryModel = await _context.ProductCategories.FindAsync(id);
            if (productCategoryModel == null)
            {
                return NotFound();
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Id", productCategoryModel.ParentCategoryId);
            return View(productCategoryModel);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ParentCategoryId")] ProductCategoryModel productCategoryModel)
        {
            if (id != productCategoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryModelExists(productCategoryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Id", productCategoryModel.ParentCategoryId);
            return View(productCategoryModel);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategoryModel = await _context.ProductCategories
                .Include(p => p.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productCategoryModel == null)
            {
                return NotFound();
            }

            return View(productCategoryModel);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCategoryModel = await _context.ProductCategories.FindAsync(id);
            if (productCategoryModel != null)
            {
                _context.ProductCategories.Remove(productCategoryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryModelExists(int id)
        {
            return _context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
