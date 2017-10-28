using SQLite;
using System;

namespace waltonstine.demo.dotnet.sqlite
{
    class Program
    {
        public class Parent 
        {
            [PrimaryKey, AutoIncrement]
            public int    Parent_pk { get; }
            public string Name      { get; set; }
            public float  MyFloat   { get; set; }
            public byte[] Data      { get; set; }
        }

        public class Child
        {
            [PrimaryKey, AutoIncrement]
            public int Child_pk { get; }
            public int Parent_fk { get; set; }
            public string Detail { get; set; }
        }

        static private int InsertParent(SQLiteConnection conn, string name, float myFloat, byte[] blob)
        {
            int insertCnt = conn.Insert(new Parent()
            {
                Name    = name,
                MyFloat = myFloat,
                Data    = blob
            });

            return insertCnt;
        }

        static private int InsertChild(SQLiteConnection conn, int parentFk, string detail)
        {
            int insertCnt = conn.Insert(new Child()
            {
                Parent_fk = parentFk,
                Detail    = detail
            });

            return insertCnt;
        }

        static public void Main(string[] args)
        {
            string dbPath =  (args.Length == 0) ? "../demo.db" : args[0];

            Console.WriteLine($"Open database {dbPath}");

            SQLiteConnection conn = new SQLiteConnection(dbPath);

            int cnt = InsertParent(conn, "george", 1.234F, null);

            int ii = 1;
            int maxChildren = 3;
            for (; ii <= maxChildren; ii++)
            {
                int rcnt = InsertChild(conn, 1, $"Detail {ii}");
                if (rcnt != 1)
                {
                    Console.Error.WriteLine($"InsertChild: inert returned {rcnt}");
                    break;
                }
            }
            
            conn.Close();

            Console.WriteLine($"Inserted {cnt} rows to Parent");

            if (ii == (maxChildren + 1))
            {
                Console.WriteLine($"Wrote {maxChildren} rows to Child.");
            }
        }
    }
}
