namespace DevRoom.Application.Features.Tags.Commands.Update
{
    using DevRoom.Application.Responses;
    using MediatR;
    using System;

    public class UpdateTagCommand: IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LinkedTags { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int Status { get; set; }
        
    }
}