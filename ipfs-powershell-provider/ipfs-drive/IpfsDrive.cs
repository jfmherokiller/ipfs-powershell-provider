﻿using System.Management.Automation;
using System.Management.Automation.Provider;

namespace ipfs_powershell_provider
{
    [CmdletProvider("IpfsDrive", ProviderCapabilities.None)]
    public class IpfsDrive : ContainerCmdletProvider
    {
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            return new IpfsDriveInfo(drive);
        }
        protected override object NewDriveDynamicParameters()
        {
            return base.NewDriveDynamicParameters();
        }
        protected override void GetItem(string path)
        {
            if (path.StartsWith("IpfsDrive:/pins/"))
            {
                var pinnedObject = communications.IpfsPinCommands.IpfsPinLS(path);
                if (null != pinnedObject)
                {
                    WriteItemObject(pinnedObject, path, false);
                }
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
    [CmdletProvider("PinnedObjects", ProviderCapabilities.None)]
    class PinnedObjectsProvider : ContainerCmdletProvider
    {
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            return base.NewDrive(drive);
        }
        protected override object NewDriveDynamicParameters()
        {
            return base.NewDriveDynamicParameters();
        }
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
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            return base.NewDrive(drive);
        }
        protected override object NewDriveDynamicParameters()
        {
            return base.NewDriveDynamicParameters();
        }
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