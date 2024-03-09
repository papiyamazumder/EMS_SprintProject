using EmsData.DataContext;
using EmsEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsData.Repository
{
    public class Grade_MasterRepo : IGrade_MasterRepo
    {
        private readonly EmsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grade_MasterRepo"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public Grade_MasterRepo(EmsDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new grade to the database.
        /// </summary>
        /// <param name="grade">The grade to add.</param>
        /// <returns>True if the grade is added successfully; otherwise, false.</returns>
        public bool AddGrade(Grade_Master grade)
        {
            _context.Grade_Masters.Add(grade);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Updates an existing grade in the database.
        /// </summary>
        /// <param name="grade">The grade to update.</param>
        /// <returns>True if the grade is updated successfully; otherwise, false.</returns>
        public bool UpdateGrade(Grade_Master grade)
        {
            _context.Entry(grade).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes a grade from the database by its code.
        /// </summary>
        /// <param name="Code">The code of the grade to delete.</param>
        /// <returns>True if the grade is deleted successfully; otherwise, false.</returns>
        public bool DeleteGrade_Code(string code)
        {
            Grade_Master grade = _context.Grade_Masters.Find(code);
            _context.Grade_Masters.Remove(grade);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retrieves a grade from the database by its code.
        /// </summary>
        /// <param name="Code">The code of the grade to retrieve.</param>
        /// <returns>The grade entity.</returns>
        public Grade_Master GetDepartment_Code(string code)
        {
            Grade_Master grade = _context.Grade_Masters.Find(code);
            return grade;
        }

        /// <summary>
        /// Retrieves a list of all grades from the database.
        /// </summary>
        /// <returns>A list of grade entities.</returns>
        public List<Grade_Master> GetGradeList()
        {
            List<Grade_Master> list = _context.Grade_Masters.ToList();
            return list;
        }
    }
}
