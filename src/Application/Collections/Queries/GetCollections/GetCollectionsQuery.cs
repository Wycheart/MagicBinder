using HelpfulThings.Connect.Scryfall.Clients;
using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Application.Common.Models;
using MagicBinder.Application.Common.Security;
using MagicBinder.Domain.Enums;

namespace MagicBinder.Application.Collections.Queries.GetCollections;
[Authorize]
public record GetCollectionsQuery : IRequest<CollectionsVm>;

public class GetCollectionsQueryHandler : IRequestHandler<GetCollectionsQuery, CollectionsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCollectionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CollectionsVm> Handle(GetCollectionsQuery request, CancellationToken cancellationToken)
    {

        IScryfallApiClient client = new ScryfallApiClient();
        var x = await client.Cards.RandomAsync(string.Empty);

        return new CollectionsVm
        {
            Collection = await _context.Collections
                //.Include(x =>x.Cards)
                .AsNoTracking()
                .ProjectTo<CollectionDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
