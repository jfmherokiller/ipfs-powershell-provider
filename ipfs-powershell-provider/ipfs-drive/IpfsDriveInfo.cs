using System.Management.Automation;

namespace ipfs_powershell_provider
{
    public class IpfsDrive: PSDriveInfo
    {
        public IpfsDrive(PSDriveInfo driveInfo) : base(driveInfo)
        {
        }
    }
}