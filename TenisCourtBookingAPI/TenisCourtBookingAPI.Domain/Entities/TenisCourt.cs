using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Enums;

namespace TenisCourtBookingAPP.Domain.Entities
{
    public class TenisCourt
    {
        [Key]
        public int CourtId { get; set; }
        [Required]
        public string CourtName { get; set; }
        [Required]
        public string CourtAddress { get; set; }
        [Required]
        public bool CourtStatus { get; set; }
        [Required]
        public CourtType CourtType { get; set; }
    }
}
