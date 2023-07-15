using Mapster;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Context;
using SocialMediaAPI.DTO.Post;
using SocialMediaAPI.Entities;

namespace SocialMediaAPI.Service;

public class PostService : IPostService
{
    private readonly AppDbContext _context;

    public PostService(AppDbContext context) =>
        _context = context;
   
    public async Task<PostDto> AddPost(int userId, CreatePostDto postDto)
    {
        var post = new Post()
        { 
            Title = postDto.Title,
            Content = postDto.Content,
            UserId = userId
        };

        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync(); 

        return post.Adapt<PostDto>();
    }

    public async Task DeletePost(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (post is null)
            throw new("Post Not Found!");

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return;
    }

    public async Task<PostDto> GetPost(int userId, int id)
    {
        var post = await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

        if (post is null)
            throw new("Post Not Found");

        return post.Adapt<PostDto>();
    }

    public async Task<List<PostDto>> GetPosts(int userId)
    {
        var posts = await _context.Posts.Include(p => p.Comments).Where(p => p.UserId == userId).ToListAsync();

        if (posts.Count == 0)
            throw new("Posts Table Is Empty");

        var postsList = new List<PostDto>();

        foreach(var post in posts)
        {
            postsList.Add(new PostDto
            { 
                Title = post.Title,
                Content = post.Content
            });

        }

        return postsList;
    }

    public async Task<PostDto> UpdatePost(int id, UpdatePostDto postDto)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (post is null)
            throw new("Post Not Found!");

        post.Title = postDto.Title;
        post.Content = postDto.Content;

        await _context.SaveChangesAsync();

        return post.Adapt<PostDto>();
    }
}