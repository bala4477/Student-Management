using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using AspCore1.Data;
using AspCore1.Models;


namespace AspCore1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> student = _dbContext.Students.ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newFileName = Guid.NewGuid().ToString();

                var upload = Path.Combine(webRootPath, @"images\student");

                var extension = Path.GetExtension(file[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }

                student.StudentPhoto = @"\images\student\" + newFileName + extension;

            }
            if (ModelState.IsValid)
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                TempData["success"] = "Record Created Successsfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            Student student = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            if (student != null)
            {
                return View(student);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newFileName = Guid.NewGuid().ToString();

                var upload = Path.Combine(webRootPath, @"images\student");

                var extension = Path.GetExtension(file[0].FileName);
                //remove old image

                var objFromDb = _dbContext.Students.AsNoTracking().FirstOrDefault(x => x.StudentId == student.StudentId);

                if (objFromDb.StudentPhoto != null)
                {
                    var oldImagepath = Path.Combine(webRootPath, objFromDb.StudentPhoto.Trim('\\'));
                    if (System.IO.File.Exists(oldImagepath))
                    {
                        System.IO.File.Delete(oldImagepath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }

                student.StudentPhoto = @"\images\student\" + newFileName + extension;

            }
            if (ModelState.IsValid)
            {
                var objFromDb = _dbContext.Students.AsNoTracking().FirstOrDefault(x => x.StudentId == student.StudentId);

                objFromDb.DepartmentId = student.DepartmentId;
                objFromDb.StudentId = student.StudentId;
                objFromDb.StudentName = student.StudentName;
                objFromDb.StudentEmail = student.StudentEmail;
                objFromDb.StudentPhone = student.StudentPhone;
                objFromDb.DateOfBirth = student.DateOfBirth;
                objFromDb.Gender = student.Gender;

                if (student.StudentPhoto != null)
                {
                    objFromDb.StudentPhoto = student.StudentPhoto;
                }

                _dbContext.Students.Update(objFromDb);
                _dbContext.SaveChanges();
                TempData["warning"] = "Record Updated Successsfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student student = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            if (!string.IsNullOrEmpty(student.StudentPhoto))
            {
                var objFromDb = _dbContext.Students.AsNoTracking().FirstOrDefault(x => x.StudentId == student.StudentId);

                if (objFromDb.StudentPhoto != null)
                {
                    var oldImagepath = Path.Combine(webRootPath, objFromDb.StudentPhoto.Trim('\\'));
                    if (System.IO.File.Exists(oldImagepath))
                    {
                        System.IO.File.Delete(oldImagepath);
                    }
                }
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                TempData["danger"] = "Record Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
