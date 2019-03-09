using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace MachineInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        // GET api/machine/Detail
        [HttpGet, Route("Detail")]
        public ActionResult<string> GetMAchineDetails()
        {
            var machineName = Environment.MachineName;
            var hostAddress = Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

            HttpContext.Response.Headers.Add("MachineName", machineName);
            HttpContext.Response.Headers.Add("hostAddress", hostAddress);

            return $"Deployed on Azure - Machine name: {machineName} - Host Address: {hostAddress} ";
        }
    }
}