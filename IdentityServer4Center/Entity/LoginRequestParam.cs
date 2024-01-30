namespace Auth.Entity
{
    public class LoginRequestParam
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string grant_type { get; set; }
        public string access_token { get; set; }
        public string access_token_secret { get; set; }
        public string access_token_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
