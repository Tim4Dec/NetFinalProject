using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFinalProject.Models
{
    public class MyCommentWrapper
    {
        public int id { get; set; }

        public int speech { get; set; }

        public string content { get; set; }

        public string time { get; set; }

        public string avatar { get; set; }
        public string title { get; set; }

        public MyCommentWrapper(Comment comment)
        {
            id = comment.id;
            content = comment.content;
            time = comment.time.GetValueOrDefault().ToString("g");
            speech = comment.speech;

            using (var db = new DBModel())
            {
                var s = db.speeches.SingleOrDefault(x => x.id == comment.speech);
                var user = db.users.SingleOrDefault(x => x.id == s.owner);
                title = s.title;
                avatar = user.avatar;
            }

        }

        public MyCommentWrapper()
        {

        }

        public static List<MyCommentWrapper> WrapComment(List<Comment> list)
        {
            List<MyCommentWrapper> wrappers = new List<MyCommentWrapper>();

            foreach (var item in list)
            {
                MyCommentWrapper wrapper = new MyCommentWrapper(item);
                wrappers.Add(wrapper);
            }

            return wrappers;
        }
    }
}