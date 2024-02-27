using AspCore1.Data;
using AspCore1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCore1.Controllers
{
    public class DepartmentController : Controller
    {
        
            private readonly ApplicationDbContext _dbContext;
            public DepartmentController(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            [HttpGet]
            public IActionResult Index()
            {
                List<Department> department = _dbContext.Departments.ToList();
                return View(department);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Department department)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Departments.Add(department);
                    _dbContext.SaveChanges();
                    TempData["success"] = "Records Created Successfully";
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Detail(int id)
            {
                Department department = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
                return View(department);
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                Department department = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
                if (department != null)
                {
                    return View(department);
                }
                return View();
            }
            [HttpPost]
            public IActionResult Edit(Department department)
            {
                if (ModelState.IsValid)
                {
                    // Delete the existing entity
                    var objFromDb = _dbContext.Departments.FirstOrDefault(x => x.Id == department.Id);

                    if (objFromDb != null)
                    {
                        _dbContext.Remove(objFromDb);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }

                    //Create a new entity with the updated key
                    var newDepartment = new Department
                    {
                        Id = department.Id,
                        DepartmentId = department.DepartmentId,
                        DepartmentName = department.DepartmentName,
                    };

                    _dbContext.Departments.Add(newDepartment);
                    _dbContext.SaveChanges();
                    TempData["warning"] = "Records Updated Successfully";
                    return RedirectToAction("Index");
                }

                return View();
            }
            [HttpGet]
            public IActionResult Delete(int id)
            {
                Department department = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
                return View(department);
            }
            [HttpPost]
            public IActionResult Delete(Department department)
            {


                var objFromDb = _dbContext.Departments.FirstOrDefault(x => x.Id == department.Id);

                if (objFromDb != null)
                {
                    _dbContext.Remove(objFromDb);
                    _dbContext.SaveChanges();
                    TempData["danger"] = "Record Deleted Successfully";
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    
}
