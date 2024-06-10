using DevRoom.Domain.Entities;
using System;

namespace DevRoom.Application.Features.Contents.Queries.GetContentsList
{
    public class ContentListVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string SubHeading { get; set; }
        public string CoverImage { get; set; }

        public string Tags { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string PublishedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }
        public string TechnologyName { get; set; }
        public Guid IdTechnology { get; set; }

        //public string ReadingTime { get; set; }
        //public string CoverImageAlt { get; set; }
    }
}
