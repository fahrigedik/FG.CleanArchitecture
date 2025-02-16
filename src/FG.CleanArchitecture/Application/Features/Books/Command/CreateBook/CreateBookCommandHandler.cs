using Domain.Entities;
using Domain.Repositories;
using Domain.UnitOfWork;
using MediatR;

namespace Application.Features.Books.Command.CreateBook;

internal sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, string>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
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
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return "Book created successfully.";
    }
}