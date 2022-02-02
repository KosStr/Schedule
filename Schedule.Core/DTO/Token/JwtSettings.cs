namespace Schedule.Core.Entities.Token
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Lifetime { get; set; }
        public int RefreshLifetime { get; set; }
    }
}
