using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Models
{
    public class Speaker
    {
        public Int32 SpeakerID { get; set; }

        [Required(ErrorMessage = "{0} is Required")]
        [Display(Name = "Speaker Name")]
        [DataType(DataType.Text)]
        public String Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public String EmailAddress { get; set; }

        //public virtual List<Session> Sessions { get; set; }
    }
}
