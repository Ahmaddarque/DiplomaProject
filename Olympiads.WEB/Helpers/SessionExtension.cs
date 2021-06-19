using Olympiads.BLL.Services;
using Olympiads.WEB.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Helpers
{
    //Антипааааатерн
    public static class SessionExtension
    {
        private static int visiterId;
        private const string userInfo = "UserInfo";

        private static void SetDefaultUser(this HttpSessionStateBase httpSession)
        {
           var ip = HttpContext.Current.Request.UserHostAddress;
            new VisiterService().Register(ip);
            var visiterId = new VisiterService().GetVisiter(HttpContext.Current.Request.UserHostAddress).Id;
            httpSession[userInfo] = new UserInfo() { Id = visiterId, Role = Role.Visiter };
        }
        public static UserInfo GetUserInfo(this HttpSessionStateBase httpSession)
        {
            try
            {
                
                if (httpSession[userInfo] == null)
                {
                    httpSession.SetDefaultUser();
                }
            }
            catch (Exception)
            {
                httpSession.SetDefaultUser();
            }
            return (UserInfo)httpSession[userInfo];

        }
        public static void SetUserInfo(this HttpSessionStateBase httpSession, UserInfo user)
        {
            var currentUser = httpSession.GetUserInfo();
            if (currentUser != null && currentUser.Role == Role.Visiter)
            {
                visiterId = currentUser.Id;
            }
            httpSession[userInfo] = user;
        }

        public static void Logout(this HttpSessionStateBase httpSession)
        {
            httpSession[userInfo] = new UserInfo() { Id = visiterId,Role = Role.Visiter};
        }
    }
}