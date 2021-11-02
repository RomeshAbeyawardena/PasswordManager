using DNI.Web.Shared.Attributes;
using DNI.Web.Shared.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PasswordManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Client.Core
{
    [ClientController,
     ClientControllerAllowedHeaders(ClientControllerAllowedHeadersAttribute.Any),
     ClientControllerAllowedOrigins(Constants.ClientUrl),
     ClientControllerAllowedMethods(ClientControllerAllowedMethodsAttribute.Any)]
    public abstract class ClientApiControllerBase : ApiControllerBase
    {
        
    }
}
