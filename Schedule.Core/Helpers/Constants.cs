namespace Schedule.Core.Helpers
{
    public class Constants
    {
        #region General 

        public static int MAX_TEXT_LENGHT = 500;
        public static int MAX_COMMENT_LENGHT = 50;
        public static int MAX_GROUP_NAME_LENGHT = 20;
        public static int MAX_SUBJECT_NAME_LENGHT = 50;
        public static int MAX_SUBJECT_DESCRIPTION_LENGHT = 250;
        public static int MAX_TASK_TITLE_LENGHT = 70;
        public static int MAX_TASK_DESCRIPTION_LENGHT = 70;
        public static int MAX_CHAT_NAME_LENGHT = 50;
    
        #endregion

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
