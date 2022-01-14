using Domain.Models;

namespace API.DTOs
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }

        public UserDto(string displayName, string token, string username, string image)
        {
            DisplayName = displayName;
            Token = token;
            Username = username;
            Image = image;
        }

        public UserDto(User user, string token)
        {
            DisplayName = user.DisplayName;
            Token = token;
            Username = user.UserName;
            Image = null;
        }
        public UserDto()
        {
            
        }
    }
}