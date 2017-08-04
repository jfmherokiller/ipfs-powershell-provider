using System.Management.Automation;
using System.Management.Automation.Provider;

namespace ipfs_powershell_provider
{
    [CmdletProvider("IpfsPinnedObjects", ProviderCapabilities.None)]
    public class IpfsPinDrive : DriveCmdletProvider
    {
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            return new PinDriveInfo(drive);
        }
        protected override object NewDriveDynamicParameters()
        {
            return base.NewDriveDynamicParameters();
        }
    }
}