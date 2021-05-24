using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Glossary.Persistence.Context
{
   public class Term : BaseEntity
    {
        [Key]
        public int TermId { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
    }
}
