using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.ChatService
{
    public class Meeting
    {

        public string Id { set; get; }
        public List<MessageDetail> Messages { set; get; }
        public DateTime StartTime { set; get; }

    }
}
