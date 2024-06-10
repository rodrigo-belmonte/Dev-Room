using DevRoom.Application.Responses;
using MediatR;
using System;

namespace DevRoom.Application.Features.Contents.Commands.Delete
{
    public class DeleteContentCommand : IRequest<BaseResponse>
    {
        public Guid ContentId { get; set; }
    }
}
