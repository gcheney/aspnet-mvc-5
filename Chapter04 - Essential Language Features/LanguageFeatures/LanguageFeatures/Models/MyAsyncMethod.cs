using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethod
    {
        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpMessage = await client.GetAsync("http://apress.com");

            //Do other things while awaiting task
            return httpMessage.Content.Headers.ContentLength;
        }
    }
}