using System;

namespace ST10212542_AAPD7112_PART_2
{
    /// <summary>
    /// Represents an issue reported by a citizen for Part 1.
    /// Stores the unique tracking reference number, location, issue category,
    /// detailed description, optional file attachment path, and the submission timestamp.
    /// </summary>
    public class Issue
    {
        // Unique tracking reference number (e.g., MS-0001)
        public string ReferenceNumber { get; set; }

        // Specific street address, suburb, or physical location of the problem
        public string Location { get; set; }

        // Category of the issue (e.g., Roads and Potholes, Water and Utilities, Electricity)
        public string Category { get; set; }

        // Detailed description of the problem provided by the citizen
        public string Description { get; set; }

        // Full file system path to the attached photo or supporting document (optional)
        public string AttachmentPath { get; set; }

        // Timestamp recording exactly when the citizen submitted the report
        public DateTime DateSubmitted { get; set; }

        /// <summary>
        /// Constructor to initialize a new Issue report with citizen input data.
        /// </summary>
        /// <param name="refNum">Auto-generated reference number</param>
        /// <param name="location">Location of the issue</param>
        /// <param name="category">Selected category</param>
        /// <param name="description">Description of the problem</param>
        /// <param name="attachment">File path of the attached document or image</param>
        public Issue(string refNum, string location, string category, string description, string attachment)
        {
            ReferenceNumber = refNum;
            Location = location;
            Category = category;
            Description = description;
            AttachmentPath = attachment;
            // Record current date and time of submission
            DateSubmitted = DateTime.Now;
        }

        /// <summary>
        /// Extracts and returns just the file name of the attachment for display purposes.
        /// Returns "None" if no attachment was provided.
        /// </summary>
        /// <returns>File name or "None"</returns>
        public string GetAttachmentFileName()
        {
            if (string.IsNullOrEmpty(AttachmentPath))
            {
                return "None";
            }
            // Return only the file name (e.g., pothole.jpg) instead of the full path
            return System.IO.Path.GetFileName(AttachmentPath);
        }
    }
}
