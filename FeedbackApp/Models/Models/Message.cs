﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? IdUser { get; set; }
    }
}
