using Mapster;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Context;
using SocialMediaAPI.DTO.Post;
using SocialMediaAPI.DTO.User;
using SocialMediaAPI.Entities;

namespace SocialMediaAPI.Service;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context) =>
        _context = context;

    public async Task<UserDto> AddUser(CreateUserDto userDto)
    {
        var user = new User()
        {
            Name = userDto.Name
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Adapt<UserDto>();
    }

    public async Task DeleteUser(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
            throw new("User Not Found!");

        _context.Users.Remove(user);

        return;
    }

    public async Task<UserDto?> GetUser(int id)
    {
        var user = await _context.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
            throw new("User Not Found!");

        var result = user.Adapt<UserDto>();

        return result;
    }

    public async Task<List<UserDto>> GetUsers()
    {
        var users = await _context.Users.Include(u => u.Posts).ToListAsync();

        if (users.Count == 0)
            throw new("Users Table Is Empty!");

        var userList = new List<UserDto>();

        foreach (var user in users)
        {
            userList.Add(new UserDto
            { 
                Name = user.Name,
            });
        }

        return userList;
    }

    public async Task<UserDto> UpdateUser(int id, UpdateUserDto userDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
            throw new("User Not Found!");

        user.Name = userDto.Name;

        await _context.SaveChangesAsync();

        return user.Adapt<UserDto>();
    }
}
