using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouses
{
    public class Events
    {
        private string title;
        private string time;
        private int roomUsed;
        private Studentcs organizer;
        private string description;


        public Events(string name, string date, int room, Studentcs org, string descriptioN)
        {
            this.title = name;
            this.time = date;
            this.roomUsed = room;
            this.organizer = org;
            this.description = descriptioN;
        }

        public override string ToString()
        {
            return title;
        }

        public List<string> GetInfo()
        {
            return new List<string> { title, time, roomUsed.ToString(), organizer.ToString(), description };
        }
    }
}
