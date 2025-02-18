using FluentValidation;

namespace Application.Features.Books.Command.CreateBook;
public class CreateBookValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookValidator()
    {
        RuleFor(x => x.title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.author).NotEmpty().WithMessage("Author is required");
        RuleFor(x => x.price).NotEmpty().WithMessage("Price is required");
    }
}
