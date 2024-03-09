using EmsData.Repository;
using EmsEntity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace EmsBusiness.Services
{
    /// <summary>
    /// Service class for managing employee operations.
    /// </summary>
    public class EmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="employeeRepo">The employee repository.</param>
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        /// <summary>
        /// Adds an employee to the database.
        /// </summary>
        /// <param name="emp">The employee to add.</param>
        /// <returns>True if the employee was added successfully, otherwise false.</returns>
        public bool AddEmp(Employee emp)
        {
            return _employeeRepo.AddEmp(emp);
        }

        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        /// <param name="emp">The updated employee information.</param>
        /// <returns>True if the employee was updated successfully, otherwise false.</returns>
        public bool UpdateEmp(Employee emp)
        {
            return _employeeRepo.UpdateEmp(emp);
        }

        /// <summary>
        /// Deletes an employee from the database by their ID.
        /// </summary>
        /// <param name="ID">The ID of the employee to delete.</param>
        /// <returns>True if the employee was deleted successfully, otherwise false.</returns>
        public bool DeleteEmp_ID(string id)
        {
            return _employeeRepo.DeleteEmp_ID(id);
        }

        /// <summary>
        /// Retrieves a employee by ID.
        /// </summary>
        /// <param name="ID">The ID of the employee to retrieve.</param>
        /// <returns>The employee entity if found, otherwise null.</returns>
        public Employee GetEmployee_ID(string id)
        {
            return _employeeRepo.GetEmployee_ID(id);
        }

        /// <summary>
        /// Retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public List<Employee> GetAllEmpList()
        {
            return _employeeRepo.GetAllEmpList();
        }
    }
}
