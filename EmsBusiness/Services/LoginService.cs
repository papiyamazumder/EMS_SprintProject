using EmsData.Repository;
using EmsEntity;

namespace EmsBusiness.Services
{
    /// <summary>
    /// Service class for user authentication.
    /// </summary>
    public class LoginService
    {
        private readonly IUser_MasterRepo _userMaster;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService"/> class.
        /// </summary>
        /// <param name="userMaster">The user repository.</param>
        public LoginService(IUser_MasterRepo userMaster)
        {
            _userMaster = userMaster;
        }

        /// <summary>
        /// Authenticates a user based on the provided credentials asynchronously.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="password">The user password.</param>
        /// <param name="userType">The user type.</param>
        /// <returns>An asynchronous task that represents the authenticated user, or null if authentication fails.</returns>
        public async Task<User_Master> Authenticate(string id, string password, string userType)
        {
            var user = await _userMaster.GetUserById(id, password, userType);

            if (user != null && user.UserPassword == password && user.UserType == userType)
            {
                return user;
            }

            return null;
        }

    }
}
