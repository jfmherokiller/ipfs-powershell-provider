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
    [CmdletProvider("PinnedObjects", ProviderCapabilities.None)]
    class PinnedObjectsProvider : ContainerCmdletProvider
    {
        protected override void GetItem(string path)
        {
            var pinnedObject = communications.IpfsPinCommands.IpfsPinLS(path);
            if (null != pinnedObject)
            {
                WriteItemObject(pinnedObject, path, false);
            }
        }
        protected override bool ItemExists(string path)
        {
            return communications.IpfsPinCommands.IpfsPinLS(path).Keys.Count != 0;
        }
        protected override bool IsValidPath(string path)
        {
            return true;
        }
    }
    [CmdletProvider("MfsDrive", ProviderCapabilities.None)]
    class MfsDataProvider : ContainerCmdletProvider
    {
        protected override void GetItem(string path)
        {
            var mfsObject = communications.IpfsFilesCommands.ipfsFilesLs(path);
            if (null != mfsObject)
            {
                if (mfsObject.Entries.Count > 1)
                {
                    WriteItemObject(mfsObject, path, true);
                }
            }
        }
        protected override bool ItemExists(string path)
        {
            return communications.IpfsFilesCommands.ipfsFilesLs(path).Entries.Count != 0;
        }
        protected override bool IsValidPath(string path)
        {
            return true;
        }
    }
}
