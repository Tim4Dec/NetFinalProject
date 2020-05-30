using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFinalProject.Requests
{
    public class ModifyPwdRequest
    {
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
        public int Id { get; set; }
    }
}
