namespace SocialMediaAPI.DTO.User;

public class UpdateUserDto
{
    public string Name { get; set; }

    public UpdateUserDto(string name) =>
        Name = name;
}