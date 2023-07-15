using Mapster;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Context;
using SocialMediaAPI.DTO.Comment;
using SocialMediaAPI.Entities;

namespace SocialMediaAPI.Service;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;

    public CommentService(AppDbContext context) =>
        _context = context;

    public async Task<CommentDto> AddComment(int postId, CreateCommentDto commentDto)
    {
        var comment = new Comment()
        { 
            Text = commentDto.Text,
            PostId = postId
        };

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return comment.Adapt<CommentDto>();
    }

    public async Task DeleteComment(int postId, int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(p => p.Id == id && p.PostId == postId);

        if (comment is null)
            throw new("Comment Not Found!");

        _context.Comments.Remove(comment);
        return ;
    }

    public async Task<List<CommentDto>> GetComments(int postId)
    {
        var comments = _context.Comments.Where(c => c.PostId == postId).ToList();

        if (comments.Count == 0)
            throw new("No Comments");

        var commentList = new List<CommentDto>();

        foreach (var comment in comments)
        {
            commentList.Add(new CommentDto(comment.Text));
        }

        return commentList;
    }

    public async Task<CommentDto> UpdateComment(int postId, int id, UpdateCommentDto commentDto)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id && c.PostId == postId);

        if (comment is null)
            throw new("Comment Not Found");

        comment.Text = commentDto.Text;

        await _context.SaveChangesAsync();

        return comment.Adapt<CommentDto>();
    }
}