using DevRoom.Application.Responses;

namespace DevRoom.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommandResponse : BaseResponse
    {
        public CreateTagCommandResponse() : base()
        {

        }

        public CreateTagDto Tag { get; set; }
    }
}