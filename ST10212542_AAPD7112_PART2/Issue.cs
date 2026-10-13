using System;

namespace ST10212542_AAPD7112_PART_2
{
    // Simple Issue class to store reported issue details for Part 1
    public class Issue
    {
        public string ReferenceNumber { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime DateSubmitted { get; set; }

        public Issue(string refNum, string location, string category, string description, string attachment)
        {
            ReferenceNumber = refNum;
            Location = location;
            Category = category;
            Description = description;
            AttachmentPath = attachment;
            DateSubmitted = DateTime.Now;
        }

        public string GetAttachmentFileName()
        {
            if (string.IsNullOrEmpty(AttachmentPath))
            {
                return "None";
            }
            return System.IO.Path.GetFileName(AttachmentPath);
        }
    }
}
