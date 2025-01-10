﻿using System;
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

        public Complaints(int complaintID, Studentcs students, string complaintText)
        {
            ComplaintID = complaintID;
            student = students;
            CreatorID = student.GetStudentId();
            ComplaintText = complaintText;
        }

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
