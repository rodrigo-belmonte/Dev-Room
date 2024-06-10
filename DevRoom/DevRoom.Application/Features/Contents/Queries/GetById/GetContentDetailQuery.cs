using MediatR;
using System;

namespace DevRoom.Application.Features.Contents.Queries.GetById
{
    public class GetContentDetailQuery : IRequest<ContentDetailVm>
    {
        public Guid Id { get; set; }
    }
}
