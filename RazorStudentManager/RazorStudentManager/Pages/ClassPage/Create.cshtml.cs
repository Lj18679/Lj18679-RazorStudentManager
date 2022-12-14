using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorStudentManager.AppData;
using RazorStudentManager.Model;

namespace RazorStudentManager.Pages.ClassPage
{
    public class CreateModel : PageModel
    {
        private readonly RazorStudentManager.AppData.AppDbContext _context;

        public CreateModel(RazorStudentManager.AppData.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]  //和前端代码绑定
        public StudentClass StudentClass { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentClasses.Add(StudentClass);
            await _context.SaveChangesAsync();//执行到数据库

            return RedirectToPage("./Index");
        }
    }
}
