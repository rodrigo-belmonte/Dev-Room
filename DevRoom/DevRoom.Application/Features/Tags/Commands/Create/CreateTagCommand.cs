using MediatR;

namespace DevRoom.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommand : IRequest<CreateTagCommandResponse>
    {
        public string Name { get; set; }
        public string LinkedTags { get; set; }
        
    }
}
