using Domain.Repositories;
using MediatR;

namespace Application.Features.Books.Command.DeleteBook;

internal sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
{
    private readonly IBookRepository _bookRepository;
    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        if (book == null)
        {
            return "Book not found.";
        }
        await _bookRepository.DeleteAsync(book);
        return "Book deleted successfully.";
    }
}