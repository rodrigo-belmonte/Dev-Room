using DevRoom.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevRoom.Domain.Entities
{
    public class Tip : AuditableEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Tags { get; set; }
    }
}
