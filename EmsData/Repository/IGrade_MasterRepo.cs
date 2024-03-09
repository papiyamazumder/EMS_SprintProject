using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsData.Repository
{
    public interface IGrade_MasterRepo
    {
        /// <summary>
        /// Adds a new grade to the repository.
        /// </summary>
        /// <param name="grade">The grade to add.</param>
        /// <returns>True if the grade is added successfully; otherwise, false.</returns>
        bool AddGrade(Grade_Master grade);

        /// <summary>
        /// Updates an existing grade in the repository.
        /// </summary>
        /// <param name="grade">The grade to update.</param>
        /// <returns>True if the grade is updated successfully; otherwise, false.</returns>
        bool UpdateGrade(Grade_Master grade);

        /// <summary>
        /// Deletes a grade from the repository by its code.
        /// </summary>
        /// <param name="Code">The code of the grade to delete.</param>
        /// <returns>True if the grade is deleted successfully; otherwise, false.</returns>
        bool DeleteGrade_Code(string code);

        /// <summary>
        /// Retrieves a grade from the repository by its code.
        /// </summary>
        /// <param name="Code">The code of the grade to retrieve.</param>
        /// <returns>The grade entity if found; otherwise, null.</returns>
        Grade_Master GetDepartment_Code(string code);

        /// <summary>
        /// Retrieves a list of all grades from the repository.
        /// </summary>
        /// <returns>A list of grade entities.</returns>
        List<Grade_Master> GetGradeList();

    }
}
