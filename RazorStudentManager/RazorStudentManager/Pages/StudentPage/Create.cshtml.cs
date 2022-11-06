using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorStudentManager.AppData;
using RazorStudentManager.Model;

namespace RazorStudentManager.Pages.StudentPage
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        public SelectList ClassList { get; set; }

        [BindProperty]//��ǰ�˴����
        public Student   Student { get; set; }
        public async Task OnGet()//��ȡ����
        {
           var items= await  _db.StudentClasses.ToListAsync();
            ClassList = new SelectList(items, "Id","ClassName");
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
              await _db.AddAsync(Student);//���ӵ����ݿ�������
              await _db.SaveChangesAsync();//ִ�е����ݿ�
              return RedirectToPage("Index");
              
            }
            else
            {
                return Page();
            }
        }
    }
}
