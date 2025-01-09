using System;
using System.Runtime.Serialization;

namespace StudentHouses
{
    [DataContract]
    public class Chores
    {
        [DataMember]
        public int ChoreID { get; set; }

        [DataMember]
        public int CreatorID { get; set; }

        [DataMember]
        public Studentcs studentName { get; set; }

        [DataMember]
        public string ChoreTitle { get; set; }

        [DataMember]
        public string ChoreBody { get; set; }

        [DataMember]
        public string ChoreText { get; set; }

        [DataMember]
        public string ChoreType { get; set; }

        [DataMember]
        public int ResponsibleID { get; set; }

        public Chores(int choreID, int creatorID, Studentcs student, string choreTitle, string choreBody, string choreText = "", string choreType = "", int responsibleID = 0)
        {
            ChoreID = choreID;
            CreatorID = creatorID;
            studentName = student;
            ChoreTitle = choreTitle;
            ChoreBody = choreBody;
            ChoreText = choreText; 
            ChoreType = choreType;
            ResponsibleID = responsibleID;
        }

        public string GetCreatorInfo()
        {
            return $"{studentName}";
        }

        public string GetChoreDetails()
        {
            return $"{ChoreTitle}: {ChoreBody}";
        }

        public string GetChoreTitle()
        {
            return $"{ChoreTitle}";
        }

        public string GetChoreBody()
        {
            return $"{ChoreBody}";
        }

        public int GetResponsibleID()
        {
            return ResponsibleID;
        }

        public int GetChoreID()
        {
            return ChoreID;
        }
    }
}
