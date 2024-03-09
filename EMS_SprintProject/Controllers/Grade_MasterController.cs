using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmsEntity;
using EmsBusiness.Services;
using NLog;
using System;

namespace EMS_SprintProject.Controllers
{
    /// <summary>
    /// Controller for managing Grade Master entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Grade_MasterController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly Grade_MasterService _grade;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grade_MasterController"/> class.
        /// </summary>
        /// <param name="grade">The grade service.</param>
        public Grade_MasterController(Grade_MasterService grade)
        {
            _logger.Info("Grade_MasterController Constructor");
            _grade = grade;
        }

        /// <summary>
        /// Adds a new grade.
        /// </summary>
        /// <param name="grade">The grade to add.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
        public IActionResult AddGrade(Grade_Master grade)
        {
            try
            {
                _logger.Info("AddGrade method entered");
                bool status = _grade.AddGrade(grade);

                if (!ModelState.IsValid)
                {
                    _logger.Error("AddGrade failed due to invalid model state");
                    return BadRequest(ModelState);
                }
                else if (!status)
                {
                    _logger.Error("AddGrade failed");
                    return BadRequest("Failed to insert Grade Master records");
                }
                else
                {
                    _logger.Info("AddGrade successful");
                    return Ok(new { status = "Inserted" });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in AddGrade method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Updates an existing grade.
        /// </summary>
        /// <param name="grade">The grade to update.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut]
        public IActionResult UpdateGrade(Grade_Master grade)
        {
            try
            {
                _logger.Info("UpdateGrade method entered");
                bool status = _grade.UpdateGrade(grade);

                if (status)
                {
                    _logger.Info("UpdateGrade successful");
                    return Ok(new { status = "Updated" });
                }
                else
                {
                    _logger.Error("UpdateGrade failed");
                    return BadRequest("Failed to update Grade Master records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in UpdateGrade method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Deletes a grade by code.
        /// </summary>
        /// <param name="code">The code of the grade to delete.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete]
        public IActionResult DeleteGrade_Code(string code)      // (Grade_Master grade)
        {
            try
            {
                _logger.Info("DeleteGrade_Code method entered");
                bool status = _grade.DeleteGrade_Code(code);

                if (status)
                {
                    _logger.Info("DeleteGrade_Code successful");
                    return Ok(new { status = "Deleted" });
                }
                else
                {
                    _logger.Error("DeleteGrade_Code failed");
                    return BadRequest("Failed to delete Grade Master records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in DeleteGrade_Code method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets a grade by code.
        /// </summary>
        /// <param name="code">The code of the grade to retrieve.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetAllGradeByID")]
        public IActionResult GetDepartment_Code(string code)
        {
            try
            {
                _logger.Info("GetDepartment_Code method entered");
                Grade_Master grade = _grade.GetDepartment_Code(code);

                if (grade != null)
                {
                    _logger.Info("GetDepartment_Code successful");
                    return Ok(grade);
                }
                else
                {
                    _logger.Error("GetDepartment_Code failed - Grade Master not found");
                    return NotFound("Grade Master not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetDepartment_Code method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets a list of all grades.
        /// </summary>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetAllGrade")]
        public IActionResult GetGradeList()
        {
            try
            {
                _logger.Info("GetGradeList method entered");
                var list = _grade.GetGradeList();

                if (list != null)
                {
                    _logger.Info("GetGradeList successful");
                    return Ok(list);
                }
                else
                {
                    _logger.Error("GetGradeList failed - Grade Master not found");
                    return NotFound("Grade Master not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetGradeList method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
