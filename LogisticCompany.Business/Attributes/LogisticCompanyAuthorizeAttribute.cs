using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LogisticCompany.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LogisticCompanyAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rayonPropertyUser = (AuthUserDto)context.HttpContext.Items["LogisticCompanyUser"];
            if (rayonPropertyUser == null)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }
            
            var authService = (IAuthService)context.HttpContext.RequestServices.GetService(typeof(IAuthService));

            if (authService is null)
            {
                context.Result = new StatusCodeResult(500);
                return;
            }

            var authUserDto = new AuthUserDto()
            {
                UserEmail = rayonPropertyUser.UserEmail,
                UserId = rayonPropertyUser.UserId,
                UserName = rayonPropertyUser.UserName
            };

            var isuserExist = authService.IsUserExists(authUserDto);
            if (!isuserExist.Success)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            var user = authService.GetForAuthorization(authUserDto.UserId, authUserDto.UserEmail);
            if (user == null)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }
        }
    }
}
