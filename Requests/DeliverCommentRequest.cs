using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFinalProject.Requests
{
    public class DeliverCommentRequest
    {
        public string Content { get; set; }
        public int Speech { get; set; }
        public int User { get; set; }
    }
}
