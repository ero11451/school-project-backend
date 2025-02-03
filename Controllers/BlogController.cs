using BackendApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;
        public BlogController( BlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<ActionResult> Get(int page= 1, int pageSize = 10, Guid? categoryId = null)
        {
             var result =  await _blogService.GetBlogsAsync(page, pageSize, categoryId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BlogRequestDTO body)
        {
           var result = _blogService.CreateBlogAsync(body);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] BlogRequestDTO value)
        {
            var response = await _blogService.UpdateBlogAsync(id, value);

            if (response == null)
            {
                return NotFound();
            }
            
            return  Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _blogService.DeleteBlogAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok("Deleted Successfully");
        }
    }
}