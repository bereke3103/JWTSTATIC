namespace JWTWebToken.Models
{
    public  class UserData
    {
        //key
        public  string  Username { get; set; } = string.Empty;
        public  string PasswordHash { get; set; } = string.Empty;
    }
}
