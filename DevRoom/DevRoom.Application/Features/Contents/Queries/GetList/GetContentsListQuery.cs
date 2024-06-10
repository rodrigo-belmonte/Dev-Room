using MediatR;
using System.Collections.Generic;

namespace DevRoom.Application.Features.Contents.Queries.GetContentsList
{
    public class GetContentsListQuery : IRequest<IEnumerable<ContentListVm>>
    {

    }
}
