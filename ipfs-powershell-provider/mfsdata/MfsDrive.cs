using System.Management.Automation;
using System.Management.Automation.Provider;

namespace ipfs_powershell_provider.mfsdata
{
    [CmdletProvider("IpfsPinnedObjects", ProviderCapabilities.None)]
    public class MfsDrive : DriveCmdletProvider
    {
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            return new MfsDriveInfo(drive);
        }
        protected override object NewDriveDynamicParameters()
        {
            return base.NewDriveDynamicParameters();
        }
    }
}