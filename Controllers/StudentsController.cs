using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApp.Models.Entities;
using CrudApp.Data;

namespace CrudApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public StudentsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
              
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student viewModel)
        {

            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return RedirectToAction("List","Students");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _dbContext.Students.ToListAsync();
            return View(students);
        }

         public async Task<IActionResult> Edit(int id)
        {
            
            var student = await _dbContext.Students.FindAsync(id);
            // Console.WriteLine(student);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student viewModel)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == viewModel.Id);
            if (student != null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("List","Students");
        }
       [HttpPost]
public async Task<IActionResult> Delete(Student viewModel)
{
    var student = await _dbContext.Students.FindAsync(viewModel.Id);
    if (student != null)
    {
        _dbContext.Students.Remove(student); // Remove the found student, not the view model
        await _dbContext.SaveChangesAsync();
    }
    return RedirectToAction("List", "Students");
}

    }
}
