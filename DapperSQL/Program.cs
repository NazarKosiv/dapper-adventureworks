using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperSQL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string connStr = @"
               Server=localhost,1433;
               Database=AdventureWorks;
               User Id=SA;
               Password=my_password
            ";
            
            Console.WriteLine("Hello World!");
            
            await using var connection = new SqlConnection(connStr);
            var res = await connection.QueryAsync<Person>("SELECT * FROM [Person].[Person]");
            foreach (var p in res)
            {
                Console.WriteLine(p);
            }
        }
    }

    public class Person
    {
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public short NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }

        public override string ToString()
        {
            return $"{nameof(BusinessEntityID)}: {BusinessEntityID}, {nameof(PersonType)}: {PersonType}, {nameof(NameStyle)}: {NameStyle}, {nameof(Title)}: {Title}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(MiddleName)}: {MiddleName}, {nameof(Suffix)}: {Suffix}";
        }
    }
}
