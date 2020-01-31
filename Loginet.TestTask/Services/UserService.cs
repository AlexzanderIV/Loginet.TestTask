using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.DataProvider;
using Loginet.TestTask.Models;
using Loginet.TestTask.Services.Interfaces;

namespace Loginet.TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly RestApiDataProvider _dataProvider;

        public UserService(RestApiDataProvider dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        /// <inheritdoc />
        public async Task<ApiResponse<IEnumerable<User>>> GetAllUsersAsync(bool encryptUser = true)
        {
            var usersResponse = await _dataProvider.GetAllUsersAsync();

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
            var userResponse = await _dataProvider.GetUserByIdAsync(userId);

            if (encryptUser && userResponse.Content != null)
            {
                userResponse.Content.EncryptEmail();
            }
            return userResponse;
        }

        /// <inheritdoc />
        public Task<ApiResponse<IEnumerable<Album>>> GetAlbumsByUserIdAsync(int userId)
        {
            return _dataProvider.GetAlbumsByUserIdAsync(userId);
        }
    }
}
