using System.Collections.Generic;
using Newtonsoft.Json;

namespace ipfs_powershell_provider.communications
{
    public class filesLsObjectresponse
    {
        public class Entry
        {
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Type")]
            [JsonConverter(typeof(BoolConverter))]
            public bool IsNotDirectory { get; set; }
            [JsonProperty("Size")]
            public int Size { get; set; }
            [JsonProperty("Hash")]
            public string Hash { get; set; }
        }
        [JsonProperty("Entries")]
        public List<Entry> Entries { get; set; }
    }
    public static class IpfsFilesCommands
    {
        public static filesLsObjectresponse ipfsFilesLs(string path = "", bool longlist = false)
        {
            var argumentlist = "?";
            if (path != "")
            {
                argumentlist += "arg=" + path + ";";
            }
            if (longlist)
            {
                argumentlist += "l=true";
            }
            argumentlist = argumentlist.Replace(";", "&").TrimEnd('&');
            var response = IpfsRestClient.RunIpfsCommand("files/ls", argumentlist);
            var parsed_response = JsonConvert.DeserializeObject<filesLsObjectresponse>(response);
            return parsed_response;
        }
    }
}