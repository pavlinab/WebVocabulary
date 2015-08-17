using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVocabulary2.Models
{
    public class Message
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required, StringLength(2000)]
        public string Content { get; set; }

        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserDeletedThis { get; set; }

    }
}