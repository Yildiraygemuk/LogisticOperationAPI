namespace LogisticCompany.Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}
