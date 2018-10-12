using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.DataProvider;
using Loginet.TestTask.Models;

namespace Loginet.TestTask.Services.Interfaces
{
    public interface IAlbumService
    {
        /// <summary>
        /// Get all albums.
        /// </summary>
        /// <returns>List of albums.</returns>
        Task<ApiResponse<IEnumerable<Album>>> GetAllAlbumsAsync();

        /// <summary>
        /// Get album by its identifier.
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns>Album with provided identifier.</returns>
        Task<ApiResponse<Album>> GetAlbumByIdAsync(int userId);
    }
}
