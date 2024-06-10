using MediatR;
using System;

namespace DevRoom.Application.Features.Tags.Queries.GetById
{
    public class GetTagDetailQuery : IRequest<TagDetailVm>
    {
        public Guid Id { get; set; }
    }
}
