namespace SocialMediaAPI.DTO.Comment;

public class CommentDto
{
    public string Text { get; set; }

    public CommentDto(string text) =>
        Text = text;
}