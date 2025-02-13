using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Books.Queries.GetAllBooks;
public sealed record GetAllBooksQuery() : IRequest<List<Book>>;

internal sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
{
    private readonly IBookRepository _bookRepository;
    public GetAllBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.ListAllAsync();
    }
}


