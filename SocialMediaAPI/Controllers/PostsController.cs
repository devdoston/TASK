using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.DTO.Post;
using SocialMediaAPI.Service;

namespace SocialMediaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService) =>
        _postService = postService;

    [HttpGet]
    public async Task<IActionResult> GetPosts(int userId) =>
        Ok(await _postService.GetPosts(userId));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(int id, int userId) =>
        Ok(await _postService.GetPost(userId, id));

    [HttpPost]
    public async Task<IActionResult> CreatePost(int userId, CreatePostDto postDto) =>
        Ok(await _postService.AddPost(userId, postDto));

    [HttpPut]
    public async Task<IActionResult> UpdatePost(int id, UpdatePostDto postDto) =>
       Ok(await _postService.UpdatePost(id, postDto));

    [HttpDelete]
    public async Task<IActionResult> DeletePost(int id) =>
        Ok(_postService.DeletePost(id));
}