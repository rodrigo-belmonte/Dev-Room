using DevRoom.Domain.Common;
using System;

namespace DevRoom.Domain.Entities
{
    public class Content : AuditableEntity
    {
        public string Title { get; set; }
        public string SubHeading { get; set; }
        public string ContentText { get; set; }
        public string CoverImage { get; set; }
        public string Tags { get; set; }
        public int TotalViews { get; set; }
        public int TotalLikes { get; set; }
        public int TotalBookmarks { get; set; }
        public int TotalComments { get; set; }
        public int TotalShares { get; set; }
        public int Status { get; set; }
        public bool Spotlight { get; set; }
        public int SpotlightOrder { get; set; }
        public string PublishedBy { get; set; }
        public DateTime? PublishedDate { get; set; }

        //public string ReadingTime { get; set; }
        //public string CoverImageAlt { get; set; }
        //public int IdAuthor { get; set; }
        //public Author Author { get; set; }

    }
}
