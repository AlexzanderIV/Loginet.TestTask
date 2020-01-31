using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.Models;

namespace Loginet.TestTask.DataProvider
{
    public class RestApiDataProvider
    {
        // TODO: Move to config.
        private const string ApiBaseUrl = "http://jsonplaceholder.typicode.com/";

        private const string UsersApiEndpoint = "users";

        private const string AlbumsApiEndpoint = "albums";

        /// <summary>
        /// Simple REST client to call for APIs endpoints.
        /// </summary>
        private readonly IRestClient _restClient;

        public RestApiDataProvider(IRestClient restClient)
        {
            _restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }

        #region Users

        /// <summary>
        /// Get all users from public REST API.
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<IEnumerable<User>>> GetAllUsersAsync()
        {
            var path = GetFullEndpointPath(UsersApiEndpoint);

            return await _restClient.Get<IEnumerable<User>>(path);
        }

        /// <summary>
        /// Get user by its identifier from public REST API.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns></returns>
        public async Task<ApiResponse<User>> GetUserByIdAsync(int userId)
        {
            var path = GetFullEndpointPath(UsersApiEndpoint, userId.ToString());

            return await _restClient.Get<User>(path);
        }

        /// <summary>
        /// Get albums of the user from public REST API.
        /// </summary>
        /// <param name="userId">User identifier for whom to get albums.</param>
        /// <returns></returns>
        public async Task<ApiResponse<IEnumerable<Album>>> GetAlbumsByUserIdAsync(int userId)
        {
            var path = GetFullEndpointPath(UsersApiEndpoint, userId.ToString(), AlbumsApiEndpoint);

            return await _restClient.Get<IEnumerable<Album>>(path);
        }

        #endregion

        #region Albums

        /// <summary>
        /// Get all albums from public REST API.
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<IEnumerable<Album>>> GetAllAlbumsAsync()
        {
            var path = GetFullEndpointPath(AlbumsApiEndpoint);

            return await _restClient.Get<IEnumerable<Album>>(path);
        }

        /// <summary>
        /// Get album by its identifier from public REST API.
        /// </summary>
        /// <param name="albumId">Album identifier.</param>
        /// <returns></returns>
        public async Task<ApiResponse<Album>> GetAlbumByIdAsync(int albumId)
        {
            var path = GetFullEndpointPath(AlbumsApiEndpoint, albumId.ToString());

            return await _restClient.Get<Album>(path);
        }

        #endregion

        private string GetFullEndpointPath(string endpointName, string parameter = null, string subEndpoint = null)
        {
            return $"{ApiBaseUrl}{endpointName}{FormatPathSection(parameter)}{FormatPathSection(subEndpoint)}";
        }

        private string FormatPathSection(string str)
        {
            return !string.IsNullOrEmpty(str) ? $"/{str}" : string.Empty;
        }
    }
}
