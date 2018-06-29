using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MysqlCore.Api.Controller
{
    public class BaseController : ControllerBase
    {
        public async Task<IActionResult> Response(object result)
        {
            //if (!notifications.Any())
            //{
                try
                {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    // Logar o erro (Elmah)
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            //}
            //else
            //{
            //    return BadRequest(new
            //    {
            //        success = false,
            //        errors = notifications
            //    });
            //}
        }
    }
}
