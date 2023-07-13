using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace EmployeeDetails.Filter
{
    public class JwtFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? JwtToken = Convert.ToString(context.HttpContext.Session.GetString("userToken"));
            if (!string.IsNullOrEmpty(JwtToken))
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken? token = handler.ReadToken(JwtToken) as JwtSecurityToken;
                if (token != null)
                {
                    if (token.ValidTo < DateTime.UtcNow.AddSeconds(1))
                    {
                        context.HttpContext.Session.Clear();
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            action = "Login",
                            controller = "Home",
                        }));
                    }
                }
            }
            else
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Login",
                    controller = "Home",
                }));
            }
        }
    }
}
