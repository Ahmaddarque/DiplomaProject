using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Helpers
{
    //Класс-бог
    public static class SessionExtension
    {
        #region Admin
        public static Admin GetAdmin(this HttpSessionStateBase httpSession)
        {
            Admin admin = null;
            if (httpSession["Admin"] is Admin admininstrator)
            {
                admin = admininstrator;
            }

            return admin;
        }
        public static void SetAdmin(this HttpSessionStateBase httpSession,Admin admin)
        {
            httpSession["Admin"] = admin;
        }
        #endregion
        public static Role GetRole(this HttpSessionStateBase httpSession)
        {
            Role role = Role.Visiter;
            if (GetParticipant(httpSession) != null)
            {
                role = Role.Participant;
            }
            else if(GetAdmin(httpSession) != null)
            {
                role = Role.Admin;
            }

            return role;
        }
        #region Participant Control
        public static void SetParticipant(this HttpSessionStateBase httpSession, Participant participant)
        {
            httpSession["Participant"] = participant;
        }
        public static Participant GetParticipant(this HttpSessionStateBase httpSession) => (Participant)httpSession["Participant"];
        public static void Logout(this HttpSessionStateBase httpSession)
        {
            SetParticipant(httpSession, null);
            SetAdmin(httpSession, null);
        }
        #endregion
        #region Visiter
        public static Visiter GetVisiter(this HttpSessionStateBase httpSession)
        {
            return (Visiter)httpSession["Visiter"];
        }
        public static void SetVisiter(this HttpSessionStateBase httpSession, Visiter visiter)
        {
            httpSession["Visiter"] = visiter;
        }

        public static bool IsVisiter(this HttpSessionStateBase httpSession)
        {
            bool isVisiter = false;
            if (GetVisiter(httpSession) != null)
            {
                isVisiter = true;
            }

            return isVisiter;
        }
        #endregion
    }
}