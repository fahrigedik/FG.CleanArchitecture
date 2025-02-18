using MediatR;

namespace Application.Features.Books.Command.DeleteBook;
public sealed record DeleteBookCommand(int Id) : IRequest<string>;