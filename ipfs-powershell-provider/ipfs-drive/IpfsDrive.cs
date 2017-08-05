using System.Management.Automation;
using System.Management.Automation.Provider;

namespace ipfs_powershell_provider
{
    [CmdletProvider("IpfsDrive", ProviderCapabilities.None)]
    public class IpfsDrive : DriveCmdletProvider
    {
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            return new IpfsDriveInfo(drive);
        }
        protected override object NewDriveDynamicParameters()
        {
            return base.NewDriveDynamicParameters();
        }
    }
}