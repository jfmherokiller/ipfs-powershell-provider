using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Security.Cryptography.X509Certificates;

namespace ipfs_powershell_provider
{
    internal class IpfsDriveInfo: PSDriveInfo
    {
        public PinnedObjectsProvider PinnedObjects;
        public MfsDataProvider MfsData;
        public IpfsDriveInfo(PSDriveInfo driveInfo) : base(driveInfo)
        {
            MfsData = new MfsDataProvider();
            PinnedObjects = new PinnedObjectsProvider();
        }
    }
}
