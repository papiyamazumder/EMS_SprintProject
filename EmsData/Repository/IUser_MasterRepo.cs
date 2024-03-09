using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsData.Repository
{
    public interface IUser_MasterRepo
    {
        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>True if the user is added successfully; otherwise, false.</returns>
        bool AddUser(User_Master user);

        /// <summary>
        /// Updates an existing user in the repository.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>True if the user is updated successfully; otherwise, false.</returns>
        bool UpdateUser(User_Master user);

        /// <summary>
        /// Deletes a user from the repository by its ID.
        /// </summary>
        /// <param name="ID">The ID of the user to delete.</param>
        /// <returns>True if the user is deleted successfully; otherwise, false.</returns>
        bool DeleteUser_ID(string id);

        /// <summary>
        /// Retrieves a grade from the repository by its ID.
        /// </summary>
        /// <param name="ID">The ID of the grade to retrieve.</param>
        /// <returns>The grade entity if found; otherwise, null.</returns>
        User_Master GetUser_ID(string id);

        /// <summary>
        /// Retrieves a list of all grades from the repository.
        /// </summary>
        /// <returns>A list of grade entities.</returns>
        List<User_Master> GetUserList();

        /// <summary>
        /// Retrieves a user based on the provided ID, password, and user type asynchronously.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="password">The user password.</param>
        /// <param name="usertype">The user type.</param>
        /// <returns>An asynchronous task that represents the user with the specified ID, password, and user type.</returns>
        public Task<User_Master> GetUserById(string id, string password, string usertype);

    }
}
