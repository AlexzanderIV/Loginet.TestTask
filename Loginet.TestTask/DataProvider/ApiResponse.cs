namespace Loginet.TestTask.DataProvider
{
    public class ApiResponse<TModel>
        where TModel : class
    {
        public TModel Content;

        public string Error;
    }
}
