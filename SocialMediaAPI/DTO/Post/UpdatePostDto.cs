namespace SocialMediaAPI.DTO.Post;

public class UpdatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }

    public UpdatePostDto(string title, string content)
    {
        Title = title;
        Content = content;
    }
}