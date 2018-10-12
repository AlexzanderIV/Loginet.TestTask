using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loginet.TestTask.DataProvider;
using Loginet.TestTask.Models;
using Loginet.TestTask.Services.Interfaces;

namespace Loginet.TestTask.Services
{
    public class UserService : IUserService
    {
        /// <inheritdoc />
        public async Task<ApiResponse<IEnumerable<User>>> GetAllUsersAsync()
        {
            return await new RestApiDataProvider().GetAllUsersAsync();
        }

        /// <inheritdoc />
        public async Task<ApiResponse<User>> GetUserByIdAsync(int userId)
        {
            return await new RestApiDataProvider().GetUserByIdAsync(userId);
        }

        /// <inheritdoc />
        public Task<ApiResponse<IEnumerable<Album>>> GetAlbumsByUserIdAsync(int userId)
        {
            return new RestApiDataProvider().GetAlbumsByUserIdAsync(userId);
        }
    }
}
