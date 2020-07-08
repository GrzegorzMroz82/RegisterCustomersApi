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
    public class RedbetController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly RegisterResponder registerResponder;
        private readonly string brandId = "Redbet";

        public RedbetController(IMediator mediator, IRegisterResponder registerResponder)
        {
            this.mediator = mediator;
            this.registerResponder = registerResponder as RegisterResponder;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<RedbetCustomer>))]
        public async Task<IActionResult> GetAll()
        {
            var res = await mediator.Send(new GetCustomersForBrandQuery(brandId));

            return Ok(res.Select(x => (RedbetCustomer)x));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RedbetCustomer customer)
        {
            await mediator.Send(new RegisterCustomerCommand(customer, brandId));

            return registerResponder.GetHttpResult();
        }
    }
}


