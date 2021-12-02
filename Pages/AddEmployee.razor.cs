using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UTS.Models;
using UTS.Services;

namespace UTS.Pages
{
    public partial class AddEmployee
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();


        protected async override Task OnInitializedAsync()
        {

            Departments = (await DepartmentService.GetAll()).ToList();
        }

        protected async Task HandleValidSubmit(){
            Employee.PhotoPath = "/images/nophoto.jpg";
            Employee result = await EmployeeService.Add(Employee);
            NavigationManager.NavigateTo("employeepage");
        }
    }
}