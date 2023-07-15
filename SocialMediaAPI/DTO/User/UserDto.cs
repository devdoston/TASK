using SocialMediaAPI.DTO.Post;

namespace SocialMediaAPI.DTO.User;

public class UserDto
{
    public string Name { get; set; }
    public List<PostDto>? Posts { get; set; }
}