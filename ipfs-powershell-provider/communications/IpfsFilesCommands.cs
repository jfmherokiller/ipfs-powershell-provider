using System.Collections.Generic;
using Newtonsoft.Json;

namespace ipfs_powershell_provider.communications
{
    public class filesLsObjectresponse
    {
        public class Entry
        {
            [JsonProperty("Name")]
            public string Name { get;}
            [JsonProperty("Type")]
            [JsonConverter(typeof(BoolConverter))]
            public bool IsNotDirectory { get; }
            [JsonProperty("Size")]
            public int Size { get; }
            [JsonProperty("Hash")]
            public string Hash { get; }
        }
        [JsonProperty("Entries")]
        public List<Entry> Entries { get; }
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
            return JsonConvert.DeserializeObject<filesLsObjectresponse>(response);
        }
    }
}