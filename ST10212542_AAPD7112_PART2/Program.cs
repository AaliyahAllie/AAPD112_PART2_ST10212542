
using ST10212542_AAPD7112_PART_2;
using ST10212542_AAPD7112_PART_2.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ST10212542_AAPD7112_PART_2
{
    /// <summary>
    /// Application entry point and central in-memory data store.
    /// Manages the collections for reported issues (Part 1) and local municipal events (Part 2),
    /// including advanced data structures: SortedDictionary, Dictionary, and HashSet.
    /// </summary>
    static class Program
    {
        // =========================================================================
        // PART 1 DATA STRUCTURES:
        // =========================================================================

        // In-memory list storing all issues submitted by citizens in Part 1
        public static List<Issue> IssueList = new List<Issue>();

        // Running counter used to generate sequential reference IDs (MS-0001, MS-0002, etc.)
        public static int IssueCounter = 1;

        // =========================================================================
        // PART 2 ADVANCED DATA STRUCTURES:
        // =========================================================================

        // 1. SortedDictionary<DateTime, List<Event>>
        // Chronological event store sorted automatically by Date keys.
        // Uses a red-black binary search tree internally to maintain keys in sorted order.
        public static SortedDictionary<DateTime, List<Event>> EventSortedByDate = new SortedDictionary<DateTime, List<Event>>();

        // 2. Dictionary<string, List<Event>>
        // Secondary index keyed by Category string.
        // Provides O(1) average constant-time lookup when a citizen filters by a specific category.
        public static Dictionary<string, List<Event>> EventByCategory = new Dictionary<string, List<Event>>(StringComparer.OrdinalIgnoreCase);

        // 3. User Search Preference Tracker for Recommendation Engine:
        // - CategorySearchCount: Counts how many times the user searched or filtered each category.
        // - UserSearchHistory: Set storing unique search keywords queried during this session.
        public static Dictionary<string, int> CategorySearchCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        public static HashSet<string> UserSearchHistory = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // 4. Municipal Administrator Authentication State
        // Tracks whether an authorized municipal official is currently logged in.
        // Protects the announcements feed by ensuring only staff can publish verified notices.
        public static bool IsAdminLoggedIn = false;

        /// <summary>
        /// Main application entry point method.
        /// Configures visual styles, populates sample data, and opens the main menu.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable standard Windows XP/Vista/7/10/11 visual styles for controls
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Populate sample municipal events into both data structures at startup
            InitializeSampleEvents();

            // Launch the main menu form directly (satisfying startup criteria without mandatory login)
            Application.Run(new MainMenuForm());
        }

        /// <summary>
        /// Adds a single Event object into both primary data structures:
        /// 1) SortedDictionary (indexed by date)
        /// 2) Dictionary (indexed by category)
        /// This keeps both data stores synchronized.
        /// </summary>
        /// <param name="ev">The Event object to insert</param>
        public static void AddEventToDataStructures(Event ev)
        {
            // --- 1. Insert into SortedDictionary<DateTime, List<Event>> ---
            // Truncate the time component to ensure all events on the same calendar day share the same key
            DateTime dateKey = ev.EventDate.Date;
            if (!EventSortedByDate.ContainsKey(dateKey))
            {
                EventSortedByDate[dateKey] = new List<Event>();
            }
            EventSortedByDate[dateKey].Add(ev);

            // --- 2. Insert into Dictionary<string, List<Event>> ---
            // Group under category key for instant O(1) filtering
            if (!EventByCategory.ContainsKey(ev.Category))
            {
                EventByCategory[ev.Category] = new List<Event>();
            }
            EventByCategory[ev.Category].Add(ev);
        }

        /// <summary>
        /// Pre-populates realistic South African municipal events and announcements.
        /// Demonstrates chronological ordering, category indexing, and search capabilities.
        /// </summary>
        private static void InitializeSampleEvents()
        {
            DateTime today = DateTime.Today;

            // Sample data reflecting realistic South African municipal operations
            List<Event> sampleEvents = new List<Event>
            {
                new Event(1, "Johannesburg Water Planned Maintenance", "Water Notices", today.AddDays(2),
                    "Sandton & Randburg", "Planned water supply shutdown for pipe replacement and maintenance from 08:00 to 18:00."),

                new Event(2, "City Power Substation Maintenance", "Power Maintenance", today.AddDays(3),
                    "Roodepoort Substation", "Emergency maintenance on 11kV transformer circuit breakers. Expect temporary outages."),

                new Event(3, "Ward 12 Community Budget Forum", "Community Meetings", today.AddDays(5),
                    "Braamfontein Civic Centre", "Public participation forum on municipal budget allocation and infrastructure projects."),

                new Event(4, "Ekurhuleni Reservoir Infrastructure Upgrade", "Water Notices", today.AddDays(7),
                    "Germiston Reservoir", "Major pipeline upgrade to improve water pressure in high-lying areas."),

                new Event(5, "Free Clinic Immunization & Health Day", "Health & Safety", today.AddDays(4),
                    "Soweto Community Clinic", "Free polio and measles vaccinations, wellness checks, and health screenings for residents."),

                new Event(6, "Annual Municipal Youth Soccer Tournament", "Sports & Youth", today.AddDays(10),
                    "Joburg Stadium Fields", "Community youth soccer championship featuring local under-17 municipal teams."),

                new Event(7, "Municipal Fire Safety & Awareness Workshop", "Health & Safety", today.AddDays(6),
                    "Midrand Fire Station", "Workshop on home fire prevention, smoke alarms, and emergency evacuation plans."),

                new Event(8, "City Planning & Zoning Townhall", "Community Meetings", today.AddDays(8),
                    "Pretoria City Hall", "Public hearing regarding proposed residential zoning amendments and urban greening."),

                new Event(9, "Eskom Planned Maintenance Outage", "Power Maintenance", today.AddDays(1),
                    "Centurion Industrial Park", "Scheduled maintenance on high-voltage lines. Power will be restored by 16:00."),

                new Event(10, "Parks & Recreation Athletics Track Day", "Sports & Youth", today.AddDays(12),
                    "Tshwane Sports Complex", "Open track and field sports day for all local community schools and athletic clubs.")
            };

            // Add each sample event to the primary data structures
            foreach (var ev in sampleEvents)
            {
                AddEventToDataStructures(ev);
            }

            // Initialize all category search counters to 0
            string[] categories = { "Water Notices", "Power Maintenance", "Community Meetings", "Health & Safety", "Sports & Youth" };
            foreach (var cat in categories)
            {
                CategorySearchCount[cat] = 0;
            }
        }
    }
}
