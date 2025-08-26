using MagicBinder.Application.Common.Interfaces;

namespace MagicBinder.Application.Collections.Commands.CreateCollection;
public class CreateCollectionCommandValidator : AbstractValidator<CreateCollectionCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCollectionCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return !await _context.Collections
            .AnyAsync(l => l.Title == title, cancellationToken);
    }
}
