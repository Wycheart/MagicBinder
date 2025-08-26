using System.Security.Cryptography.X509Certificates;
using HelpfulThings.Connect.Scryfall.Clients;
using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Domain.Entities;
using MagicBinder.Domain.Enums;
using MagicBinder.Domain.Events;
using Microsoft.Extensions.DependencyInjection.Helper;
using Newtonsoft.Json;

namespace MagicBinder.Application.Cards.Commands.CreateCard;
public record CreateCardCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCardCommand request, CancellationToken cancellationToken)
    {
        var entity = new Card
        {
           // ListId = request.ListId,
        };

        entity.AddDomainEvent(new CardCreatedEvent(entity));

        _context.Cards.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
