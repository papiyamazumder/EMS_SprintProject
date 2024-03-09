using EmsData.DataContext;
using EmsEntity;
using Microsoft.EntityFrameworkCore;

namespace EmsData.Repository
{
    /// <summary>
    /// Repository class for User_Master entity operations.
    /// </summary>
    public class User_MasterRepo : IUser_MasterRepo
    {
        private readonly EmsDbContext _context;

        /// <summary>
        /// Constructor for User_MasterRepo class.
        /// </summary>
        /// <param name="context">Instance of EmsDbContext.</param>
        public User_MasterRepo(EmsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user to be added.</param>
        /// <returns>Returns true if the user was added successfully, otherwise false.</returns>
        public bool AddUser(User_Master user)
        {
            _context.User_Masters.Add(user);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="user">The user to be updated.</param>
        /// <returns>Returns true if the user was updated successfully, otherwise false.</returns>
        public bool UpdateUser(User_Master user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes a user from the database by ID.
        /// </summary>
        /// <param name="ID">The ID of the user to be deleted.</param>
        /// <returns>Returns true if the user was deleted successfully, otherwise false.</returns>
        public bool DeleteUser_ID(string id)
        {
            User_Master user = _context.User_Masters.Find(id);
            _context.User_Masters.Remove(user);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retrieves a user from the database by ID.
        /// </summary>
        /// <param name="ID">The ID of the user to be retrieved.</param>
        /// <returns>Returns the User_Master object corresponding to the provided ID.</returns>
        public User_Master GetUser_ID(string id)
        {
            User_Master user = _context.User_Masters.Find(id);
            return user;
        }

        /// <summary>
        /// Retrieves a list of all users from the database.
        /// </summary>
        /// <returns>Returns a list of User_Master objects representing all users in the database.</returns>
        public List<User_Master> GetUserList()
        {
            List<User_Master> list = _context.User_Masters.ToList();
            return list;
        }

        /// <summary>
        /// Retrieves a user asynchronously based on the provided ID, password, and user type.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="password">The user password.</param>
        /// <param name="usertype">The user type.</param>
        /// <returns>An asynchronous task that represents the user with the specified ID, password, and user type.</returns>
        public async Task<User_Master> GetUserById(string id, string password, string usertype)
        {
            var authentication = await _context.User_Masters.FirstOrDefaultAsync(u => u.UserID == id);
            return authentication;
        }
    }
}
