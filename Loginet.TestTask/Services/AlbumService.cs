using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loginet.TestTask.DataProvider;
using Loginet.TestTask.Models;
using Loginet.TestTask.Services.Interfaces;

namespace Loginet.TestTask.Services
{
    public class AlbumService : IAlbumService
    {
        /// <inheritdoc />
        public async Task<ApiResponse<IEnumerable<Album>>> GetAllAlbumsAsync()
        {
            return await new RestApiDataProvider().GetAllAlbumsAsync();
        }

        /// <inheritdoc />
        public async Task<ApiResponse<Album>> GetAlbumByIdAsync(int albumId)
        {
            return await new RestApiDataProvider().GetAlbumByIdAsync(albumId);
        }
    }
}
