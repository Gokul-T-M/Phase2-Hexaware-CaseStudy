using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class SpeakerDetails
    {
        [Key]
        public int SpeakerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SpeakerName { get; set; }
    }
}
