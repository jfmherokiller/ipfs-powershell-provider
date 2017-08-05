using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace ipfs_powershell_provider
{
    public class IpfsDrive: PSDriveInfo
    {
        public PinnedObjectsProvider mypins;
        public IpfsDrive(PSDriveInfo driveInfo) : base(driveInfo)
        {
            mypins = new PinnedObjectsProvider();
        }
        public PinnedObjectsProvider PinnedObjectsProvider => mypins;
    }

    public class PinnedObjectsProvider
    {
    }
}