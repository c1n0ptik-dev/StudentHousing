using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouses
{
    [DataContract]
    public class Complaints
    {
        [DataMember]
        Studentcs student;
        [DataMember]
        string complain;
        [DataMember]
        int numberOfComplaints;

        public Complaints(Studentcs studentN, string complains)
        {
            this.student = studentN;
            this.complain = complains;
            numberOfComplaints += 1;
        }

        public string GetNameNumber() 
        {
            return $"{student.GetStudent()}({student.GetStudentId()})";
        }

        public string GetComplain()
        {
            return $"{complain}";
        }

        public int GetNumber()
        {
            return numberOfComplaints;
        }
    }
}
