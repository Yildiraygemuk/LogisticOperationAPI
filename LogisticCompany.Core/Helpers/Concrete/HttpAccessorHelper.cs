using LogisticCompany.Core.Entities.Dtos;
using LogisticCompany.Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;

namespace LogisticCompany.Core.Helpers
{
    public class HttpAccessorHelper : IHttpAccessorHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpAccessorHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int? GetUserId()
        {
            var userId = GetJwtClaim(CustomClaimTypes.UserId);
            return string.IsNullOrEmpty(userId) ? null : Convert.ToInt32(userId);
        }
        public string GetJwtClaim(string claimType)
        {
            return _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }

        //public int? GetUserId()
        //{
        //    var user = (AuthUserDto)_httpContextAccessor.HttpContext.Items["LogisticCompanyUser"];
        //    return user.UserId;
        //}
    }
}