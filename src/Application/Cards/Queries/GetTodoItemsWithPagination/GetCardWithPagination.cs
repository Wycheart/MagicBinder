using MagicBinder.Application.Common.Interfaces;
using MagicBinder.Application.Common.Mappings;
using MagicBinder.Application.Common.Models;

namespace MagicBinder.Application.Cards.Queries.GetCardsWithPagination;
public record GetCardsWithPaginationQuery : IRequest<PaginatedList<CardBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCardsWithPaginationQueryHandler : IRequestHandler<GetCardsWithPaginationQuery, PaginatedList<CardBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCardsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CardBriefDto>> Handle(GetCardsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cards
            //.Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Name)
            .ProjectTo<CardBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
