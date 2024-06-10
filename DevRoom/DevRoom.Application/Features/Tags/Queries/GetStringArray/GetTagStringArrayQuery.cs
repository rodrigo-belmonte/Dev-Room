using MediatR;
using System;
using System.Collections.Generic;

namespace DevRoom.Application.Features.Tags.Queries.GetStringArray
{
    public class GetTagStringArrayQuery : IRequest<IEnumerable<string>>
    {
        public Guid Id { get; set; }
    }
}
