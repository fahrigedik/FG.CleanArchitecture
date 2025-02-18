using Domain.Common;
using MediatR;

namespace Application.Features.Auth.Login;

public sealed record LoginCommand(string emailOrUsername, string password) : IRequest<TokenResponse>;