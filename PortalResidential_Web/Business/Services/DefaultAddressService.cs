using PortalResidential_Web.Business.ModelFactory;
using PortalResidential_Web.Business.Repositories;
using PortalResidential_Web.Models.BindingModels;
using PortalResidential_Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Business.Services
{
    public class DefaultAddressService : IService<defaultaddress>
    {
        public List<DefaultAddressBindingModel> GetAll(bool availables = true)
        {
            try
            {
                using (var db = new ResidentialEntities())
                {
                    var defaultAddressRepository = new DefaultAddressRepository(db);
                    var defaultaddresList = defaultAddressRepository.Search(x => x.isavailable == availables);
                    return defaultaddresList.ToBindingModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool DeleteById(int id_address)
        {
            try
            {
                using (var db = new ResidentialEntities())
                {
                    var defaultAddressRepository = new DefaultAddressRepository(db);
                    var address = defaultAddressRepository.SearchOne(x => x.id == id_address);
                    address.isavailable = false;
                    defaultAddressRepository.Update(address);
                    return db.SaveChanges() >= 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(defaultaddress obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(defaultaddress obj)
        {
            throw new NotImplementedException();
        }
    }
}