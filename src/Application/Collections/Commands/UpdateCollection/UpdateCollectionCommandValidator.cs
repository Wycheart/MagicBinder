using MagicBinder.Application.Common.Interfaces;

namespace MagicBinder.Application.Collections.Commands.UpdateCollection;
public class UpdateCollectionCommandValidator : AbstractValidator<UpdateCollectionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCollectionCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Collection.Title)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueTitle(UpdateCollectionCommand model, string title, CancellationToken cancellationToken)
    {
        return !await _context.Collections
            .Where(l => l.Id != model.Collection.Id)
            .AnyAsync(l => l.Title == title, cancellationToken);
    }
}
