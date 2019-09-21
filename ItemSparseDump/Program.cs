using DBCD.Providers;
using System;
using System.IO;

namespace ItemSparseDump
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbcd = new DBCD.DBCD(new ItemSparseProvider(), new GithubDBDProvider());
            var ItemSparse = dbcd.Load("ItemSparse", "8.2.5.31921");
            foreach (dynamic row in ItemSparse.Values)
            {
                Console.WriteLine(row.ID + " " + row.Display_lang);
            }
        }
    }
    class ItemSparseProvider : IDBCProvider
    {
        public Stream StreamForTableName(string tableName, string build)
        {
            if (File.Exists(tableName + ".db2"))
            {
                return File.Open(tableName + ".db2", FileMode.Open);
            }
            else
            {
                throw new FileNotFoundException("Could not find " + tableName);
            }
        }
    }
}
