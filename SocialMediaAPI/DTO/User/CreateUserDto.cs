namespace SocialMediaAPI.DTO.User;

public class CreateUserDto
{
    public string Name { get; set; }

    public CreateUserDto(string name) =>
        Name = name;
}