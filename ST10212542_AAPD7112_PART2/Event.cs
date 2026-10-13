using System;

namespace ST10212542_AAPD7112_PART_2
{
    /// <summary>
    /// Event class representing a municipal event or public announcement for Part 2.
    /// Stores the unique identifier, announcement title, municipal category,
    /// scheduled date, physical venue/affected area, and full detailed message.
    /// </summary>
    public class Event
    {
        // Unique identifier for the event
        public int EventId { get; set; }

        // Short descriptive title of the event or public announcement
        public string Title { get; set; }

        // Category (e.g., Water Notices, Power Maintenance, Community Meetings, Health & Safety, Sports & Youth)
        public string Category { get; set; }

        // Date when the event or scheduled maintenance occurs
        public DateTime EventDate { get; set; }

        // Physical location, venue, or suburb affected
        public string Location { get; set; }

        // Full comprehensive notice or description provided by the municipality
        public string Description { get; set; }

        /// <summary>
        /// Constructor to initialize an Event object with all necessary announcement details.
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <param name="title">Announcement title</param>
        /// <param name="category">Category name</param>
        /// <param name="date">Event scheduled date</param>
        /// <param name="location">Venue or affected area</param>
        /// <param name="description">Complete detailed description</param>
        public Event(int id, string title, string category, DateTime date, string location, string description)
        {
            EventId = id;
            Title = title;
            Category = category;
            EventDate = date;
            Location = location;
            Description = description;
        }

        /// <summary>
        /// Returns a formatted summary string of the event for display in lists and tooltips.
        /// </summary>
        /// <returns>Formatted event summary string</returns>
        public override string ToString()
        {
            return "[" + Category + "] " + Title + " - " + EventDate.ToString("yyyy-MM-dd") + " (" + Location + ")";
        }
    }
}
