using PortalResidential_Web.Business.ModelFactory;
using PortalResidential_Web.Business.Repositories;
using PortalResidential_Web.Models.BindingModels;
using PortalResidential_Web.Models.Entity;
using System;
using System.Collections.Generic;

namespace PortalResidential_Web.Business.Services
{
    public class AppUsersService : IService<appusers>
    {
        public bool Save(appusers appuser)
        {
            try
            {
                using (var db = new ResidentialEntities())
                {
                    var appusersRepository = new AppUsersRepository(db);
                    appusersRepository.Insert(appuser);
                    return db.SaveChanges() >= 1;
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException) { return false; }
            catch (Exception ex) { throw ex; }
        }

        internal AppUserBindingModel Get(int id_address, string password)
        {
            try
            {
                using (ResidentialEntities db = new ResidentialEntities())
                {
                    AppUsersRepository appUserRepository = new AppUsersRepository(db);
                    var appUser = appUserRepository.SearchOne(
                        u => u.id_address == id_address &&
                        u.contrasena == password);
                    return appUser.ToBindingModel();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<AppUserBindingModel> GetAll()
        {
            try
            {
                using (ResidentialEntities db = new ResidentialEntities())
                {
                    AppUsersRepository appUserRepository = new AppUsersRepository(db);
                    var appUser = appUserRepository.GetAll();
                    return appUser.ToBindingModel();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(appusers obj)
        {
            throw new NotImplementedException();
        }
    }
}