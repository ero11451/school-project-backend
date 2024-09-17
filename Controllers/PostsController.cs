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
        private static List<PostModel> postsModels = new List<PostModel>();

        private readonly PostService _postService;

        private readonly TokenService _tokenService;

        public PostsController(
            PostService postService,
            TokenService tokenService
        )
        {
            _postService = postService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PostModel>>>
        GetPosts(int page = 1, int pageSize = 4, int? categoryId = null)
        {
            var posts =
                await _postService.GetPostsAsync(page, pageSize, categoryId);
            return Ok(posts);
        }

        // [Authorize]
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
            var newPost =
                new PostModel {
                    Title = post.Title,
                    Content = post.Content,
                    ImgUrl = post.ImgUrl,
                    VideoUrl = post.VideoUrl,
                    Code = post.Code,
                    Status = post.Status,
                    CategoryId = post.CategoryId,
                    Question = post.QuestionText,
                    Options =
                        post
                            .Options
                            .Select(option =>
                                new TestOptions {
                                    Option = option.Option,
                                    IsCorrect = option.IsCorrect
                                })
                            .ToList()
                };
            await _postService.CreatePostAsync(newPost);
            return Ok(newPost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, PostRequest post)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var newPost =
                new PostModel {
                    Title = post.Title,
                    Content = post.Content,
                    ImgUrl = post.ImgUrl,
                    VideoUrl = post.VideoUrl,
                    Code = post.Code,
                    Status = post.Status,
                    CategoryId = post.CategoryId,
                    Question = post.QuestionText,
                    Options =
                        post
                            .Options
                            .Select(option =>
                                new TestOptions {
                                    Option = option.Option,
                                    IsCorrect = option.IsCorrect
                                })
                            .ToList()
                };

            await _postService.UpdatePostAsync(newPost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }

    public class PostRequest
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string? ImgUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string? Code { get; set; }

        public string? Status { get; set; }

        public int? CategoryId { get; set; }

        public string? QuestionText { get; set; }

        public List<TestOptionRequest> Options { get; set; }
    }

    public class TestOptionRequest
    {
        public string Option { get; set; }

        public bool IsCorrect { get; set; }
    }
}
