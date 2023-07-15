using SocialMediaAPI.DTO.Comment;

namespace SocialMediaAPI.DTO.Post;

public class PostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<CommentDto> Comments { get; set; }
}