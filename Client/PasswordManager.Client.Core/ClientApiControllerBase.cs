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
    public abstract class ClientApiControllerBase : ApiControllerBase
    {
        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", Constants.ClientUrl);
            Response.Headers.Add("Access-Control-Request-Method", "GET, POST");
            Response.Headers.Add("Access-Control-Request-Headers", "*");
            return base.Ok(value);
        }

    }
}
