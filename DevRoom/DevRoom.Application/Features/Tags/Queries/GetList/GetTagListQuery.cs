using MediatR;
using System;
using System.Collections.Generic;

namespace DevRoom.Application.Features.Tags.Queries.GetList
{
    public class GetTagListQuery : IRequest<List<TagListVm>>
    {
        public Guid Id { get; set; }

    }
}
