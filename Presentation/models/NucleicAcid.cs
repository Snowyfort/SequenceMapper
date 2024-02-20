using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.models
{
    public class NucleicAcid
    {
        [Required]
        [Display(Name = "DNA Base Sequence")]
        public string Bases { get; set; } = string.Empty;
        public bool IsRNA { get; set; } = false;
    }
}