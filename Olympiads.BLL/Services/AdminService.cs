using AutoMapper;
using Olympiads.BLL.BusinessModels;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Services
{
    public class AdminService : IAdminService
    {
        readonly OlympiadDb db = new OlympiadDb();
        ICryptoService Crypto { get; set; }
        
        public AdminLoggedDTO Login(AuthAdminDTO auth)
        {
            AdminLoggedDTO adminLogged = null;
            var admin = db.Administrators.FirstOrDefault(x => x.Login == auth.Login);
            if (admin != null)
            {
                if (Crypto.Compare(Crypto.Compute(auth.Password,admin.PasswordSalt),admin.PasswordHash))
                {
                    adminLogged = new AdminLoggedDTO() { IsLogged = true, Id = admin.Id };
                }
                else
                {
                    adminLogged = new AdminLoggedDTO() { IsLogged = false };
                }
            }
            else
            {
                adminLogged = new AdminLoggedDTO() { IsLogged = false };
            }
            return adminLogged;
        }
        public void ChangeCredentials(ChangeCredentialsDTO credentials)
        {
            var admin = db.Administrators.FirstOrDefault(x => x.Login == credentials.OldLogin);
            IValidationResult validationResult = new ValidResult();
            if (admin != null)
            {
                admin.PasswordHash = Crypto.Compute(credentials.Login,admin.PasswordSalt);
                admin.Login = credentials.Login;

                db.SaveChanges();
            }
        }
        public AdminInfo GetAdminInfo(int AdminId)
        {
            var login = db.Administrators.Where(x => x.Id == AdminId).Select(u => u.Login).FirstOrDefault();
            return new AdminInfo() { Login = login };
        }
        public AdminService(ICryptoService crypto)
        {
            Crypto = crypto;
        }
    }
}
