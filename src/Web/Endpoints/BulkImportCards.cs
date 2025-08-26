//using MagicBinder.Application.Common.Models;
//using MagicBinder.Application.Cards.Commands.CreateCard;
//using MagicBinder.Application.Cards.Commands.DeleteCard;
//using MagicBinder.Application.Cards.Commands.UpdateCard;
//using MagicBinder.Application.Cards.Commands.UpdateCardDetail;
//using MagicBinder.Application.Cards.Queries.GetCardsWithPagination;
//using Microsoft.AspNetCore.Http.HttpResults;
//using MagicBinder.Application.Cards.Commands.BulkImportCard;

//namespace MagicBinder.Web.Endpoints;
//public class BulkImportCards : EndpointGroupBase
//{
//    public override void Map(WebApplication app)
//    {
//        app.MapGroup(this)
//            //  .RequireAuthorization()
//            .MapPost(BulkImportCard, "BulkImport");

//    }



//    public async Task<Created<int>> BulkImportCard(ISender sender, BulkImportCardCommand command)
//    {
//        var id = await sender.Send(command);

//        return TypedResults.Created($"/{nameof(Cards)}/{id}", id);
//    }

//}
