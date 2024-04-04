using Neerogilksample.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Models
{
    public class Notification : IEntityBase
    {
        [Key]
        public int  Id { get; set; }
        public DateTime NotiDate { get; set; }
        public string Type { get; set; }
        public string NotiDescription { get; set; }
    }
}
