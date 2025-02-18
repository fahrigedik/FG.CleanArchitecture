using Domain.Repositories;
using Domain.UnitOfWork;
using MediatR;

namespace Application.Features.Books.Command.DeleteBook;

internal sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        if (book == null)
        {
            return "Book not found.";
        }
        await _bookRepository.DeleteAsync(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "Book deleted successfully.";
    }
}