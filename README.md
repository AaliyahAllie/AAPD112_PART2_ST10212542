# South African Municipal Services Application: Part 2 POE

## 1. Project Name

**Municipal Services Application: Part 2 — Local Events & Announcements System**

* AAPD7112 / Programming 3B Portfolio of Evidence (POE)

## 2. Project Purpose

The purpose of this project is to provide citizens with a user-friendly desktop application to interact with municipal services.

For Part 2, the application includes:

- **Report Issues (Part 1 — Enabled):** Allows citizens to report issues (location, category, description, attachment) with estimated resolution turnaround times and reference number generation (`MS-0001`).
- **Local Events and Announcements (Part 2 — Enabled):** Allows citizens to view, search, and filter municipal events and public notices, and receive personalized event recommendations based on their search history.
- **Service Request Status (Part 3 — Disabled):** Reserved for Part 3 implementation.

## 3. Technologies Used

- **Language:** C#
- **Framework:** .NET Framework 4.8 (`net48`)
- **UI Platform:** Windows Forms Application
- **Data Structures:**
  - `List<Issue>` — Part 1 issue store
  - `SortedDictionary<DateTime, List<Event>>` — Part 2 chronological event store
  - `Dictionary<string, List<Event>>` — Part 2 category lookup index
  - `Dictionary<string, int>` and `HashSet<string>` — Part 2 search preference tracker and history

## 4. Prerequisites

- Windows 10 or Windows 11
- .NET Framework 4.8 Runtime
- Visual Studio 2022 (with .NET desktop development tools)

## 5. How to Obtain and Open the Project

### Option A: Clone from GitHub Repository

1. Open Terminal, Command Prompt, or Git Bash.
2. Clone the repository (replace `<your-username>` with the correct GitHub username):

   ```bash
   git clone https://github.com/<your-username>/AAPD7112_PART_2.git
   ```

3. Navigate into the project directory:

   ```bash
   cd AAPD7112_PART_2
   ```

   The local solution/project folder may be named `ST10212542_AAPD7112_PART_2` instead; use the folder name that actually exists.

### Option B: Open in Visual Studio 2022

1. Launch Visual Studio 2022.
2. Select **Open a project or solution**.
3. Browse to:

   ```text
   C:\Users\Aaliyah\.gemini\antigravity\scratch\AAPD7112_PART 2\
   ```

4. Select `ST10212542_AAPD7112_PART 2.csproj` and click **Open**.

## 6. How to Compile / Build

### In Visual Studio

Select **Build > Build Solution**, or press `Ctrl + Shift + B`.

### Via Command Line

From the project directory, run:

```bash
dotnet build "ST10212542_AAPD7112_PART 2.csproj" -c Release
```

> **Note:** Building a .NET Framework 4.8 project requires the appropriate targeting/developer pack and compatible build tools. If `dotnet build` fails for this Windows Forms project, build it using Visual Studio 2022 or MSBuild from the Visual Studio Developer Command Prompt.

## 7. How to Use the Main Menu

- **Option 1 — Report Issues (Enabled):** Opens the Part 1 issue reporting form.
- **Option 2 — Local Events and Announcements (Enabled):** Opens the Part 2 local events and announcements form.
- **Option 3 — Service Request Status (Disabled):** Placeholder for Part 3.

## 8. How to Use Local Events & Announcements (Part 2)

1. **Open the events page:** Click **2. Local Events and Announcements** on the Main Menu.
2. **View events (Resident Mode):** All upcoming events and public notices display automatically in the main table. Residents can browse without logging in.
3. **Search by keyword:** Enter a term such as *Maintenance*, *Water*, or *Clinic* in the search box and click **Search**.
4. **Filter by category:** Choose *Water Notices*, *Power Maintenance*, *Community Meetings*, *Health & Safety*, or *Sports & Youth* from the dropdown menu.
5. **Filter by date:** Check **Filter by Date** and select a date.
6. **View full event details:**
   - Double-click an event row in the table; or
   - Select an event and click **View Event Details**; or
   - Double-click an item in the **Recommended Events** list.

   An **Official Municipal Notice** window opens, showing the event's title, category, formatted date, location, and full multi-line description.

7. **View recommendations:** The Recommendation Engine updates the recommended events list based on the user's most frequently searched category.
8. **Municipal Admin Portal — Post Announcements:**
   - Click **Admin Portal: Post Event** to access the posting interface, which helps prevent residents from posting fake announcements.
   - Enter the demo administrator credentials: `admin` / `admin123`.
   - Complete the **Title**, **Category**, **Date**, **Location**, and **Description** fields.
   - Submit the event. It is inserted into the `SortedDictionary` and category `Dictionary`, updating the grid and recommendations in real time.
   - Click **[Log Out]** to return to resident mode.

> **Security note:** The administrator credentials above are for demonstration purposes only and should not be used in a production application.

## 9. Data Structures Explained

### Primary Event Store — `SortedDictionary<DateTime, List<Event>>`

Events are indexed by date using a `SortedDictionary`. This keeps event dates automatically sorted in chronological order.

### Category Lookup Index — `Dictionary<string, List<Event>>`

Events are grouped by category inside a `Dictionary`. This supports average **O(1)** access to the selected category's list of events.

### Recommendation Engine & Search Preference Tracker — `Dictionary<string, int>` and `HashSet<string>`

The application stores unique search keywords in a `HashSet` and tracks category search frequencies in a `Dictionary`. The recommendation algorithm identifies the user's most frequently searched category and displays personalized event recommendations.
