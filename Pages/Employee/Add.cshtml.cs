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

        [BindProperty]
        public Employee employee { get; set; }

        public void OnGet()
        {
            employee = new Employee();
            Message = "新增一筆員工資料";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            Console.WriteLine("Step01: Model State is Valid.");
            DatastoreDb db = GoogleCloudDatastore.CreateDb();
            Console.WriteLine("Step02: Create Datastore DB");

            var newEmployee = new Entity
            {
                Key = db.CreateKeyFactory("Employee").CreateIncompleteKey(),
                //["Name"] = "郭靖",
                //["Password"] = "abcdefghij",
                //["PersonId"] = "M123456789"
                ["Name"] = employee.Name,
                ["Password"] = employee.Password,
                ["PersonId"] = employee.PersonId


            };
            Console.WriteLine("Step03: Construct Entity - Name: {0}", employee.Name);


            var employeeKeys = db.Insert(new[] { newEmployee });
            Console.WriteLine("Step04: Insert to DB");

                //["Name"] = employee.Name,
                //["Password"] = employee.Password,
                //["PersonId"] = employee.PersonId


            return RedirectToPage("/Employee/Index");
        }
    }
}
