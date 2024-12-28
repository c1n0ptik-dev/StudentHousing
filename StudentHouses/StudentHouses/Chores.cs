using System;
using System.Runtime.Serialization;

namespace StudentHouses
{
    [DataContract]
    public class Chores
    {
        [DataMember]
        public int ChoreID { get; set; } // Matches ChoreID from the database
        [DataMember]
        public int CreatorID { get; set; } // Matches CreatorID from the database
        [DataMember]
        public string CreatorName { get; set; } // Matches CreatorName from the database
        [DataMember]
        public string ChoreTitle { get; set; } // Matches ChoreTitle from the database
        [DataMember]
        public string ChoreBody { get; set; } // Matches ChoreBody from the database
        [DataMember]
        public int ResponsibleID { get; set; } // Matches ResponsibleID from the database

        public Chores(int choreID, int creatorID, string creatorName, string choreTitle, string choreBody, int responsibleID)
        {
            ChoreID = choreID;
            CreatorID = creatorID;
            CreatorName = creatorName;
            ChoreTitle = choreTitle;
            ChoreBody = choreBody;
            ResponsibleID = responsibleID;
        }

        // Method to format creator information for display
        public string GetCreatorInfo()
        {
            return $"{CreatorName}";
        }

        // Method to get the chore details
        public string GetChoreDetails()
        {
            return $"{ChoreTitle}: {ChoreBody}";
        }

        public string GetChoreTitle ()
        {
            return $"{ChoreTitle}";
        }

        public string GetChoreBody()
        {
            return $"{ChoreBody}";
        }

        // Method to retrieve the responsible person's ID
        public int GetResponsibleID()
        {
            return ResponsibleID;
        }

        // Method to retrieve the chore ID
        public int GetChoreID()
        {
            return ChoreID;
        }
    }
}
