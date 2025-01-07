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
        private string organizer;
        private string description;


        public Events(string name, string date, int room, string org, string descriptioN)
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
            return new List<string> { title, time, roomUsed.ToString(), organizer, description };
        }
    }
}
