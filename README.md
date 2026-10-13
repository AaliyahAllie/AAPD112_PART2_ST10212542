# South African Municipal Services Application — Part 2 POE

## 1. Project Name
**Municipal Services Application — Part 2: Local Events & Announcements System**  
*AAPD7112 / Programming 3B Portfolio of Evidence (POE)*

---

## 2. Project Purpose
The purpose of this project is to provide citizens with a user-friendly desktop application to interact with municipal services.

For Part 2, the application includes:
1. **Report Issues (Part 1 - Enabled)**: Allows citizens to report issues (location, category, description, attachment) with estimated resolution turnaround times and reference number generation (`MS-0001`).
2. **Local Events and Announcements (Part 2 - Enabled)**: Allows citizens to view, search, and filter municipal events and public notices, and receive personalized event recommendations based on their search history.
3. **Service Request Status (Part 3 - Disabled)**: Reserved for Part 3 implementation.

---

## 3. Technologies Used
- **Language**: C#
- **Framework**: .NET Framework 4.8 (`net48`)
- **UI Platform**: Windows Forms Application
- **Data Structures**:
  - `List<Issue>` (Part 1 store)
  - `SortedDictionary<DateTime, List<Event>>` (Part 2 chronological event store)
  - `Dictionary<string, List<Event>>` (Part 2 O(1) category lookup index)
  - `Dictionary<string, int>` & `HashSet<string>` (Part 2 search preference tracker & history)

---

## 4. Prerequisites
- Windows 10 or Windows 11
- .NET Framework 4.8 Runtime
- Visual Studio 2022

---

## 5. How to Obtain and Open the Project

### Option A: Clone from GitHub Repository
1. Open Terminal, Command Prompt, or Git Bash.
2. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/AAPD7112_PART_2.git
   ```
3. Navigate into the directory:
   ```bash
   cd AAPD7112_PART_2
   ```

### Option B: Open in Visual Studio 2022
1. Launch **Visual Studio 2022**.
2. Click **Open a project or solution**.
3. Browse to: `C:\Users\Aaliyah\.gemini\antigravity\scratch\AAPD7112_PART 2`
4. Select `AAPD7112_PART 2.csproj` and click **Open**.

---

## 6. How to Compile / Build
In Visual Studio:
- Select **Build > Build Solution** (or press `Ctrl + Shift + B`).

Via Command Line:
```powershell
dotnet build "AAPD7112_PART 2.csproj" -c Release
```

---

## 7. How to Run the Application
Run the compiled executable located at:
`C:\Users\Aaliyah\.gemini\antigravity\scratch\AAPD7112_PART 2\bin\Release\AAPD7112_PART 2.exe`

---

## 8. How to Use the Main Menu
- **Option 1: Report Issues (Enabled)**: Opens the Part 1 issue reporting form.
- **Option 2: Local Events and Announcements (Enabled)**: Opens the Part 2 local events and announcements form.
- **Option 3: Service Request Status (Disabled)**: Placeholder for Part 3.

---

## 9. How to Use Local Events & Announcements (Part 2)
1. Click **2. Local Events and Announcements** on the Main Menu.
2. **View Events (Resident Mode)**: All upcoming events and public notices display automatically in the main table. Residents can browse safely without any login hurdle.
3. **Search by Keyword**: Type a word (e.g., *"Maintenance"*, *"Water"*, *"Clinic"*) in the search box and click **Search**.
4. **Filter by Category**: Select a category (*Water Notices, Power Maintenance, Community Meetings, Health & Safety, Sports & Youth*) from the dropdown menu.
5. **Filter by Date**: Check the **Filter by Date** checkbox and pick a date.
6. **View Event Full Details**:
   - **Method 1**: Double-click any event row in the table.
   - **Method 2**: Click on an event in the table and click the **"View Event Details"** button.
   - **Method 3**: Double-click any item in the **Recommended Events** list.
   - A dedicated **Official Municipal Notice** window opens displaying the event's full title, category, formatted date, location, and the full multi-line description notice.
7. **View Recommendations**: The **Recommendation Engine** dynamically updates the recommended events list based on your most frequently searched category.
8. **Municipal Admin Portal (Posting Announcements)**:
   - To prevent residents from posting fake announcements, click the **"Admin Portal: Post Event"** button.
   - Enter administrator credentials (Demo: `admin` / `admin123`).
   - Fill in Title, Category, Date, Location, and Description.
   - Upon submission, the event is dynamically inserted into the `SortedDictionary` and `Dictionary`, updating the grid and recommendations in real time.
   - Click `[Log Out]` to return to resident mode.

---

## 10. Data Structures Explained

### Primary Event Store (`SortedDictionary<DateTime, List<Event>>`)
- Events are indexed by date using a `SortedDictionary`. This ensures that all events are automatically sorted chronologically.

### Category Lookup Index (`Dictionary<string, List<Event>>`)
- Events are grouped by category inside a `Dictionary`. This provides O(1) instant retrieval when a citizen filters by category.

### Recommendation Engine & Search Preference Tracker (`Dictionary<string, int>` & `HashSet<string>`)
- The app records search keywords in a `HashSet` and tracks search frequencies per category using a `Dictionary`.
- The recommendation algorithm identifies the user's most searched category and populates personalized event recommendations.

---

## 11. Rubric Compliance Checklist

| Requirement | Implemented? | Source Code File |
| :--- | :---: | :--- |
| **Main Menu Startup** | Yes | `Forms/MainMenuForm.cs` |
| **Report Issues (Part 1 Enabled)** | Yes | `Forms/ReportIssuesForm.cs` |
| **Local Events (Part 2 Enabled)** | Yes | `Forms/LocalEventsForm.cs` |
| **Service Status (Part 3 Disabled)** | Yes | `Forms/MainMenuForm.Designer.cs` |
| **Event Model** | Yes | `Event.cs` |
| **Data Structures (SortedDictionary & Dictionary)** | Yes | `Program.cs` |
| **Search Functionality** | Yes | `Forms/LocalEventsForm.cs` |
| **Category & Date Filtering** | Yes | `Forms/LocalEventsForm.cs` |
| **Recommendation Engine** | Yes | `Forms/LocalEventsForm.cs` |
| **Event Detailed View (Full Notice Modal)** | Yes | `Forms/EventDetailsForm.cs` |
| **Admin Authentication (Anti-Spam)** | Yes | `Forms/AdminLoginForm.cs`, `Forms/AddEventForm.cs` |
| **Dynamic Event Creation** | Yes | `Forms/AddEventForm.cs` |
| **README Documentation** | Yes | `README.md` |
