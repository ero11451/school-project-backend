using System.Security.Claims;
using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly TokenService _tokenService;
        public PostsController(PostService postService, TokenService tokenService)
        {
            _postService = postService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PostModel>>> GetPosts(int page = 1 , int pageSize = 4)
        {
            var posts = await _postService.GetPostsAsync( page, pageSize);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> GetPost(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        // [Authorize]
        public async Task<ActionResult> CreatePost(PostRequest post)
        {
            // var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var newPost = new PostModel
            {
                Title = post.Title,
                Content = post.Content,
                Code = post.Code,
                ImgUrl = post.ImgUrl,
                VideoUrl = post.VideoUrl,
                Status = post.Status,
                TestId = post.TestId,
                CategoryId = post.CategoryId,
                LocationId = post.LocationId,
                TeacherId = post.TeacherId,
            };
            await _postService.CreatePostAsync(newPost);
            return Ok(newPost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, PostModel post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            await _postService.UpdatePostAsync(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }

  public class PostRequest{
        public string Title { get; set; } = null;

        public string Content { get; set; } = null;

        public string ImgUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string? Code { get; set; }

        public string? Status { get; set; }

        public int? TestId { get; set; }

        public int? CategoryId { get; set; }

        public int? LocationId { get; set; }

        public int? TeacherId { get; set; }
   }

}
