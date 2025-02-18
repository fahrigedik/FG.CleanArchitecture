using Domain.Entities;
using MediatR;

namespace Application.Features.Books.Command.UpdateBook;

public sealed record UpdateBookCommand(int id, string title, string author, decimal price, string? pictureUrl)
    : IRequest<string>;