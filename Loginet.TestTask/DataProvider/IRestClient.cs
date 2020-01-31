using System.Threading.Tasks;

namespace Loginet.TestTask.DataProvider
{
    /// <summary>
    /// Simple REST client to call for APIs endpoints.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Execute GET HTTP request to the provided path.
        /// </summary>
        /// <typeparam name="TResult">Expected type of the response from the server.</typeparam>
        /// <param name="path">Path to the resource (URI).</param>
        /// <returns></returns>
        Task<ApiResponse<TResult>> Get<TResult>(string path) where TResult : class;
    }
}
