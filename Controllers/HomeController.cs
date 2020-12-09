using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpCodeAssignmentOne.Data;
using SharpCodeAssignmentOne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SharpCodeAssignmentOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly Alert _alert;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, Alert alert)
        {
            _context = context;
            _logger = logger;
            _alert = alert;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Students()
        {
            return View(await _context.StudentInfo.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {

            var student = await _context.StudentInfo
                .SingleOrDefaultAsync(m => m.StudentInfoID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentInfoFirstName,StudentInfoLastName,StudentInfoSex,StudentInfoAge,StudentInfoClass,StudentInfoID")] StudentInfo student, string message, string action)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                action = "registered";
                message = _alert.Success(student.StudentInfoFirstName, action);
                TempData["Message"] = message;
                return RedirectToAction(nameof(Students));
            }
            TempData.Keep("Message");
            return View(student);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.StudentInfo.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentInfoFirstName,StudentInfoLastName,StudentInfoSex,StudentInfoAge,StudentInfoClass,StudentInfoID")]   StudentInfo student, string message, string action)
        {
            if (id != student.StudentInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    action = "edited";
                    message = _alert.Success(student.StudentInfoFirstName, action);
                    TempData["Message"] = message;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentInfoExists(student.StudentInfoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Students));
            }
            TempData.Keep("Message");
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.StudentInfo
                .FirstOrDefaultAsync(m => m.StudentInfoID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.StudentInfo.FindAsync(id);
            _context.StudentInfo.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Students));
        }

        private bool StudentInfoExists(int id)
        {
            return _context.StudentInfo.Any(e => e.StudentInfoID == id);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
