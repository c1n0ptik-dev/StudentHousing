using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouses
{
    internal class Announcements
    {
        DateTime date;
        string contents;
        Studentcs student;

        public Announcements(DateTime dateA, Studentcs student, string studentInfo)
        {
            this.date = dateA; 
        }
    }
}
