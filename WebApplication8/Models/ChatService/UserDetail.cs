using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.ChatService
{
    public class UserDetail
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string IsAdmin { get; set; }
        public List<MessageDetail> Message { get; set; }

    }
}
