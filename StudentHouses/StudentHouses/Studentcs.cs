using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouses
{
    internal class Studentcs
    {
        string name;
        int roomNumber;
        int studentId;
        string studentEmail;
        List<Announcements> studentAnnouncements = new List<Announcements>();

        public Studentcs(string nameS, int roomN, int studentID, string email)
        {
            this.name = nameS;
            this.roomNumber = roomN;
            this.studentId = studentID;
            this.studentEmail = email;
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
