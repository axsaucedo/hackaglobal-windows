using System.Collections.Generic;

namespace HackaGlobal
{
    public class Event
    {
        public int eventid { get; set; }
        public string city { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string start { get; set; }
        public string address { get; set; }
        public string organizer { get; set; }
    }

    public class LoadedEvents
    {
        public List<Event> events { get; set; }
        public List<string> ToStringList()
        {
            var list = new List<string>();
            events.ForEach(e => list.Add(e.title));
            return list;
        }
    }
}