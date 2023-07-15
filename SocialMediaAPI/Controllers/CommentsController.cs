using Microsoft.AspNetCore.Mvc;
using SocialMediaAPI.DTO.Comment;
using SocialMediaAPI.DTO.Post;
using SocialMediaAPI.Service;

namespace SocialMediaAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService) =>
        _commentService = commentService;

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetComments(int postId) =>
        Ok(await _commentService.GetComments(postId));

    [HttpPost]
    public async Task<IActionResult> CreateComment(int postId, CreateCommentDto commentDto) =>
        Ok(await _commentService.AddComment(postId, commentDto));

    [HttpPut]
    public async Task<IActionResult> UpdateComment(int postId, int id, UpdateCommentDto postDto) =>
       Ok(await _commentService.UpdateComment(postId, id, postDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteComment(int postId, int id) =>
        Ok(_commentService.DeleteComment(postId, id));
}