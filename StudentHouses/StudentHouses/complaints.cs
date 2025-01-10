using System;
using System.Runtime.Serialization;

namespace StudentHouses
{
    [DataContract]
    public class Complaints
    {
        [DataMember]
        public int ComplaintID { get; set; } 
        [DataMember]
        public Studentcs student { get; set; }
        [DataMember]
        public int CreatorID { get; set; } 
        [DataMember]
        public string ComplaintText { get; set; } 

        public Complaints(int complaintID, Studentcs students, int studentid, string complaintText)
        {
            ComplaintID = complaintID;
            student = students;
            CreatorID = studentid;
            ComplaintText = complaintText;
        }

        public string GetComplain()
        {
            return ComplaintText;
        }

        public int GetCreatorId()
        {
            return CreatorID;
        }

        public int GetComplaintID()
        {
            return ComplaintID;
        }
    }
}
