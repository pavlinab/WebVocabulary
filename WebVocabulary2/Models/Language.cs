using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVocabulary2.Models
{
    public class Language
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }
    }
}