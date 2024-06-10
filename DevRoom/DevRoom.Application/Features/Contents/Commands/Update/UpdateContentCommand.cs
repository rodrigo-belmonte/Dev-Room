using DevRoom.Application.Responses;
using MediatR;
using System;

namespace DevRoom.Application.Features.Contents.Commands.Update
{
    public class UpdateContentCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubHeading { get; set; }
        public string ContentText { get; set; }
        public string Tags { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string PublishedBy { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int Status { get; set; }
        // public string CoverImage { get; set; }
        //public int TotalViews { get; set; }
        //public int TotalLikes { get; set; }
        //public int TotalBookmarks { get; set; }
        //public int TotalComments { get; set; }
        //public int TotalShares { get; set; }
        //public bool Published { get; set; }
        //public bool Spotlight { get; set; }
        //public int SpotlightOrder { get; set; }
        //public string PublishedBy { get; set; }
        //public DateTime? PublishedDate { get; set; }

    }
}
