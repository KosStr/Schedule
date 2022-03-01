namespace Schedule.Core.Helpers
{
    public class Constants
    {
        #region Emailing

        public class EmailTemplates
        {
            public const string RegistrationMailPath = "Schedule.ClientApp.EmailTemplates.RegistrationMail.cshtml";
            public const string ChangePasswordMailPath = "Schedule.ClientApp.EmailTemplates.PasswordChangeMail.cshtml";
        }

        #endregion

        #region Cookies

        public class Cookies
        {
            public const string RefreshTokenKey = "refresh_token";
        }

        #endregion
    }
}
