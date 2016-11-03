using PortalResidential_Web.Models;
using PortalResidential_Web.Models.BindingModels;
using PortalResidential_Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Business.ModelFactory
{
    public static class ModelFactory
    {
        public static appusers ToEntityModel(this RegisterViewModel model)
        {
            return new appusers
            {
                apellido = model.lastname,
                contrasena = model.password,
                correo = model.email,
                id_address = model.id_address,
                nombre = model.name,
                telefono = model.telephone,
                id = 0
            };
        }

        public static List<DefaultAddressBindingModel> ToBindingModel(this List<defaultaddress> modelList)
        {
            return modelList.Select(x => new DefaultAddressBindingModel
            {
                id = x.id,
                address = x.address,
                isavailable = x.isavailable
            }).ToList();
        }

        public static AppUserBindingModel ToBindingModel(this appusers model)
        {
            return model != null ? new AppUserBindingModel
            {
                apellido = model.apellido,
                contrasena = model.contrasena,
                correo = model.correo,
                id_address = (long)model.id_address,
                nombre = model.nombre,
                telefono = model.telefono,
                id = 0
            } : null;
        }

        public static List<AppUserBindingModel> ToBindingModel(this List<appusers> modelList)
        {
            return modelList.Select(x => new AppUserBindingModel
            {
                apellido = x.apellido,
                id_address = (long)x.id_address,
                contrasena = x.contrasena,
                correo = x.correo,
                id = x.id,
                nombre = x.nombre,
                reg_date = x.reg_date,
                telefono = x.telefono
            }).ToList();
        }
    }
}