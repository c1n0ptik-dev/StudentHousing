﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouses
{
        [DataContract]
        public class Studentcs
        {
        [DataMember]
        string name;
        [DataMember]
        int roomNumber;
        [DataMember]
        int studentId;
        [DataMember]
        string studentEmail;
        [DataMember]
        bool bannedForComplaints = false;
        [DataMember]
        List<Announcements> studentAnnouncements = new List<Announcements>();

        public Studentcs(string nameS, int roomN, int studentID, string email, bool ComplaintsBan)
        {
            this.name = nameS;
            this.roomNumber = roomN;
            this.studentId = studentID;
            this.studentEmail = email; 
            this.bannedForComplaints = ComplaintsBan;
        }


        public void ChangeBan(bool changes)
        {
            this.bannedForComplaints = changes;
        }

        public bool Banned()
        {
            return bannedForComplaints;
        }

        public string GetStudent()
        {
            return $"{this.name}";
        }

        public int GetStudentId()
        {
            return studentId;
        }
    }

    
}
