using System.Security.Claims;

namespace Projekt_inz_backend.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpcontext;

        public UserService(IHttpContextAccessor httpcontext)
        {
            _httpcontext = httpcontext;
        }
        public string GetName()
        {
            var result = string.Empty;
            if (_httpcontext.HttpContext != null) 
            {
                result = _httpcontext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

        public string GetRole()
        {
            var result = string.Empty;
            if (_httpcontext.HttpContext != null)
            {
                result = _httpcontext.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            return result;
        }
    }
}
