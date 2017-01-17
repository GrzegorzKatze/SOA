using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiTest
{
    public class Program
    {
        private const string _webApiUri = "http://localhost:49702/";

        private static void Main(string[] args)
        {
          
        }

        public static async Task<IRestResponse> Example()
        {
            var client = new RestClient(_webApiUri);

            var request = new RestRequest("api/client/{id}", Method.POST);
            var cancelaltionTokenSource = new CancellationTokenSource();
            request.AddParameter("id", "1", ParameterType.UrlSegment);

            return await client.ExecuteTaskAsync(request);
        }
    }
}