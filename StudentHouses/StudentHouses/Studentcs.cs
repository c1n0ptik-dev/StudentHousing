using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public Studentcs(string nameS, int roomN, int studentID, string email, bool ComplaintsBan)
        {
            this.name = nameS;
            this.roomNumber = roomN;
            this.studentId = studentID;
            this.studentEmail = email; 
            this.bannedForComplaints = ComplaintsBan;
        }


        public Studentcs(string nameSS)
        {
            this.name = nameSS;
        }

        public override string ToString()
        {
            return name;
        }

        public int GetRoomNumber()
        {
            return roomNumber;
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
