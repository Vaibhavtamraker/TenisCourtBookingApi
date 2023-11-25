﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenisCourtBookingAPP.Domain.Enums
{
    public class Bookingclass
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourtId { get; set; }
        [Required]
        public string bookingtime { get; set; }
        [Required]
        public string BookingDuration { get; set; }
    }
}
