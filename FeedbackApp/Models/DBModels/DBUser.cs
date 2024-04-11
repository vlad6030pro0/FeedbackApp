using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Models.Models;

namespace FeedbackApp.Models.DBModels
{
    public class DBUser : User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ChatId { get; set; }
    }
}
