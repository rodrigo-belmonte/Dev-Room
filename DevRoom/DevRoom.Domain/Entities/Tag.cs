using DevRoom.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevRoom.Domain.Entities
{
    public class Tag : AuditableEntity
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public string LinkedTags { get; set; }

    }
}
