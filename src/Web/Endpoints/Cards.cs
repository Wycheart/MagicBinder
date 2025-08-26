using MagicBinder.Application.Common.Models;
using MagicBinder.Application.Cards.Commands.CreateCard;
using MagicBinder.Application.Cards.Commands.DeleteCard;
using MagicBinder.Application.Cards.Commands.UpdateCard;
using MagicBinder.Application.Cards.Commands.UpdateCardDetail;
using MagicBinder.Application.Cards.Queries.GetCardsWithPagination;
using Microsoft.AspNetCore.Http.HttpResults;
using MagicBinder.Application.Cards.Commands.BulkImportCard;


namespace MagicBinder.Web.Endpoints;
public class Cards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
          //  .RequireAuthorization()
            .MapGet(GetCardsWithPagination)
            .MapPost(CreateCard)
            .MapPost(BulkImportCard, "BulkImport")
            .MapPut(UpdateCard, "{id}")
            .MapPut(UpdateCardDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteCard, "{id}");
    }

    public async Task<Ok<BulkImportCardResponse>> BulkImportCard(ISender sender, BulkImportCardCommand command)
    {
        var response = await sender.Send(command);

        return TypedResults.Ok(response);
    }


    public async Task<Ok<PaginatedList<CardBriefDto>>> GetCardsWithPagination(ISender sender, [AsParameters] GetCardsWithPaginationQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    public async Task<Created<int>> CreateCard(ISender sender, CreateCardCommand command)
    {
        var id = await sender.Send(command);

        return TypedResults.Created($"/{nameof(Cards)}/{id}", id);
    }

    public async Task<Results<NoContent, BadRequest>> UpdateCard(ISender sender, int id, UpdateCardCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<Results<NoContent, BadRequest>> UpdateCardDetail(ISender sender, int id, UpdateCardDetailCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await sender.Send(command);

        return TypedResults.NoContent();
    }

    public async Task<NoContent> DeleteCard(ISender sender, int id)
    {
        await sender.Send(new DeleteCardCommand(id));

        return TypedResults.NoContent();
    }
}
