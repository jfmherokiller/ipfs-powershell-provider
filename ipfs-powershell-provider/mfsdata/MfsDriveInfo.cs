using System.Management.Automation;

namespace ipfs_powershell_provider.mfsdata
{
    public class MfsDriveInfo: PSDriveInfo
    {
        public MfsDriveInfo(PSDriveInfo driveInfo) : base(driveInfo)
        {
        }
    }
}