using EmsData.Repository;
using EmsEntity;
using System.Collections.Generic;

namespace EmsBusiness.Services
{
    /// <summary>
    /// Service class for managing user master entities.
    /// </summary>
    public class User_MasterService
    {
        private readonly IUser_MasterRepo _userRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="User_MasterService"/> class.
        /// </summary>
        /// <param name="userRepo">The user master repository.</param>
        public User_MasterService(IUser_MasterRepo userRepo)
        {
            _userRepo = userRepo;
        }

        /// <summary>
        /// Adds a new user master.
        /// </summary>
        /// <param name="user">The user master to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool AddUser(User_Master user)
        {
            return _userRepo.AddUser(user);
        }

        /// <summary>
        /// Updates an existing user master.
        /// </summary>
        /// <param name="user">The updated user master information.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool UpdateUser(User_Master user)
        {
            return _userRepo.UpdateUser(user);
        }

        /// <summary>
        /// Deletes a user master by ID.
        /// </summary>
        /// <param name="ID">The ID of the user master to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public bool DeleteUser(string id)
        {
            return _userRepo.DeleteUser_ID(id);
        }

        /// <summary>
        /// Retrieves a user master by ID.
        /// </summary>
        /// <param name="ID">The ID of the user master to retrieve.</param>
        /// <returns>The user master entity if found, otherwise null.</returns>
        public User_Master GetUser_ID(string id)
        {
            return _userRepo.GetUser_ID(id);
        }

        /// <summary>
        /// Retrieves a list of all user masters.
        /// </summary>
        /// <returns>A list of user masters.</returns>
        public List<User_Master> GetUsers()
        {
            return _userRepo.GetUserList();
        }
    }
}
