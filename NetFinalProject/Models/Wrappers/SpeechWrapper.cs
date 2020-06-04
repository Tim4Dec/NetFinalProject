using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetFinalProject.Models
{
    public class SpeechWrapper
    {
        public int id { get; set; }

        public int owner { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string time { get; set; }

        public string nickname { get; set; }

        public string avatar { get; set; }

        public SpeechWrapper(Speech speech)
        {
            id = speech.id;
            owner = speech.owner;
            title = speech.title;
            content = speech.content;
            time = speech.time.GetValueOrDefault().ToString("g");
            using(var db = new DBModel())
            {
                var user = db.users.SingleOrDefault(x => x.id == speech.owner);
                nickname = user.nickname;
                avatar = user.avatar;
            }
        }

        public SpeechWrapper()
        {

        }

        public static List<SpeechWrapper> WrapSpeech(List<Speech> list)
        {
            List<SpeechWrapper> wrappers = new List<SpeechWrapper>();
            foreach(var item in list)
            {
                var wrapper = new SpeechWrapper(item);
                wrappers.Add(wrapper);
            }

            return wrappers;
        }

    }
}