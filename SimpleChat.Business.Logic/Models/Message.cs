using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.Business.Logic.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Msg { get; set; }
    }
}
