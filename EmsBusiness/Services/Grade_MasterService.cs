using EmsData.Repository;
using EmsEntity;

namespace EmsBusiness.Services
{
    /// <summary>
    /// Service class for managing grade masters.
    /// </summary>
    public class Grade_MasterService
    {
        private readonly IGrade_MasterRepo _gradeRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grade_MasterService"/> class.
        /// </summary>
        /// <param name="gradeRepo">The grade master repository.</param>
        public Grade_MasterService(IGrade_MasterRepo gradeRepo)
        {
            _gradeRepo = gradeRepo;
        }

        /// <summary>
        /// Adds a new grade master.
        /// </summary>
        /// <param name="grade">The grade master to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool AddGrade(Grade_Master grade)
        {
            return _gradeRepo.AddGrade(grade);
        }

        /// <summary>
        /// Updates an existing grade master.
        /// </summary>
        /// <param name="grade">The updated grade master information.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool UpdateGrade(Grade_Master grade)
        {
            return _gradeRepo.UpdateGrade(grade);
        }

        /// <summary>
        /// Deletes a grade master by code.
        /// </summary>
        /// <param name="Code">The code of the grade master to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool DeleteGrade_Code(string code)
        {
            return _gradeRepo.DeleteGrade_Code(code);
        }

        /// <summary>
        /// Retrieves a grade master by code.
        /// </summary>
        /// <param name="Code">The code of the grade master to retrieve.</param>
        /// <returns>The grade master entity if found, otherwise null.</returns>
        public Grade_Master GetDepartment_Code(string code)
        {
            return _gradeRepo.GetDepartment_Code(code);
        }

        /// <summary>
        /// Retrieves a list of all grade masters.
        /// </summary>
        /// <returns>A list of grade masters.</returns>
        public List<Grade_Master> GetGradeList()
        {
            return _gradeRepo.GetGradeList();
        }
    }
}
