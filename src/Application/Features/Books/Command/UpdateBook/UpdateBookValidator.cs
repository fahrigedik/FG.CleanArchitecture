using FluentValidation;

namespace Application.Features.Books.Command.UpdateBook;
public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.author).NotEmpty().WithMessage("Author is required");
        RuleFor(x => x.price).NotEmpty().WithMessage("Price is required");
    }
}
