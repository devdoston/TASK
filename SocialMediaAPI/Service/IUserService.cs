using SocialMediaAPI.DTO.User;

namespace SocialMediaAPI.Service;

public interface IUserService
{
    Task<List<UserDto>> GetUsers();
    Task<UserDto?> GetUser(int id);
    Task DeleteUser(int id);
    Task<UserDto> UpdateUser(int id, UpdateUserDto userDto);
    Task<UserDto> AddUser(CreateUserDto userDto);
}