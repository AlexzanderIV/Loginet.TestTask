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
        public async Task<ApiResponse<IEnumerable<User>>> GetAllUsersAsync(bool encryptUser = true)
        {
            var usersResponse = await new RestApiDataProvider().GetAllUsersAsync();

            if (encryptUser && usersResponse.Content != null)
            {
                foreach (var user in usersResponse.Content)
                {
                    user.EncryptEmail();
                }
            }
            return usersResponse;
        }

        /// <inheritdoc />
        public async Task<ApiResponse<User>> GetUserByIdAsync(int userId, bool encryptUser = true)
        {
            var userResponse = await new RestApiDataProvider().GetUserByIdAsync(userId);

            if (encryptUser && userResponse.Content != null)
            {
                userResponse.Content.EncryptEmail();
            }
            return userResponse;
        }

        /// <inheritdoc />
        public Task<ApiResponse<IEnumerable<Album>>> GetAlbumsByUserIdAsync(int userId)
        {
            return new RestApiDataProvider().GetAlbumsByUserIdAsync(userId);
        }
    }
}
