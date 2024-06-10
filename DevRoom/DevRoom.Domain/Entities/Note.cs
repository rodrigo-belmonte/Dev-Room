using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevRoom.Domain.Common;

namespace DevRoom.Domain.Entities
{
    public class Note : AuditableEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Tags { get; set; }
    }
}
