using DevRoom.Application.Features.Contents.Commands.Create;
using DevRoom.Application.Features.Contents.Commands.Delete;
using DevRoom.Application.Features.Contents.Commands.Publish;
using DevRoom.Application.Features.Contents.Commands.Update;
using DevRoom.Application.Features.Contents.Queries.GetById;
using DevRoom.Application.Features.Contents.Queries.GetContentsList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRoom.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ContentController> _logger;
        public ContentController(IMediator mediator, ILogger<ContentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }



        [Authorize]
        [HttpGet("all", Name = "GetAllContents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ContentListVm>>> GetContents()
        {
            _logger.LogInformation(message: $"inside Content getall api call. ");

            var dtos = await _mediator.Send(new GetContentsListQuery());
            return Ok(dtos);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetContentById")]
        public async Task<ActionResult<ContentDetailVm>> GetContentById(Guid id)
        {
            _logger.LogInformation(message: $"inside Content get api call. ");

            var getContentDetailQuery = new GetContentDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getContentDetailQuery));
        }

        [Authorize]
        [HttpPost("new", Name = "AddContent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContentCommand createContentCommand)
        {
            _logger.LogInformation(message: $"inside Content new api call. ");

            var response = await _mediator.Send(createContentCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpPut(Name = "UpdateContent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateContentCommand updateContentCommand)
        {
            _logger.LogInformation(message: $"inside Content edit api call. ");

            var res = await _mediator.Send(updateContentCommand);
            return Ok(res);
        }

        [Authorize]
        [HttpPut("publish", Name = "PublishContent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Publish([FromBody] PublishContentCommand publishContentCommand)
        {
            _logger.LogInformation(message: $"inside Content publish api call. ");

           var res = await _mediator.Send(publishContentCommand);
            return Ok(res);
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteContent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            _logger.LogInformation(message: $"inside Content delete api call. ");

            var deleteContentCommand = new DeleteContentCommand() { ContentId = id };
           var res =  await _mediator.Send(deleteContentCommand);
            return Ok(res);
        }
    }
}
