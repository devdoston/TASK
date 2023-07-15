namespace SocialMediaAPI.DTO.Post;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }

    public CreatePostDto(string title, string content)
    {
        Title = title;
        Content = content;
    }
}