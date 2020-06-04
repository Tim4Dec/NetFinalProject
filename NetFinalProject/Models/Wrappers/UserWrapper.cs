using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFinalProject.Models
{
    public class UserWrapper
    {
        public int id { get; set; }

        public string nickname { get; set; }

        public string username { get; set; }

        public string avatar { get; set; }

        public string birthday { get; set; }

        public string sex { get; set; }

        public UserWrapper(User user)
        {
            id = user.id;
            nickname = user.nickname;
            username = user.username;
            avatar = user.avatar;
            birthday = user.birthday.GetValueOrDefault().ToString("D");
            sex = transformSex(user.sex);
        }
        public UserWrapper()
        {

        }

        static string transformSex(int sex)
        {
            if(sex == 0)
            {
                return "男";
            }else if(sex == 1)
            {
                return "女";
            }
            else
            {
                return "未知";
            }
        }
    }
}