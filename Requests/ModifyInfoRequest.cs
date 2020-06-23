using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFinalProject.Requests
{
    public class ModifyInfoRequest
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public string Username { get; set; }

        public DateTime? Birthday { get; set; }

        public int Sex { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
