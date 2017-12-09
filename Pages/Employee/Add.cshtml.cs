using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Cloud.Datastore.V1;


namespace HowzWebRazor003.Pages.Employee
{
    public class AddModel : PageModel
    {
        public string Message { get; set; }
        public Employee employee { get; set; }

        public void OnGet()
        {
            employee = new Employee();
            Message = "新增一筆員工資料";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            /*
            DatastoreDb db = GoogleCloudDatastore.CreateDb();

            var newEmployee = new Entity
            {
                Key = db.CreateKeyFactory("Employee").CreateIncompleteKey(),
                ["Name"] = this.employee.Name,
                ["Password"] = this.employee.Password,
                ["PersonId"] = this.employee.PersonId
            };
            var employeeKeys = db.Insert(new[] { newEmployee });
            */

            Console.WriteLine("Name: {0}, PersonId: {1}, Password: {2}", this.employee.Name, this.employee.PersonId, this.employee.Password);

            return RedirectToPage("/Employee/Index");
        }
    }
}
