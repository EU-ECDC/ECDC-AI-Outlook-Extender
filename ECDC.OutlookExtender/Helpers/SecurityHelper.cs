using ECDC.OutlookExtender.Properties;
using System;
using System.Security.Principal;
using System.Windows.Forms;

namespace ECDC.OutlookExtender.Helpers
{
    public static class SecurityHelper
    {
        private static bool? _IsVerified = null; 
        public static bool IsUserInOrganization()
        {
            if (_IsVerified.HasValue== false)
            { 
                try
                {

                    WindowsIdentity identity = WindowsIdentity.GetCurrent();                
                    string userDomain = identity.Name.Split('\\')[0];  // Domain part of DOMAIN\User format

                    var allowedDomain = Security.Default.UserDomain;
                    _IsVerified = userDomain.Equals(allowedDomain, StringComparison.OrdinalIgnoreCase);

                }
                catch
                {
                    _IsVerified = false;                
                }
            }

            if (_IsVerified.Value == false)
            {
                var message = Security.Default.Message;
                MessageBox.Show(message, "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return _IsVerified.Value;
        }
    }
}
