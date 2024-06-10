using System;

namespace DevRoom.Application.Features.Tags.Queries.GetList
{
    public class TagListVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LinkedTags { get; set; }

    }
}
