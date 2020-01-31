using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.DataProvider;
using Loginet.TestTask.Models;
using Loginet.TestTask.Services.Interfaces;

namespace Loginet.TestTask.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly RestApiDataProvider _dataProvider;

        public AlbumService(RestApiDataProvider dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        /// <inheritdoc />
        public async Task<ApiResponse<IEnumerable<Album>>> GetAllAlbumsAsync()
        {
            return await _dataProvider.GetAllAlbumsAsync();
        }

        /// <inheritdoc />
        public async Task<ApiResponse<Album>> GetAlbumByIdAsync(int albumId)
        {
            return await _dataProvider.GetAlbumByIdAsync(albumId);
        }
    }
}
