﻿using System.Collections.Generic;

namespace Domain.Models
{
    public class ListLastMessages
    {
        public string IdClient { get; set; }
        public string PhoneFrom { get; set; }
        public List<LastMessage> MessageList { get; set; }
    }
}
