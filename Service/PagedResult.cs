
using SendGrid.Helpers.Errors.Model;

namespace BackendApp.Services;

public class PagedResult<T>
{
    public List<T> Data { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}

  [Serializable]
  public   class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) :
            base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) :
            base(message, innerException)
        {
        }
    }