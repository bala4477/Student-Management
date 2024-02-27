using AspCore1.Data;
using AspCore1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCore1.Controllers
{
    public class MarksController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        public MarksController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            List<Marks> marks = _dbContext.marks.ToList();
            Marks.UpdateRanks(marks);
            _dbContext.SaveChanges();
            return View(marks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Marks marks)
        {
            if (ModelState.IsValid)
            {
                Marks.CalculateTotal(marks);
                _dbContext.marks.Add(marks);
                _dbContext.SaveChanges();
                TempData["success"] = "Record Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Marks marks = _dbContext.marks.FirstOrDefault(x => x.MarkID == id);
            if (marks != null)
            {
                return View(marks);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Marks marks = _dbContext.marks.FirstOrDefault(x => x.MarkID == id);
            if (marks != null)
            {
                return View(marks);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Marks marks)
        {
            if (ModelState.IsValid)
            {
                Marks.CalculateTotal(marks);
                _dbContext.marks.Update(marks);
                _dbContext.SaveChanges();
                TempData["warning"] = "Record Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Marks marks = _dbContext.marks.FirstOrDefault(x => x.MarkID == id);
            return View(marks);
        }
        [HttpPost]
        public IActionResult Delete(Marks mark)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Remove(mark);
                _dbContext.SaveChanges();
                TempData["danger"] = "Record Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
