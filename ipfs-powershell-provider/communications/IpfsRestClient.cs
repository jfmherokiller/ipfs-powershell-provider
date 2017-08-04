using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ipfs_powershell_provider.communications
{
    public class IpfsRestClient
    {
        public static string RunIpfsCommand(string command, string arguments)
        {
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var commandurl = "http://localhost:5001/api/v0/" + command+arguments;
            var jsonResponse = client.GetStringAsync(commandurl).Result;
            return jsonResponse;
        }
    }
}