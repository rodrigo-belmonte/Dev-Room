using System;

namespace DevRoom.Application.Features.Tags.Queries.GetById
{
    public class TagDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LinkedTags { get; set; }

    }
}
