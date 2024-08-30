using Microsoft.AspNetCore.Mvc;
using RocketAuction.API.Filters;
using RocketAuction.Application.UseCases.Offers.CreateOffer;
using RocketAuction.Communication.Requests;

namespace RocketAuction.API.Controllers;
public class OfferController : RocketBaseController
{
    [HttpPost("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public async Task<IActionResult> CreateOffer(
        [FromServices] ICreateOfferUseCase useCase,
        [FromRoute] int itemId, 
        [FromBody] RequestCreateOfferJson request)
    {
        var id = await useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
