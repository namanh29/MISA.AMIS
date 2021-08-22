using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAmisController : EntityController<EmployeeAmis>
    {
        public EmployeeAmisController(IBaseService<EmployeeAmis> baseService):base(baseService)
        {

        }
    }
}
