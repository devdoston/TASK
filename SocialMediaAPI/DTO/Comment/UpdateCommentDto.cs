namespace SocialMediaAPI.DTO.Comment;

public class UpdateCommentDto
{
    public string Text { get; set; }

    public UpdateCommentDto(string text) =>
        Text = text;
}