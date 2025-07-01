using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace NEA_v1
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            mySQL.ViewTableOfTeacher("","");
            Console.ReadKey();

        }
    }
}
