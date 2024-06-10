using DevRoom.Domain.Common;
using System;

namespace DevRoom.Domain.Entities
{
    public class Library : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string LinkDocumentation { get; set; }
    }
}
