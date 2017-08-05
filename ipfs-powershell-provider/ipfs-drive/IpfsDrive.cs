using System.Management.Automation;
using System.Management.Automation.Provider;

namespace ipfs_powershell_provider
{
    [CmdletProvider("PinnedObjects", ProviderCapabilities.None)]
    public class PinnedObjectsProvider : ContainerCmdletProvider
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
    public class MfsDataProvider : ContainerCmdletProvider
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