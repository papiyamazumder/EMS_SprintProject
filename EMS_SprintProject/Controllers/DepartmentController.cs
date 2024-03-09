using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmsBusiness;
using EmsBusiness.Services;
using EmsEntity;
using EmsData.Repository;
using NLog;
using System;

namespace EMS_SprintProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly DepartmentService _departmentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentController"/> class.
        /// </summary>
        /// <param name="departmentService">The department service.</param>
        public DepartmentController(DepartmentService departmentService)
        {
            _logger.Info("DepartmentController Constructor");
            _departmentService = departmentService;
        }

        /// <summary>
        /// Adds a new department.
        /// </summary>
        /// <param name="dept">The department to add.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
        public IActionResult AddDepartment(Department dept)
        {
            try
            {
                _logger.Info("AddDepartment method entered");
                bool status = _departmentService.AddDept(dept);

                if (!ModelState.IsValid)
                {
                    _logger.Error("AddDepartment failed due to invalid model state");
                    return BadRequest(ModelState);
                }
                else if (!status)
                {
                    _logger.Error("AddDepartment failed");
                    return BadRequest("Failed to insert department records");
                }
                else
                {
                    _logger.Info("AddDepartment successful");
                    return Ok(new { status = "Inserted" });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in AddDepartment method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="dept">The department to update.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut]
        public IActionResult UpdateDept(Department dept)
        {
            try
            {
                _logger.Info("UpdateDept method entered");
                bool status = _departmentService.UpdateDept(dept);

                if (status)
                {
                    _logger.Info("UpdateDept successful");
                    return Ok(new { status = "Updated" });
                }
                else
                {
                    _logger.Error("UpdateDept failed");
                    return BadRequest("Failed to update department records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in UpdateDept method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Deletes a department by ID.
        /// </summary>
        /// <param name="id">The ID of the department to delete.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete]
        public IActionResult DeleteDept_ID(int id)
        {
            try
            {
                _logger.Info("DeleteDept_ID method entered");
                bool status = _departmentService.DeleteDept_ID(id);

                if (status)
                {
                    _logger.Info("DeleteDept_ID successful");
                    return Ok(new { status = "Deleted" });
                }
                else
                {
                    _logger.Error("DeleteDept_ID failed");
                    return BadRequest("Failed to delete department records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in DeleteDept_ID method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets a department by ID.
        /// </summary>
        /// <param name="id">The ID of the department to retrieve.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetDepartmentById")]
        public IActionResult GetDepartment_ID(int id)
        {
            try
            {
                _logger.Info("GetDepartment_ID method entered");
                Department deptList = _departmentService.GetDepartment_ID(id);

                if (deptList != null)
                {
                    _logger.Info("GetDepartment_ID successful");
                    return Ok(deptList);
                }
                else
                {
                    _logger.Warn("GetDepartment_ID failed - Department list not found");
                    return NotFound("Department list not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetDepartment_ID method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets a list of all departments.
        /// </summary>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetAllDepartments")]
        public IActionResult GetDepartmentList()
        {
            try
            {
                _logger.Info("GetDepartmentList method entered");
                var list = _departmentService.GetDepartmentList();

                if (list != null)
                {
                    _logger.Info("GetDepartmentList successful");
                    return Ok(list);
                }
                else
                {
                    _logger.Warn("GetDepartmentList failed - No departments found");
                    return NotFound("No departments found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetDepartmentList method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
