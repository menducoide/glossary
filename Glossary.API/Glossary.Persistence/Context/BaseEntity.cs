using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Persistence.Context
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public bool Active { get; set; }
    }
}
