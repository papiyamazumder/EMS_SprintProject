using EmsEntity;

namespace EmsData.Repository
{
    /// <summary>
    /// Interface for employee repository, defining methods for CRUD operations on employee entities.
    /// </summary>
    public interface IEmployeeRepo
    {
        /// <summary>
        /// Adds a new employee to the repository.
        /// </summary>
        /// <param name="emp">The employee to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool AddEmp(Employee emp);

        /// <summary>
        /// Updates an existing employee in the repository.
        /// </summary>
        /// <param name="emp">The updated employee information.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool UpdateEmp(Employee emp);

        /// <summary>
        /// Deletes an employee from the repository by ID.
        /// </summary>
        /// <param name="ID">The ID of the employee to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool DeleteEmp_ID(string ID);

        /// <summary>
        /// Retrieves an Employee from the repository by its ID.
        /// </summary>
        /// <param name="ID">The ID of the employee to retrieve.</param>
        /// <returns>The Employee entity.</returns>
        Employee GetEmployee_ID(string ID); 

        /// <summary>
        /// Retrieves a list of all employees from the repository.
        /// </summary>
        /// <returns>A list of employees.</returns>
        List<Employee> GetAllEmpList();
    }
}
