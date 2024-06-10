using System;

namespace DevRoom.Application.Features.Contents.Queries.GetById
{
    public class ContentDetailVm
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubHeading { get; set; }
        public string ContentText { get; set; }
        public string CoverImage { get; set; }
        public string Tags { get; set; }
        
        public int Status { get; set; }
        
        public string PublishedBy { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Guid IdTechnology { get; set; }
        public string TechnologyName { get; set; }
        //public TechnologyDto Technology { get; set; }

        //public int TotalViews { get; set; }
        //public int TotalLikes { get; set; }
        //public int TotalBookmarks { get; set; }
        //public int TotalComments { get; set; }
        //public int TotalShares { get; set; }
        //public bool Spotlight { get; set; }
        //public int SpotlightOrder { get; set; }
    }
    
}
