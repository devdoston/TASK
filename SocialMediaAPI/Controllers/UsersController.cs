using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.DTO.User;
using SocialMediaAPI.Service;

namespace SocialMediaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) =>
        _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetUsers() =>
        Ok(await _userService.GetUsers());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id) =>
        Ok(await _userService.GetUser(id));

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto userDto) =>
        Ok(await _userService.AddUser(userDto));

    [HttpPut]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto userDto) =>
        Ok(await _userService.UpdateUser(id, userDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id) =>
        Ok(_userService.DeleteUser(id));
}