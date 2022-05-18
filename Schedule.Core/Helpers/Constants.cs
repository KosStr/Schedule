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

        #region Claims

        public class Claims
        {
            public const string UserId = "UserId";
            public const string GroupId = "GroupId";
        }

        #endregion

        #region Rules
        public class Rules
        {
            public const string Create = "Create";
            public const string Update = "Update";
            public const string Delete = "Delete";
        }

        #endregion

        #region Messages
        public class Messages
        {
            public const string ExistingId = "This Id already exists";
            public const string NonExistingId = "This Id doesn't exists";
            public const string ExistingEmail = "This email already exists";
            public const string ExistingEntity = "This entity already exists";
            public const string InvalidInput = "Invalid input";
        }

        #endregion
    }
}
