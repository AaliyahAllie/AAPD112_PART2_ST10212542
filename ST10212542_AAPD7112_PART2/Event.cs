using System;

namespace ST10212542_AAPD7112_PART_2
{
    // Event class representing a municipal local event or public announcement
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public Event(int id, string title, string category, DateTime date, string location, string description)
        {
            EventId = id;
            Title = title;
            Category = category;
            EventDate = date;
            Location = location;
            Description = description;
        }

        public override string ToString()
        {
            return "[" + Category + "] " + Title + " - " + EventDate.ToString("yyyy-MM-dd") + " (" + Location + ")";
        }
    }
}
