using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Loginet.TestTask.DataProvider
{
    /// <summary>
    /// Simple REST client to call for APIs endpoints.
    /// </summary>
    public class RestClient
    {
        /// <summary>
        /// Execute GET HTTP request to the provided path.
        /// </summary>
        /// <typeparam name="TResult">Expected type of the response from the server.</typeparam>
        /// <param name="path">Path to the resource (URI).</param>
        /// <returns></returns>
        public async Task<ApiResponse<TResult>> Get<TResult>(string path)
            where TResult : class
        {
            using (HttpClient client = new HttpClient())
            {
                // Decided not to use Newtonsoft, but use JsonSerializer which is available out of the box.
                var serializer = new DataContractJsonSerializer(typeof(TResult));

                try
                {
                    var resultStream = await client.GetStreamAsync(path);
                    var result = serializer.ReadObject(resultStream) as TResult;

                    return new ApiResponse<TResult>
                    {
                        Content = result
                    };
                }
                catch (System.Exception ex)
                {
                    return new ApiResponse<TResult>
                    {
                        Content = null,
                        Error = ex.Message
                    };
                }
            }
        }
    }
}
