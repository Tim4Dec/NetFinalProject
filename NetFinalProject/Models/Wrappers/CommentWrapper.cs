using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFinalProject.Models
{
    public class CommentWrapper
    {
        public int id { get; set; }

        public int owner { get; set; }

        public int floor { get; set; }

        public string content { get; set; }

        public string time { get; set; }

        public string nickname { get; set; }

        public string avatar { get; set; }

        public CommentWrapper(Comment comment)
        {
            id = comment.id;
            owner = comment.owner;
            floor = comment.floor;
            content = comment.content;
            time = comment.time.GetValueOrDefault().ToString("g");
            using (var db = new DBModel())
            {
                var user = db.users.SingleOrDefault(x => x.id == comment.owner);
                nickname = user.nickname;
                avatar = user.avatar;
            }
        }

        public CommentWrapper()
        {

        }

        public static List<CommentWrapper> WrapComment(List<Comment> list)
        {
            List<CommentWrapper> wrappers = new List<CommentWrapper>();

            foreach(var item in list)
            {
                CommentWrapper wrapper = new CommentWrapper(item);
                wrappers.Add(wrapper);
            }

            return wrappers;
        }

    }
}