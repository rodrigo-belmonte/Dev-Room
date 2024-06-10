using DevRoom.Application.Features.Tags.Commands.Create;
using DevRoom.Application.Features.Tags.Commands.CreateMany;
using DevRoom.Application.Features.Tags.Commands.Delete;
using DevRoom.Application.Features.Tags.Commands.Update;
using DevRoom.Application.Features.Tags.Queries.GetById;
using DevRoom.Application.Features.Tags.Queries.GetList;
using DevRoom.Application.Features.Tags.Queries.GetStringArray;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevRoom.Api.Controllers
{
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("allTagNames", Name = "GetAllTagsNames")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<string>>> GetAllTagsNames()
        {
            var dtos = await _mediator.Send(new GetTagStringArrayQuery());
            return Ok(dtos);
        }

        [HttpGet("all", Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TagListVm>>> GetAll()
        {
            var dtos = await _mediator.Send(new GetTagListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetTagById")]
        public async Task<ActionResult<TagDetailVm>> GetTagById(Guid id)
        {
            var getTagDetailQuery = new GetTagDetailQuery()
            { Id = id };
            return Ok(await _mediator.Send(getTagDetailQuery));
        }

        [Authorize]
        [HttpPost(Name = "AddTag")]
        public async Task<ActionResult<CreateTagCommandResponse>> Create([FromBody] CreateTagCommand createTagCommand)
        {
            var response = await _mediator.Send(createTagCommand);
            return Ok(response);
        }

        [HttpPost("createMany", Name = "AddManyTag")]
        public async Task<ActionResult<CreateManyTagCommandResponse>> CreateMany([FromBody] CreateManyTagCommand createManyTagCommand)
        {
            var response = await _mediator.Send(createManyTagCommand);
            return Ok(response);
        }
        [Authorize]
        [HttpPut(Name = "Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTagCommand updateContentCommand)
        {
            var response = await _mediator.Send(updateContentCommand);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete("{id}", Name = "DeleteTag")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteTagCommand = new DeleteTagCommand() { Id = id };
            await _mediator.Send(deleteTagCommand);
            return NoContent();
        }
    }
}