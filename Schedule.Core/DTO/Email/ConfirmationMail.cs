namespace Schedule.Core.DTO.Email
{
    public class ConfirmationMail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VerificationLink { get; set; }

        public ConfirmationMail(string firstName, string lastName, string verificationLink)
        {
            FirstName = firstName;
            LastName = lastName;
            VerificationLink = verificationLink;
        }
    }
}
