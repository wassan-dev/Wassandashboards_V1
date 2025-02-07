namespace Wassandashboard.Services
{
    public class CurrentUserService
    {
        public HttpContext _context { get; }
        public CurrentUserService(HttpContext context)
        {
            _context = context;
        }

        public string GetCurrentUserId()
        {
            return _context.User.Identity.Name;
        }
    }
}
