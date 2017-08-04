using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IpfsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIpfsVersionCommand()
        {
            var runIpfsCommand = ipfs_powershell_provider.communications.IpfsRestClient.RunIpfsCommand("version","");
            Assert.IsTrue(runIpfsCommand.Contains("Version"));
            Console.WriteLine(runIpfsCommand);
        }

        [TestMethod]
        public void TestIPFSLsCommand()
        {
            var lsresponse = ipfs_powershell_provider.communications.IpfsPinCommands.IpfsPinLS(type:"recursive");
            Assert.IsTrue(lsresponse.Keys.Count > 0);
            Console.WriteLine(string.Join(Environment.NewLine, lsresponse.Keys.Select(kvp => kvp.Key + ": " + kvp.Value.TypeOfKey)));
        }
    }
}
