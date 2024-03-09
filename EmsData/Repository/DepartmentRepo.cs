using EmsEntity;
using EmsData.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EmsData.Repository
{
    /// <summary>
    /// Repository class for performing CRUD operations on Department entities.
    /// </summary>
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly EmsDbContext _context;
        public DepartmentRepo(EmsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new Department entity to the database.
        /// </summary>
        /// <param name="department">The Department entity to be added.</param> 
        /// [param->When referring to "param" in the context of dynamic queries, it likely refers to parameters that are used to add flexibility and security to the query construction process. These parameters serve as placeholders for values that will be supplied at runtime, allowing for dynamic query generation while mitigating the risk of SQL injection attacks.]
        /// <returns>True if the Department is successfully added; otherwise, false.</returns>
        public bool AddDept(Department department)
        {
            _context.Departments.Add(department);
            //_context.Database.ExecuteSqlRaw("INSERT INTO Departments (Dept_Name) VALUES ({0})", department.Dept_Name);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Updates an existing Department entity in the database.
        /// </summary>
        /// <param name="department">The updated Department entity.</param>
        /// <returns>True if the Department is successfully updated; otherwise, false.</returns>
        public bool UpdateDept(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes a Department entity from the database by its ID.
        /// </summary>
        /// <param name="ID">The ID of the Department to be deleted.</param>
        /// <returns>True if the Department is successfully deleted; otherwise, false.</returns>
        public bool DeleteDept_ID(int ID)
        {
            Department department = _context.Departments.Find(ID);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retrieves a Department entity from the database by its ID.
        /// </summary>
        /// <param name="ID">The ID of the Department to be retrieved.</param> 
        /// <returns>The Department entity if found; otherwise, null.</returns>
        public Department GetDepartment_ID(int ID)
        {
            Department department = _context.Departments.Find(ID);
            return department;
        }

        /// <summary>
        /// Retrieves a list of all Department entities from the database.
        /// </summary>
        /// <returns>A list of Department entities.</returns>
        public List<Department> GetDepartmentList()
        {
            List<Department> list = _context.Departments.ToList();
            return list;
        }
    }
}
