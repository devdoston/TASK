namespace SocialMediaAPI.DTO.Comment;

public class CreateCommentDto
{
    public string Text { get; set; }

    public CreateCommentDto(string text) =>
        Text = text;
}