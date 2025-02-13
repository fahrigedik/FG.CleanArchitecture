using Domain.Repositories;
using MediatR;

namespace Application.Features.Books.Command.UpdateBook;

internal sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, string>
{
    private readonly IBookRepository _bookRepository;
    public UpdateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }


    public async Task<string> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.id);
        if (book == null)
        {
            return "Book not found.";
        }
        book.Title = request.title;
        book.Author = request.author;
        book.Price = request.price;
        book.PictureUrl = request.pictureUrl;
        await _bookRepository.UpdateAsync(book);
        return "Book updated successfully.";
    }
}