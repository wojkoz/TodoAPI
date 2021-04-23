using System;

namespace TodoAPI.Domain.Dtos
{
    public class LoginResponse
    {
        public string Token { get; }
        public DateTime Expiration { get; }
        public UserDto User { get; }

        public LoginResponse( string token, DateTime expiration, UserDto user)
        {
            Token = token;
            Expiration = expiration;
            User = user;
        }
    }
}
