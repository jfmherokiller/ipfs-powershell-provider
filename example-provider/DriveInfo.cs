using System;
using System.Configuration;
using System.Management.Automation;
using System.Web.Configuration;
using System.Web.Security;

namespace ASPNETMembership
{
    public class MembershipDriveInfo : PSDriveInfo
    {
        private static ushort providerIndex = 0;
        MembershipProvider provider;

        public MembershipDriveInfo( PSDriveInfo driveInfo, DriveParameters parameters )
            : base( driveInfo )
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            var fi = typeof( ConfigurationElementCollection )
                .GetField( "bReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic );

            fi.SetValue( connectionStrings, false );

            var connectionString = String.Format(
                "data source={0};Integrated Security=SSPI;Initial Catalog={1}",
                parameters.Server,
                parameters.Catalog
                );

            var moniker = Guid.NewGuid().ToString("N");
            var connectionStringName = moniker;
            var providerName = "AspNetSqlMembershipProvider";

            connectionStrings.Add(
                new ConnectionStringSettings(
                    connectionStringName,
                    connectionString
                )
            );

            provider = new SqlMembershipProvider();
            var nvc = new System.Collections.Specialized.NameValueCollection
            {
                { "connectionStringName", connectionStringName },
                { "enablePasswordRetrieval", parameters.EnablePasswordRetrieval.ToString() },
                { "enablePasswordReset", parameters.EnablePasswordReset.ToString() },
                { "requiresQuestionAndAnswer", parameters.RequiresQuestionAndAnswer.ToString() },
                { "requiresUniqueEmail", parameters.RequiresUniqueEmail.ToString() },
                { "passwordFormat", parameters.PasswordFormat.ToString() },
                { "maxInvalidPasswordAttempts", parameters.MaxInvalidPasswordAttempts.ToString() },
                { "minRequiredPasswordLength", parameters.MinRequiredPasswordLength.ToString() },
                { "minRequiredNonalphanumericCharacters", parameters.MinRequiredNonalphanumericCharacters.ToString() },
                { "passwordAttemptWindow", parameters.PasswordAttemptWindow.ToString() },
                { "passwordStrengthRegularExpression", parameters.PasswordStrengthRegularExpression },
                { "applicationName", parameters.ApplicationName },                
            };
            
            provider.Initialize( providerName, nvc );

            // set up private members of the Membership type
            //  this allows us to work with MembershipUser objects directly (e.g., calling MembershipUser.ResetPassword

            fi = typeof( Membership )
                .GetField( "s_Provider", System.Reflection.BindingFlags.Static| System.Reflection.BindingFlags.NonPublic );

            fi.SetValue( null, provider );

            MembershipProviderCollection coll = new MembershipProviderCollection
                                                {
                                                    provider
                                                };

            fi = typeof( Membership )
                .GetField( "s_Providers", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic );

            fi.SetValue( null, coll );

            fi = typeof( Membership )
                .GetField( "s_Initialized", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic );

            fi.SetValue( null, true );

            fi = typeof( Membership )
                .GetField( "s_HashAlgorithmType", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic );

            fi.SetValue( null, "SHA1" );

            fi = typeof( Membership )
                .GetField( "s_HashAlgorithmFromConfig", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic );

            fi.SetValue( null, false );

        }
        
        public MembershipProvider MembershipProvider
        {
            get
            {
                return this.provider;
            }
        }
    }
}
