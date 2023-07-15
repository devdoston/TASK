using SocialMediaAPI.DTO.Comment;

namespace SocialMediaAPI.Service;

public interface ICommentService
{
    Task<List<CommentDto>> GetComments(int postId);
    Task DeleteComment(int postId, int id);
    Task<CommentDto> UpdateComment(int postId, int id, UpdateCommentDto commentDto);
    Task<CommentDto> AddComment(int postId, CreateCommentDto commentDto);
}