using SQLite;
using System;
using System.Collections.Generic;

namespace waltonstine.demo.dotnet.sqlite
{
    class Program
    {
        public class Parent 
        {
            [PrimaryKey, AutoIncrement]
            public int    Parent_pk { get; set; }
            public string Name      { get; set; }
            public float  MyFloat   { get; set; }
            public byte[] Data      { get; set; }
        }

        public class Child
        {
            [PrimaryKey, AutoIncrement]
            public int Child_pk  { get; set; }
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
            Console.WriteLine($"Inserted {cnt} rows to Parent");

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
            if (ii == (maxChildren + 1))
            {
                Console.WriteLine($"Wrote {maxChildren} rows to Child.");
            }

            IEnumerable<Child> selected = conn.Table<Child>().Where(c => c.Parent_fk == 1);

            Console.WriteLine("Rows from table 'Child': ");
            foreach (Child c in selected)
            {
                Console.WriteLine($"{c.Child_pk} | {c.Parent_fk} | {c.Detail}");
            }

            conn.Close();

            Console.WriteLine("\nDemo is complete.");
        }
    }
}
