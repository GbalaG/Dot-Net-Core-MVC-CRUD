using Core_MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVC_CRUD.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployee();
        Employee Save(Employee Emp);
        Employee Update(Employee EditEmp);
        Employee Edit(int id);
        Employee Delete(int id);
    }
}
