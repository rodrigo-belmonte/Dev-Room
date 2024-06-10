using MediatR;
using System.Collections.Generic;

namespace DevRoom.Application.Features.Tags.Commands.CreateMany
{
    public class CreateManyTagCommand : IRequest<CreateManyTagCommandResponse>
    {
        public IList<string> Tags { get; set; }
    }
}
