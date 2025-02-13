using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Books.Command.CreateBook;

internal sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, string>
{
    private readonly IBookRepository _bookRepository;
    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<string> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.title,
            Author = request.author,
            PictureUrl = request.pictureUrl,
            Price = request.price
        };
        await _bookRepository.AddAsync(book);
        return "Book created successfully.";
    }
}