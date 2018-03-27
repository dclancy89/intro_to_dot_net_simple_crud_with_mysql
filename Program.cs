using System;
using DbConnection;
using System.Collections.Generic;

namespace Simple_CRUD_with_MySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DisplayAllUsers();
            Console.WriteLine("\nGive me a first name:");
            string first_name = Console.ReadLine();
            Console.WriteLine("\nGive me a last name:");
            string last_name = Console.ReadLine();
            Console.WriteLine("\nGive me a favorite number:");
            int favorite_number = Convert.ToInt32(Console.ReadLine());

            createNewUser(first_name, last_name, favorite_number);


        }

        static public void DisplayAllUsers()
        {
            List<Dictionary<string, object>> query = DbConnector.Query("SELECT * FROM Users;");
            foreach(var entry in query)
            {
               foreach(var item in entry)
               {
                   Console.WriteLine(item.Key + " - " + item.Value);
               }
            }
        }

        static public void createNewUser(string fn, string ln, int num)
        {
            
            string query = $"INSERT INTO Users (FirstName, LastName, FavoriteNumber) VALUES('{fn}', '{ln}', '{num}');";
            //Console.WriteLine(query);
            DbConnector.Execute(query);
            DisplayAllUsers();
        }
    }
}
