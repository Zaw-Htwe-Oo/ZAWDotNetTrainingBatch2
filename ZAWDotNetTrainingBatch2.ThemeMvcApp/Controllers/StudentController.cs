using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZAWDotNetTrainingBatch2.ThemeMvcApp.Database.AppDbContexModels;
namespace ZAWDotNetTrainingBatch2.ThemeMvcApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var students = await _context.TblStudents.Where(x => x.DeleteFlag == false).ToListAsync();
            return View(students);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentNo,StudentName,FatherName,DateOfBirth,Gender,Address,MobileNo")] TblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                tblStudent.DeleteFlag = false;
                _context.Add(tblStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStudent);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent == null || tblStudent.DeleteFlag == true) return NotFound();
            return View(tblStudent);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentNo,StudentName,FatherName,DateOfBirth,Gender,Address,MobileNo,DeleteFlag")] TblStudent tblStudent)
        {
            if (id != tblStudent.StudentId) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(tblStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStudent);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var tblStudent = await _context.TblStudents.FirstOrDefaultAsync(m => m.StudentId == id && m.DeleteFlag == false);
            if (tblStudent == null) return NotFound();
            return View(tblStudent);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent != null)
            {
                tblStudent.DeleteFlag = true; // Soft Delete
                _context.Update(tblStudent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
