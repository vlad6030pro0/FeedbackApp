using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Models.Models;

namespace FeedbackApp.Models.DBModels
{
    public class DBMessage : Message
    {
        [Key]
        public int Id { get; set; }
        public string? Text { get; set; }
        [ForeignKey("IdUser")]
        public int? IdUser { get; set; }
    }
}
