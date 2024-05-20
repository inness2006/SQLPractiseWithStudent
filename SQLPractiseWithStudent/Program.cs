using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Azure.Core.HttpHeader;

namespace SQLPractiseWithStudent
{
    internal class Program
    {
        static void Main()
        {

            const string ConnectionString = "Data Source=LAPTOP-Q4CV9BN2;Initial Catalog=Student Option;Integrated Security=True;TrustServerCertificate=True";
            Console.WriteLine(ConnectionString);

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                //menu start
                Console.WriteLine("1) Get Student Names");
                Console.WriteLine("2) Display students enrolled in a set");
                Console.WriteLine("3) Insert student");
                //menu end 

                string Choice = Console.ReadLine();
                int IntChoice = Int32.Parse(Choice);

                if (IntChoice == 1)
                {
                    command.CommandText = "Select * from student";
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var name = dataReader.GetString(1);
                        Console.WriteLine(name);
                    }
                }

                else if (IntChoice == 2)
                {
                    Console.WriteLine("Enter what set number you would like");

                    
                    string Choice2 = Console.ReadLine();
                    int IntChoice2 = Int32.Parse(Choice2);

                    command.CommandText = $"select e.student_id, first_name, last_name\r\nfrom Student \r\ninner join Enrollment e on e.student_id = e.student_id\r\nwhere e.set_id = {IntChoice2};";
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var name = dataReader.GetString(1);
                        Console.WriteLine(name);
                    }
                }

                else if (IntChoice == 3)
                {
                    Console.WriteLine("Enter ID of Student, FirstName, LastName and DOB");


                    string student_id = Console.ReadLine();
                    string New_Student_First_Name = Console.ReadLine();
                    string New_Student_Last_Name = Console.ReadLine();
                    string Date_of_Birth = Console.ReadLine();



                    command.CommandText = $"INSERT INTO Student (StudentID, FirstName, LastName, DateOfBirth)\r\nVALUES ({student_id}, '{New_Student_First_Name}', '{New_Student_Last_Name}', '{Date_of_Birth}');";
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var name = dataReader.GetString(1);
                        Console.WriteLine(name);
                    }
                }
            }
           
        }
    }
}
