using Application.Features.Books.Command.CreateBook;
using Application.Features.Books.Command.DeleteBook;
using Application.Features.Books.Command.UpdateBook;
using Application.Features.Books.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BookController : BaseApiController
    {
        public BookController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(200, response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(200, response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(200, response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(200, response);
        }
    }
}
