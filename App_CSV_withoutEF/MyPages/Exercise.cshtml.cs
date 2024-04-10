using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace App_CSV_withoutEF.MyPages
{
    public class ExerciseModel : PageModel
    {
        public Employee employee { get; set; }
        public List<SelectListItem> listItems { get; set; }
        public string Message { get; set; }
        [BindProperty]public string Message1 { get; set; }

        public ExerciseModel(Employee employee)
        {
            this.employee = employee;
        }
        public void OnGet()
        {
            listItems = new List<SelectListItem>();
            List<Employee> employees = new List<Employee>() 
            {
                new Employee() { Name = "Иван" },
                new Employee() { Name = "Пётр" },
                new Employee() { Name = "Сидор" },
                new Employee() { Name = "Семён" }
            };

            //listItems = employees.Select(s => new SelectListItem() { Value = s.Name, Text = s.Name }).ToList();


            foreach (Employee employee in employees)
            {
                listItems.Add(new SelectListItem() { Value = employee.Name, Text = employee.Name });
            }

            //ViewData["listItems"] = listItems;
        }
        public void OnPost() 
        {
            Message = Message1;
            listItems = new List<SelectListItem>();
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Name = "Иван" },
                new Employee() { Name = "Пётр" },
                new Employee() { Name = "Сидор" },
                new Employee() { Name = "Семён" }
            };

            listItems = employees.Select(s => new SelectListItem() { Value = s.Name, Text = s.Name }).ToList();
            
        }
    }
}
