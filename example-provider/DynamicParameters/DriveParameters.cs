using System;
using System.Management.Automation;
using System.Web.Security;

namespace ASPNETMembership
{
    public class DriveParameters
    {
        public DriveParameters()
        {
            EnablePasswordReset = true;
            EnablePasswordRetrieval = false;
            RequiresQuestionAndAnswer = false;
            RequiresUniqueEmail = false;
            MaxInvalidPasswordAttempts = 5;
            MinRequiredNonalphanumericCharacters = 0;
            MinRequiredPasswordLength = 6;
            PasswordAttemptWindow = 10;
            PasswordStrengthRegularExpression = String.Empty;
            ApplicationName = "/";
            PasswordFormat = MembershipPasswordFormat.Hashed;
        }

        [Parameter( Mandatory=true )]       
        public string Server { get; set; }
        
        [Parameter( Mandatory = true )]
        public string Catalog { get; set; }

        public bool EnablePasswordRetrieval { get; set; }
        public bool EnablePasswordReset { get; set; }
        public bool RequiresQuestionAndAnswer { get; set; }
        public bool RequiresUniqueEmail { get; set; }
        public MembershipPasswordFormat PasswordFormat { get; set; }
        public int MaxInvalidPasswordAttempts { get; set; }
        public int MinRequiredPasswordLength { get; set; }
        public int MinRequiredNonalphanumericCharacters { get; set; }
        public int PasswordAttemptWindow { get; set; }
        public string PasswordStrengthRegularExpression { get; set; }
        public string ApplicationName { get; set; }
    }
}
