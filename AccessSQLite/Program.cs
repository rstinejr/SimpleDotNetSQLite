using SQLite;
using System;

namespace waltonstine.demo.dotnet.sqlite
{
    class Program
    {
        public class Parent 
        {
            [PrimaryKey, AutoIncrement]
            public int    Parent_pk { get; set; }
            public string Name      { get; set; }
            public float  Pi        { get; set; }
            public byte[] Data      { get; set; }
        }


        static private int InsertParent(SQLiteConnection conn, string name, float pi, byte[] blob)
        {
            int insertCnt = conn.Insert(new Parent()
            {
                Name = name,
                Pi = pi,
                Data = blob
            });

            return insertCnt;
        }

        static public void Main(string[] args)
        {
            string dbPath =  (args.Length == 0) ? "../demo.db" : args[0];

            Console.WriteLine($"Open database {dbPath}");

            SQLiteConnection conn = new SQLiteConnection(dbPath);

            int cnt = InsertParent(conn, "george", 1.234F, null);

            conn.Close();

            Console.WriteLine($"Rows inserted: {cnt}");
        }
    }
}
