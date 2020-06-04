using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFinalProject.Models
{
    public class NoticeWrapper
    {
        public int id { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public string content { get; set; }

        public string time { get; set; }

        public NoticeWrapper(Notice notice)
        {
            id = notice.id;
            title = notice.title;
            author = notice.author;
            content = notice.content;
            time = notice.time.GetValueOrDefault().ToString("D");
        }

        public static List<NoticeWrapper> WrapNotice(List<Notice> list)
        {
            List<NoticeWrapper> wrappers = new List<NoticeWrapper>();
            foreach (Notice item in list)
            {
                NoticeWrapper wrapper = new NoticeWrapper(item);
                wrappers.Add(wrapper);
            }

            return wrappers;
        }
        
    }
}