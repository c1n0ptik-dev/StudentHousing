using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.SQLite;
using System.Drawing;
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
                                Complaints complaint = new Complaints(
                                    reader.GetInt32(0),  
                                    reader.GetString(1), 
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


        public void BanUser(int creatorID)
        {

        }
    }
}
