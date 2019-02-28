using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AngularWebAPIDataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;

namespace AngularWebAPI
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            if (!UserService.Login(context.UserName, context.Password))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("Username", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));

            context.Validated(identity);

            //return Task.Factory.StartNew(() =>
            //{
            //    var userName = context.UserName;
            //    var password = context.Password;
            //    var userService = new UserService(); // our created one
            //    var user = userService.Login(userName, password);
            //    if (user != null)
            //    {
            //        var claims = new List<Claim>()
            //        {
            //            new Claim(ClaimTypes.Sid, Convert.ToString(user.User_ID)),
            //            new Claim(ClaimTypes.Name, user.User_Name),
            //            new Claim(ClaimTypes.Email, user.User_EmailID)
            //        };
            //        ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, context.Options.AuthenticationType);


            //        //var properties = CreateProperties(user.User_Name);
            //        //var ticket = new AuthenticationTicket(oAuthIdentity, properties);
            //        context.Validated(oAuthIdentity);
            //    }
            //    else
            //    {
            //        context.SetError("invalid_grant", "The user name or password is incorrect");
            //        return;
            //    }
            //});
            //var userStore = new UserStore<ApplicationUser>(new AngularWebAPIEntities());
            //var manager = new UserManager<ApplicationUser>(userStore);
            //var user = await manager.FindAsync(context.UserName, context.Password);
            //if (user != null)
            //{
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    identity.AddClaim(new Claim("Username", user.UserName));
            //    identity.AddClaim(new Claim("Email", user.Email));
            //    identity.AddClaim(new Claim("FirstName", user.FirstName));
            //    identity.AddClaim(new Claim("LastName", user.LastName));
            //    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
            //    context.Validated(identity);
            //}
            //else
            //    return;
        }
    }
}