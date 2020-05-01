using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payroll.Application.Commands.Payments;

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IMediator _mediator;

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return new string[] { "payment controller" };
        }


        public PaymentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [Route("salary")]
        [HttpPost]
        public async Task<ActionResult<PaymentDTO>> GeneratePaymentAsync([FromBody] GeneratePaymentCmd generatePaymentCmd)
        {
            return await _mediator.Send(generatePaymentCmd);
        }

    }
}


