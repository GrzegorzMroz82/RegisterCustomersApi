

using GameTek.Boundary;
using GameTek.Services.Customers.Commands;
using GameTek.Services.Users.Queries;
using GameTekRegWebApp.Models;
using GameTekRegWebApp.Responders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTekRegWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MrGreenController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly RegisterResponder registerResponder;
        private readonly string brandId = "MrGreen";

        public MrGreenController(IMediator mediator, IRegisterResponder registerResponder)
        {
            this.mediator = mediator;
            this.registerResponder = registerResponder as RegisterResponder;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<MrGreenCustomer>))]
        public async Task<IActionResult> GetAll()
        {
            var res = await mediator.Send(new GetCustomersForBrandQuery(brandId));

            return Ok(res.Select(x => (MrGreenCustomer)x));
        }

        [HttpPost]        
        public async Task<IActionResult> Register([FromBody] MrGreenCustomer customer)
        {
            await mediator.Send(new RegisterCustomerCommand(customer, brandId));

            return registerResponder.GetHttpResult();
        }
    }
}

