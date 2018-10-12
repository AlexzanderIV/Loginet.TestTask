using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.DataProvider;
using Loginet.TestTask.Models;

namespace Loginet.TestTask.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>List of users.</returns>
        Task<ApiResponse<IEnumerable<User>>> GetAllUsersAsync();

        /// <summary>
        /// Get user by its identifier.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User with provided identifier.</returns>
        Task<ApiResponse<User>> GetUserByIdAsync(int userId);

        /// <summary>
        /// Get albums of the user.
        /// </summary>
        /// <param name="userId">User identifier for whom to get albums.</param>
        /// <returns>Albums list of the user.</returns>
        Task<ApiResponse<IEnumerable<Album>>> GetAlbumsByUserIdAsync(int userId);
    }
}
