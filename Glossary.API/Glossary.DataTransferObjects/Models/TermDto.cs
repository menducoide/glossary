using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Glossary.DataTransferObjects.Models
{
    public class TermDto
    {
        public int? TermId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }
    }
}
