using System;
using System.Runtime.Serialization;

namespace StudentHouses
{
    [DataContract]
    public class Complaints
    {
        [DataMember]
        public int ComplaintID { get; set; } // Matches ComplaintID from the database
        [DataMember]
        public string CreatorName { get; set; } // Matches CreatorName from the database
        [DataMember]
        public int CreatorID { get; set; } // Matches CreatorID from the database
        [DataMember]
        public string ComplaintText { get; set; } // Matches ComplaintText from the database

        public Complaints(int complaintID, string creatorName, int creatorID, string complaintText)
        {
            ComplaintID = complaintID;
            CreatorName = creatorName;
            CreatorID = creatorID;
            ComplaintText = complaintText;
        }

        // Method to format name and ID for display
        public string GetNameNumber()
        {
            return $"{CreatorName} ({CreatorID})";
        }

        // Method to get the complaint text
        public string GetComplain()
        {
            return ComplaintText;
        }

        public int GetComplaintID()
        {
            return ComplaintID;
        }
    }
}
