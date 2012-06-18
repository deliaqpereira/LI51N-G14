using System.Web;
using System;
using System.Web.Security;
using System.Security.Principal;
using MvcFollowTv.Secure;
using Domain.DomainEntity;

namespace MvcFollowTv.Module
{
    public class ProgramsModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);
            context.AuthenticateRequest += new EventHandler(OnAuthenticateRequest);
        }

        #endregion

        public void OnAuthenticateRequest(Object source, EventArgs args)
        {
            //custom Authentication logic can go here
            var app = source as HttpApplication;

            HttpRequest req = app.Context.Request;
            HttpResponse rep = app.Context.Response;

            //empty cookie goes to Login
            if (req.Cookies.Count == 0)
            {
                //set temp cookie
                string publicName = Hash64.base64Encode("public");
                HttpCookie c = new HttpCookie("public", publicName);
                c.Expires = DateTime.Now.AddMinutes(30);
                HttpContext.Current.Response.Cookies.Add(c);
                HttpContext.Current.User = new GenericPrincipal(new GenericIdentity("public"), new[] { "public" });

                //redirect to base
                rep.Redirect("/");
            }
            //get cookie
            HttpCookie cookie = req.Cookies["user"];
            if (cookie != null)
            {
                //desencriptacao
                string userName = Hash64.base64Decode(cookie.Value);
                User u = MvcApplication._userLogic.GetByNickName(userName);

                if (u != null)
                    HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(userName), u.Role);
            }
            //if (HttpContext.Current.User != null)
            //{
            //    if (HttpContext.Current.User.Identity.IsAuthenticated)
            //    {
            //        if (HttpContext.Current.User.Identity is FormsIdentity)
            //        {
            //            FormsIdentity id =(FormsIdentity)HttpContext.Current.User.Identity;
                            
            //            FormsAuthenticationTicket ticket = id.Ticket;

            //            // Get the stored user-data, in this case, our roles
            //            string userData = ticket.UserData;
            //            string[] roles = userData.Split(',');
            //            HttpContext.Current.User = new GenericPrincipal(id, roles);
            //        }
            //    }
            //}


            

        }


    }
}
