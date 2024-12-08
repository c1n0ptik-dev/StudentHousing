using System;
using System.Data.SQLite;
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
    }
}
