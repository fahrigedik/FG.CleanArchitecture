using Domain.Entities;
using MediatR;

namespace Application.Features.Books.Command.CreateBook;

public sealed record CreateBookCommand(string title, string author,  string? pictureUrl, decimal price) : IRequest<string>;