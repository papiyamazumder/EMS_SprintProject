using EmsData.DataContext;
using EmsEntity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmsData.Repository
{
    /// <summary>
    /// Repository for handling employee data operations.
    /// </summary>
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepo"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public EmployeeRepo(EmsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="emp">The employee to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool AddEmp(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        /// <param name="emp">The updated employee information.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool UpdateEmp(Employee emp)
        {
            _context.Entry(emp).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes an employee from the database by ID.
        /// </summary>
        /// <param name="ID">The ID of the employee to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool DeleteEmp_ID(string ID)
        {
            Employee emp = _context.Employees.Find(ID);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retrieves a Employee entity from the database by its ID.
        /// </summary>
        /// <param name="ID">The ID of the Employee to be retrieved.</param> 
        /// <returns>The Employee entity if found; otherwise, null.</returns>
        public Employee GetEmployee_ID(string ID)
        {
            Employee emp = _context.Employees.Find(ID);
            return emp;
        }

        /// <summary>
        /// Retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>A list of employees.</returns>
        public List<Employee> GetAllEmpList()
        {
            List<Employee> list = _context.Employees.ToList();
            return list;
        }
    }
}
