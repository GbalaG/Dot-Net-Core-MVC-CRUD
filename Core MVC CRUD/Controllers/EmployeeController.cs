using Core_MVC_CRUD.Models;
using Core_MVC_CRUD.Repository;
using Core_MVC_CRUD.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository EmpReposittory;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            EmpReposittory = employeeRepository;
        }


        [HttpGet]
        public IActionResult EmployeeCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmployeeCreate(EmployeeCreateViewModel employee)
        {
            if (ModelState.IsValid)
            {
                Employee NewEmp = new Employee
                {
                    Name = employee.Name,
                    Department = employee.Department,
                    Salary = employee.Salary
                };
                EmpReposittory.Save(NewEmp);
                return RedirectToAction("EmployeeList");
            }
            return View();
        }

        [AllowAnonymous]
        public ViewResult EmployeeList()
        {
            var mode = EmpReposittory.GetEmployee();
            return View(mode);

        }

        [HttpGet]
        public ViewResult EmployeeEdit(int id)
        {
            Employee Emp = EmpReposittory.Edit(id);
            EmployeeEditViewModel model = new EmployeeEditViewModel
            {
                id = Emp.id,
                Name = Emp.Name,
                Department = Emp.Department,
                Salary = Emp.Salary

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EmployeeEdit(EmployeeEditViewModel employeeEdit)
        {
            if (ModelState.IsValid)
            {
                Employee Emp = EmpReposittory.Edit(employeeEdit.id);
                Emp.Name = employeeEdit.Name;
                Emp.Department = employeeEdit.Department;
                Emp.Salary = employeeEdit.Salary;

                Employee updateEmp = EmpReposittory.Update(Emp);
                return RedirectToAction("EmployeeList");
            }
            return View(employeeEdit);
        }
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            EmpReposittory.Delete(id);
            return RedirectToAction("EmployeeList");
        }

    }
}
