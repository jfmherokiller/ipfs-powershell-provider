

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ipfs_powershell_provider.communications
{
    public class PinObjectresponse
    {
        [JsonProperty("Keys")]
        public Dictionary<string, KeyType> Keys { get; set; }
        public class KeyType
        {
            [JsonProperty("Type")]
            public string TypeOfKey { get; set; }
        }
    }
    public static class IpfsPinCommands
    {
        public static PinObjectresponse IpfsPinLS(string path = "", string type = "", bool quiet = false)
        {
            var argumentlist = "?";
            if (path != "")
            {
                argumentlist += "path="+path+";";
            }
            if (type != "")
            {
                argumentlist += "type=" + type + ";";
            }
            if (quiet)
            {
                argumentlist += "quiet=true";
            }
            argumentlist = argumentlist.Replace(";", "&").TrimEnd('&');
            var response =IpfsRestClient.RunIpfsCommand("pin/ls", argumentlist);
            return JsonConvert.DeserializeObject<PinObjectresponse>(response);
        }
    }
}