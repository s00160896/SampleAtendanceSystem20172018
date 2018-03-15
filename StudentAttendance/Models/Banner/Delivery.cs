using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentAttendance.Models.Banner
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name ="Day of Delivery")]
        public string Day { get; set; }

        [Display(Name = "Delivery Time")]
        public TimeSpan TimeSlot { get; set; }

        [ForeignKey("DeliveryOf")]
        public int ModuleId { get; set; }

        [ForeignKey("DeliveredBy")]
        public int LecturerId { get; set; }

        public virtual Module DeliveryOf { get; set; }
        public virtual Lecturer DeliveredBy { get; set; }
    }
}