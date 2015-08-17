using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVocabulary2.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }

        [Required, StringLength(5)]
        public string Role { get; set; }
    }
}