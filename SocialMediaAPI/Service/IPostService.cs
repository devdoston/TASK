using SocialMediaAPI.DTO.Post;

namespace SocialMediaAPI.Service;

public interface IPostService
{
    Task<List<PostDto>> GetPosts(int userId);
    Task<PostDto> GetPost(int userId, int id);
    Task DeletePost(int id);
    Task<PostDto> UpdatePost(int id, UpdatePostDto postDto);
    Task<PostDto> AddPost(int UserId, CreatePostDto postDto);
}