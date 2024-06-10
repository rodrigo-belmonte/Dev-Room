using DevRoom.Application.Responses;
using System;

namespace DevRoom.Application.Features.Contents.Commands.Create
{
    public class CreateContentCommandResponse : BaseResponse
    {
        public CreateContentCommandResponse() : base()
        {
            
        }
        public Guid Id { get; set; }
        
        
    }
}