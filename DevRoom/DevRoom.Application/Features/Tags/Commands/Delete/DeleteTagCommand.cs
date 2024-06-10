using DevRoom.Application.Responses;
using MediatR;
using System;

namespace DevRoom.Application.Features.Tags.Commands.Delete
{
    public class DeleteTagCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
