using System;

namespace DevRoom.Application.Features.Tags.Commands.Create
{
    public class CreateTagDto
    {
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public string LinkedTags { get; set; }
        
        
    }
}
