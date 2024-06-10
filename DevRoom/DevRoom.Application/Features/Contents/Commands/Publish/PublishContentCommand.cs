using DevRoom.Application.Responses;
using MediatR;
using System;

namespace DevRoom.Application.Features.Contents.Commands.Publish
{
    public class PublishContentCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubHeading { get; set; }
        public string ContentText { get; set; }
        public string CoverImage { get; set; }
        public string Tags { get; set; }
        public Guid IdTechnology { get; set; }
        public string PublishedBy { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int Status { get; set; }
    }
}