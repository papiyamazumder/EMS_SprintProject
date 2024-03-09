using EmsData;
using EmsEntity;
using System.Collections.Generic;

namespace EmsBusiness.Services
{
    /// <summary>
    /// Service class for managing departments.
    /// </summary>
    public class DepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class.
        /// </summary>
        /// <param name="departmentRepo">The department repository.</param>
        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        /// <summary>
        /// Adds a new department.
        /// </summary>
        /// <param name="dept">The department to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool AddDept(Department dept)
        {
            return _departmentRepo.AddDept(dept);
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="dept">The updated department information.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool UpdateDept(Department dept)
        {
            return _departmentRepo.UpdateDept(dept);
        }

        /// <summary>
        /// Deletes a department by ID.
        /// </summary>
        /// <param name="ID">The ID of the department to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool DeleteDept_ID(int ID)
        {
            return _departmentRepo.DeleteDept_ID(ID);
        }

        /// <summary>
        /// Retrieves a department by ID.
        /// </summary>
        /// <param name="ID">The ID of the department to retrieve.</param>
        /// <returns>The department entity if found, otherwise null.</returns>
        public Department GetDepartment_ID(int ID)
        {
            return _departmentRepo.GetDepartment_ID(ID);
        }

        /// <summary>
        /// Retrieves a list of all departments.
        /// </summary>
        /// <returns>A list of departments.</returns>
        public List<Department> GetDepartmentList()
        {
            return _departmentRepo.GetDepartmentList();
        }
    }
}
