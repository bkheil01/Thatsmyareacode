using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace thatsmyareacode.Models
{
    public class Zinger
    {
        public int ZingerID { get; set; }
        [Required(ErrorMessage="Message is required")]
        [DisplayName("Zinger:")]
        public string ZingerMessage { get; set; }
        public string ProfileName { get; set; }
        public int ThumbsUpCounter { get; set; }
    }
}