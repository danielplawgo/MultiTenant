using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MultiTenantDemo1.Tenants
{
    public class CustomPageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            foreach (var selector in model.Selectors.ToList())
            {
                selector.AttributeRouteModel.Template = "{tenant=none}/" + selector.AttributeRouteModel.Template;
            }
        }
    }
}
