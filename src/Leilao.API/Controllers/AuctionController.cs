using Microsoft.AspNetCore.Mvc;
using RocketAuction.Application.UseCases.Auctions.GetCurrent;
using RocketAuction.Domain.Entities;

namespace RocketAuction.API.Controllers;

public class AuctionController : RocketBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetCurrentAuction([FromServices] IGetCurrentAuctionUseCase useCase)
    {
        var result = await useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }
}
