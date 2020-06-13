using Core_MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVC_CRUD.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetEmployee()
        {
            return _context.employees;
        }

        public Employee Save(Employee Emp)
        {
            _context.employees.Add(Emp);
            _context.SaveChanges();
            return Emp;
        }
        public Employee Update(Employee EditEmp)
        {
            var employee = _context.employees.Attach(EditEmp);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return EditEmp;
        }

        public Employee Edit(int id)
        {
            return _context.employees.Find(id);
        }

        public Employee Delete(int id)
        {
            Employee Emp = _context.employees.Find(id);
            if (Emp != null)
            {
                _context.Remove(Emp);
                _context.SaveChanges();
            }
            return Emp;
        }
    }
}
