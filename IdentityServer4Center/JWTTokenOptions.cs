namespace IdentityServer4Center
{
    public class JWTTokenOptions
    {
        public string Audience
        {
            get;
            set;
        }

        public string SecurityKey
        {
            get;
            set;
        }

        //public SigningCredentials Credentials
        //{
        //    get;
        //    set;
        //}

        public string Issuer
        {
            get;
            set;
        }
    }
}
