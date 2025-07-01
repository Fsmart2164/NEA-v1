using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace NEA_v1
{
    public class mySQL
    {
        static SQLiteConnection conn = CreateConnection();
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // Open the connection:
            sqlite_conn.Open();
            return sqlite_conn;
        }
        static public void ViewTableOfTeacher(string firstname, string lastname)
        {
            string Query = "SELECT DayOfTheWeek,PeriodNumber,Location FROM Timetable,Teachers WHERE Teachers.ID = TeacherID AND Teachers.Forename='" + firstname + "' AND teachers.Lastname'" + lastname + "')";
            SQLiteCommand cmd = new SQLiteCommand(Query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();             // reader is storing the command we now need to ouput it - if we not ouputting anythign we cna stop now
            List<List<string>> teachersfnln = new List<List<string>>();
            while (reader.Read())
            {
                List<string> row = new List<string>();
                row.Add(reader["DayOfWeek"].ToString());
                row.Add(reader["PeriodNumber"].ToString());
                row.Add(reader["Location"].ToString());
                teachersfnln.Add(row);
            }
            Console.WriteLine("timetable for " + firstname + " " + lastname + " is:");
            foreach (List<string> row in teachersfnln)
            {
                Console.WriteLine(row[0] + row[1] + row[2]);
            }
        }
    }
}
