using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Security.Cryptography.X509Certificates;

namespace ipfs_powershell_provider
{
    internal class IpfsDrive: PSDriveInfo
    {
        public PinnedObjectsProvider PinnedObjects;
        public IpfsDrive(PSDriveInfo driveInfo) : base(driveInfo)
        {
            PinnedObjects = new PinnedObjectsProvider();
        }
    }

    class PinnedObjectsProvider : ContainerCmdletProvider
    {
        protected override bool IsValidPath(string path)
        {
            throw new System.NotImplementedException();
        }
    }

    public class mfsData
    {
        
    }
}