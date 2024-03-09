using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmsEntity;
using EmsBusiness;
using EmsBusiness.Services;
using System.Diagnostics;
using NLog;
using System;

namespace EMS_SprintProject.Controllers
{
    /// <summary>
    /// Controller for managing User Master entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class User_MasterController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly User_MasterService _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="User_MasterController"/> class.
        /// </summary>
        /// <param name="user">The user master service.</param>
        public User_MasterController(User_MasterService user)
        {
            _logger.Info("User_MasterController Constructor");
            _user = user;
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
        public IActionResult AddUser(User_Master user)
        {
            try
            {
                _logger.Info("AddUser method entered");
                bool status = _user.AddUser(user);

                if (!ModelState.IsValid)
                {
                    _logger.Error("AddUser failed due to invalid model state");
                    return BadRequest(ModelState);
                }
                else if (!status)
                {
                    _logger.Error("AddUser failed");
                    return BadRequest("Failed to insert User Master records");
                }
                else
                {
                    _logger.Info("AddUser successful");
                    return Ok(new { status = "Inserted" });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in AddUser method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut]
        public IActionResult UpdateUser(User_Master user)
        {
            try
            {
                _logger.Info("UpdateUser method entered");
                bool status = _user.UpdateUser(user);

                if (status)
                {
                    _logger.Info("UpdateUser successful");
                    return Ok(new { status = "Updated" });
                }
                else
                {
                    _logger.Error("UpdateUser failed");
                    return BadRequest("Failed to update User Master records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in UpdateUser method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _logger.Info("DeleteUser method entered");
                bool status = _user.DeleteUser(id);

                if (status)
                {
                    _logger.Info("DeleteUser successful");
                    return Ok(new { status = "Deleted" });
                }
                else
                {
                    _logger.Error("DeleteUser failed");
                    return BadRequest("Failed to delete User Master records");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in DeleteUser method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="code">The ID of the user to retrieve.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetAllGradeByID")]
        public IActionResult GetUser_ID(string code)
        {
            try
            {
                _logger.Info("GetUser_ID method entered");
                User_Master user = _user.GetUser_ID(code);

                if (user != null)
                {
                    _logger.Info("GetUser_ID successful");
                    return Ok(user);
                }
                else
                {
                    _logger.Error("GetUser_ID failed - User Master not found");
                    return NotFound("User Master not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetUser_ID method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        /// <summary>
        /// Gets a list of all users.
        /// </summary>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("GetAllUser")]
        public IActionResult GetUsers()
        {
            try
            {
                _logger.Info("GetUsers method entered");
                var list = _user.GetUsers();

                if (list != null)
                {
                    _logger.Info("GetUsers successful");
                    return Ok(list);
                }
                else
                {
                    _logger.Error("GetUsers failed - User Master not found");
                    return NotFound("User Master not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred in GetUsers method");
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
