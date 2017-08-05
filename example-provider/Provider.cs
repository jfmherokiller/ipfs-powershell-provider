using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace ASPNETMembership
{
    [CmdletProvider( "ASPNETMembership", ProviderCapabilities.None )]
    public class Provider : ContainerCmdletProvider
    {
        protected override PSDriveInfo NewDrive( PSDriveInfo drive )
        {
            if( drive is MembershipDriveInfo )
            {
                return drive;
            }

            var driveParams = this.DynamicParameters as DriveParameters;
            return new MembershipDriveInfo(drive, driveParams);
        }

        protected override object NewDriveDynamicParameters()
        {
            return new DriveParameters();
        }

        protected override bool ItemExists( string path )
        {
            return null != GetUserFromPath( path );
        }

        protected override void GetItem( string path )
        {
            var user = GetUserFromPath(path);

            if( null != user )
            {
                WriteItemObject( user, path, false );
            }
        }

        MembershipUser GetUserFromPath( string path )
        {
            var drive = this.PSDriveInfo as MembershipDriveInfo;

            var username = ExtractUserNameFromPath( path );
            return drive.MembershipProvider.GetUser( username, false );
        }

        static string ExtractUserNameFromPath( string path )
        {
            if( String.IsNullOrEmpty( path ) )
            {
                return path;
            }

            // this regex matches all supported powershell path syntaxes:
            //  drive-qualified - users:/username
            //  provider-qualified - membership::users:/username
            //  provider-internal - users:/username
            var match = Regex.Match( path, @"(?:membership::)?(?:\w+:[\\/])?(?<username>[a-z0-9_]*)$", RegexOptions.IgnoreCase );
            if( match.Success )
            {
                return match.Groups[ "username" ].Value;
            }

            return String.Empty;
        }

        //protected override Collection<PSDriveInfo> InitializeDefaultDrives()
        //{
        //    var driveInfo = new PSDriveInfo(
        //        "users",
        //        this.ProviderInfo,
        //        "",
        //        "Default ASP.NET Membership Drive",
        //        null
        //        );

        //    var parameters = new DriveParameters
        //                     {
        //                         Catalog = "AwesomeWebsiteDB",
        //                         Server = "localhost"
        //                     };

        //    return new Collection<PSDriveInfo>
        //           {
        //               new MembershipDriveInfo(
        //                   driveInfo,
        //                   parameters
        //                   )
        //           };
        //}


        protected override bool IsValidPath(string path)
        {
            return true;
        }
    }
}
