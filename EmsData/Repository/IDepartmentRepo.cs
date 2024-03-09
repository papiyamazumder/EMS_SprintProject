using EmsEntity;
public interface IDepartmentRepo
{
    /// <summary>
    /// Adds a new department to the repository.
    /// </summary>
    /// <param name="department">The department to add.</param>
    /// <returns>True if the department is added successfully; otherwise, false.</returns>
    bool AddDept(Department department);

    /// <summary>
    /// Updates an existing department in the repository.
    /// </summary>
    /// <param name="department">The department to update.</param>
    /// <returns>True if the department is updated successfully; otherwise, false.</returns>
    bool UpdateDept(Department department);

    /// <summary>
    /// Deletes a department from the repository by its ID.
    /// </summary>
    /// <param name="ID">The ID of the department to delete.</param>
    /// <returns>True if the department is deleted successfully; otherwise, false.</returns>
    bool DeleteDept_ID(int ID);

    /// <summary>
    /// Retrieves a department from the repository by its ID.
    /// </summary>
    /// <param name="ID">The ID of the department to retrieve.</param>
    /// <returns>The department entity.</returns>
    Department GetDepartment_ID(int ID);

    /// <summary>
    /// Retrieves a list of all departments from the repository.
    /// </summary>
    /// <returns>A list of department entities.</returns>
    List<Department> GetDepartmentList();
}
