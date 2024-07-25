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
        public async Task<ActionResult<List<PostModel>>> GetPosts()
        {
            var posts = await _postService.GetPostsAsync();
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
        [Authorize]
        public async Task<ActionResult> CreatePost(PostModel post)
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            var token = authHeader.Substring("Bearer ".Length).Trim();
            var principal = _tokenService.ValidateToken(token);
            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            post.TeacherId = int.Parse(userId);
            await _postService.CreatePostAsync(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.id }, post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, PostModel post)
        {
            if (id != post.id)
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

}
