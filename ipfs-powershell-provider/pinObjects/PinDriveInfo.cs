using System.Management.Automation;

namespace ipfs_powershell_provider
{
    public class PinDriveInfo : PSDriveInfo
    {
        public PinDriveInfo(PSDriveInfo driveInfo) : base(driveInfo)
        {
        }
    }
}