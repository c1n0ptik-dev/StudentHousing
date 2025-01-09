using Newtonsoft.Json.Linq;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Net.PeerToPeer.Collaboration;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace StudentHouses
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=../../Database/Database.db;Version=3;";

        public bool VerifyUser(string username, string password)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT 1 FROM Users WHERE Username = @username AND Password = @password";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        object result = cmd.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            return false;
        }

        public bool VerifyAdmin(string username, string password)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT 1 FROM Users WHERE Username = @username AND Password = @password AND IsAdmin = 1";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        object result = cmd.ExecuteScalar();
                        return result != null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return false;
        }

        public void IncertRecord(string username, string password, string fullName, int roomNumber, string studentEmail, bool isAdmin)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO Users (Username, Password, Name, RoomNumber, StudentEmail, IsAdmin)
                VALUES (@username, @password, @fullName, @roomNumber, @studentEmail, @isAdmin)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username.Trim());
                        cmd.Parameters.AddWithValue("@password", password.Trim());
                        cmd.Parameters.AddWithValue("@fullName", fullName.Trim());
                        cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                        cmd.Parameters.AddWithValue("@studentEmail", studentEmail.Trim());
                        cmd.Parameters.AddWithValue("@isAdmin", isAdmin);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public int GetStudetnID(string username, string password)
        {
            int FoundID = 0;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StudentId FROM Users WHERE Username = @username AND Password = @password";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn)) 
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            FoundID = id;
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return FoundID;
        }

        public (int StudentId, string Name, int RoomNumber, string StudentEmail, bool BannedForComplaints)? GetStudentData(int studentId)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT StudentId, Name, RoomNumber, StudentEmail, BannedForComplaints " +
                                   "FROM Users WHERE StudentId = @studentId";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                int roomNumber = reader.GetInt32(2);
                                string email = reader.IsDBNull(3) ? null : reader.GetString(3); // Handle NULL emails
                                bool banned = reader.GetBoolean(4);

                                return (id, name, roomNumber, email, banned);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching student data: {ex.Message}");
            }

            return null;
        }

        public void AddComplaint(string creatorName, int creatorId, string complain, bool isanonymous)
        {
            try{
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    string query = "INSERT INTO Complaints (CreatorName, CreatorID, ComplaintText) VALUES (@creatorname, @creatorid, @complainttext)";

                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@creatorname", creatorName);
                        cmd.Parameters.AddWithValue("@creatorid", creatorId);
                        cmd.Parameters.AddWithValue("@complainttext", complain);

                        cmd.ExecuteNonQuery();
                    }
                }
                if (isanonymous)
                {
                    MessageBox.Show("Anonymous complaint is submited");
                }
                else
                {
                    MessageBox.Show("Complaint is submited");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while adding a complaint: {ex.Message}");
            }
        }

        public List<Complaints> GetAllComplaints()
        {
            List<Complaints> complaintsList = new List<Complaints>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ComplaintID, CreatorName, CreatorID, ComplaintText FROM Complaints";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Studentcs student = new Studentcs(reader.GetString(1));
                                Complaints complaint = new Complaints(
                                    reader.GetInt32(0),  
                                    student,             
                                    reader.GetInt32(2), 
                                    reader.GetString(3)  
                                );

                                complaintsList.Add(complaint);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching complaints: {ex.Message}", "Error");
            }

            return complaintsList;
        }

        public void DeleteComplaint(int complaintID)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Complaints WHERE ComplaintID = @complaintid";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // Ensure the parameter is added correctly
                        cmd.Parameters.AddWithValue("@complaintid", complaintID);

                        // Check the number of rows affected to confirm deletion
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No complaint found with the specified ID.", "Info");
                        }
                        else
                        {
                            MessageBox.Show($"Complaint with ID {complaintID} has been deleted.", "Success");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while deleting complaint: {ex.Message}", "Error");
            }
        }

        public void AddEvent(string title, string date, int roomUsed, string organizer, string description)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    string query = "INSERT INTO Calendar (Title, Time, RoomUsed, Organizer, Description) VALUES (@title, @time, @room, @org, @description)";

                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@time", date);
                        cmd.Parameters.AddWithValue("@room", roomUsed);
                        cmd.Parameters.AddWithValue("@org", organizer);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Complaint is succesfully added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while adding a complaint: {ex.Message}");
            }
        }

        public List<Events> GetEventsForDate(DateTime date)
        {
            List<Events> eventsList = new List<Events>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Title, Time, RoomUsed, Organizer, Description FROM Calendar WHERE Time = @date";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string time = reader.GetString(1);
                                string eventTitle = reader.GetString(0);
                                int roomUsed = reader.GetInt32(2); 
                                string organizer = reader.GetString(3);
                                string eventDescription = reader.GetString(4);

                                Studentcs student = new Studentcs(organizer);

                                Events events = new Events(eventTitle, time, roomUsed, student, eventDescription);
                                eventsList.Add(events);
                            }   
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching events: {ex.Message}", "Error");
            }

            return eventsList;
        }


        public DataTable GetBannedUsers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT Name, Username, StudentEmail FROM Users WHERE BannedForComplaints = 1";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        
        public void UnbanUser(string username)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var query = "UPDATE Users SET BannedForComplaints = 0 WHERE Username = @Username";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BanUser(int creatorID)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET BannedForComplaints = 1 WHERE StudentId = @StudentId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentId", creatorID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("User banned successfully.", "Ban info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while banning user: {ex.Message}");
            }       
        }

        public List<string> GetAllUserNames()
        {
            List<string> AvailableNames = new List<string>(); 

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Name FROM Users WHERE IsAdmin = 0";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AvailableNames.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while fecthing users: {ex.Message}");
            }

            return AvailableNames;
        }

        public int GetStudentIdByName(string name)
        {
           using (SQLiteConnection conn = new SQLiteConnection(connectionString))
           {
              conn.Open();
              string query = "SELECT StudentId FROM Users WHERE Name = @Name";
              using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
              {
                 cmd.Parameters.AddWithValue("@Name", name);
                 var result = cmd.ExecuteScalar();
                 return result != null ? Convert.ToInt32(result) : -1;
               }
           }
        }


        public void AddChore(int creatorID, string creatorName, string choreTitle, string choreBody, int responsibleID)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Chores (CreatorID, CreatorName, ChoreTitle, ChoreBody, ResponsibleID) VALUES (@CreatorID, @CreatorName, @ChoreTitle, @ChoreBody, @ResponsibleID)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CreatorID", creatorID);
                        cmd.Parameters.AddWithValue("@CreatorName", creatorName);
                        cmd.Parameters.AddWithValue("@ChoreTitle", choreTitle);
                        cmd.Parameters.AddWithValue("@ChoreBody", choreBody);
                        cmd.Parameters.AddWithValue("@ResponsibleID", responsibleID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error while adding a chore: {ex.Message}");
            }
        }

        public Chores[] GetChoresByUserID(int activeUserID)
        {
            var choresList = new List<Chores>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ChoreID, CreatorID, CreatorName, ChoreTitle, ChoreBody, ResponsibleID " +
                               "FROM Chores WHERE ResponsibleID = @ActiveUserID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ActiveUserID", activeUserID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var chore = new Chores(
                                choreID: reader.GetInt32(0),
                                creatorID: reader.GetInt32(1),
                                creatorName: reader.GetString(2),
                                choreTitle: reader.GetString(3),
                                choreBody: reader.GetString(4),
                                responsibleID: reader.GetInt32(5)
                            );

                            choresList.Add(chore);
                        }
                    }
                }
            }

            return choresList.ToArray();
        }

        public void DeleteChore(int ChoreID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Chores WHERE ChoreID = @ChoreID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ChoreID", ChoreID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetLastInsertedChoreId()
        {
            int lastInsertedId = 0;

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT last_insert_rowid();";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        lastInsertedId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while getting the last inserted ID: {ex.Message}");
            }

            return lastInsertedId;
        }

    }
}
