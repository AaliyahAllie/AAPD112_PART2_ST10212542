using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ST10212542_AAPD7112_PART_2.Forms;

namespace ST10212542_AAPD7112_PART_2
{
    static class Program
    {
        // Part 1: Global List<Issue> for storing issue reports
        public static List<Issue> IssueList = new List<Issue>();
        public static int IssueCounter = 1;

        // Part 2 Data Structures:
        // 1. SortedDictionary<DateTime, List<Event>> - Chronologically sorted events by date
        public static SortedDictionary<DateTime, List<Event>> EventSortedByDate = new SortedDictionary<DateTime, List<Event>>();

        // 2. Dictionary<string, List<Event>> - Fast O(1) category lookup index
        public static Dictionary<string, List<Event>> EventByCategory = new Dictionary<string, List<Event>>(StringComparer.OrdinalIgnoreCase);

        // 3. User Search Preference Tracker (Dictionary<string, int> & HashSet<string>)
        public static Dictionary<string, int> CategorySearchCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        public static HashSet<string> UserSearchHistory = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Municipal Admin authentication state (prevents false event creation by residents)
        public static bool IsAdminLoggedIn = false;

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Populate sample municipal events & initialize data structures
            InitializeSampleEvents();

            Application.Run(new MainMenuForm());
        }

        /// <summary>
        /// Helper method to add an event into all data structures (SortedDictionary & Dictionary)
        /// </summary>
        public static void AddEventToDataStructures(Event ev)
        {
            // 1. Add to SortedDictionary by Date (truncating time to Date only for clean sorting)
            DateTime dateKey = ev.EventDate.Date;
            if (!EventSortedByDate.ContainsKey(dateKey))
            {
                EventSortedByDate[dateKey] = new List<Event>();
            }
            EventSortedByDate[dateKey].Add(ev);

            // 2. Add to Dictionary by Category
            if (!EventByCategory.ContainsKey(ev.Category))
            {
                EventByCategory[ev.Category] = new List<Event>();
            }
            EventByCategory[ev.Category].Add(ev);
        }

        /// <summary>
        /// Pre-populates realistic South African municipal events & public announcements
        /// </summary>
        private static void InitializeSampleEvents()
        {
            DateTime today = DateTime.Today;

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

            foreach (var ev in sampleEvents)
            {
                AddEventToDataStructures(ev);
            }

            // Initialize category search counts
            string[] categories = { "Water Notices", "Power Maintenance", "Community Meetings", "Health & Safety", "Sports & Youth" };
            foreach (var cat in categories)
            {
                CategorySearchCount[cat] = 0;
            }
        }
    }
}
