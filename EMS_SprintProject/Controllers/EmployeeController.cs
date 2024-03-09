using Microsoft.AspNetCore.Mvc;
using EmsEntity;
using System.Linq.Dynamic.Core;
using EmsBusiness.Services;
using NLog;

namespace EMS_SprintProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly EmployeeService _empSer;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="empSer">The employee service.</param>
        public EmployeeController(EmployeeService empSer)
        {
            _empSer = empSer;
            _logger.Info("EmployeeController Constructor");
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="emp">The employee to add.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
        public IActionResult AddEmp(Employee emp)
        {
            try
            {
                _logger.Info("AddEmp method entered");
                bool status = _empSer.AddEmp(emp);

                if (!ModelState.IsValid)
                {
                    _logger.Error("AddEmp failed due to invalid model state");
                    return BadRequest(ModelState);
                }
                else if (!status)
                {
                    _logger.Error("AddEmp failed");
                    return BadRequest("Failed to insert Employee records");
                }
                else
                {
                    _logger.Info("AddEmp successful");
                    return Ok(new { status = "Inserted" });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in AddEmp method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="emp">The employee to update.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut]
        public IActionResult UpdateEmp(Employee emp)
        {
            try
            {
                _logger.Info("UpdateEmp method entered");
                bool status = _empSer.UpdateEmp(emp);

                if (status)
                {
                    _logger.Info("UpdateEmp successful");
                    return Ok(new { status = "Updated" });
                }
                else
                {
                    _logger.Error("UpdateEmp failed");
                    return BadRequest("Failed to update Employee records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in UpdateEmp method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete]
        public IActionResult DeleteEmp_ID(string id)
        {
            try
            {
                _logger.Info("DeleteEmp_ID method entered");
                bool status = _empSer.DeleteEmp_ID(id);

                if (status)
                {
                    _logger.Info("DeleteEmp_ID successful");
                    return Ok(new { status = "Deleted" });
                }
                else
                {
                    _logger.Error("DeleteEmp_ID failed");
                    return BadRequest("Failed to delete Employee records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in DeleteEmp_ID method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetAllGradeByID")]
        public IActionResult GetEmployee_ID(string id)
        {
            try
            {
                _logger.Info("GetEmployee_ID method entered");
                Employee emp = _empSer.GetEmployee_ID(id);

                if (emp != null)
                {
                    _logger.Info("GetEmployee_ID successful");
                    return Ok(emp);
                }
                else
                {
                    _logger.Warn("GetEmployee_ID failed - Employee not found");
                    return NotFound("Employee not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetEmployee_ID method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets a list of all employees.
        /// </summary>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetAllUser")]
        public IActionResult GetAllEmpList()
        {
            try
            {
                _logger.Info("GetAllEmpList method entered");
                var list = _empSer.GetAllEmpList();

                if (list != null)
                {
                    _logger.Info("GetAllEmpList successful");
                    return Ok(list);
                }
                else
                {
                    _logger.Warn("GetAllEmpList failed - Employee not found");
                    return NotFound("Employee not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetAllEmpList method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
