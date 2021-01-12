using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Data.Client;

namespace SnowFlakeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // string connectionString = "Host=jo69808.us-central1.gcp.snowflakecomputing; ROLE=sysadmin;WAREHOUSE=John; USER=johns; PASSWORD=Water123;DB=JOHN;SCHEMA=EM";
            string connectionString = "scheme=https;host=jo69808.us-central1.gcp.snowflakecomputing.com;ROLE=sysadmin;WAREHOUSE=John;user=johns;password=Water123;DB=JOHN;account=jo69808.us-central1.gcp.*;";


            //Scenario 1. Get the list of employee from Snowflake View which returns Json data  ///Read The data using snow flake
            using (var conn = new SnowflakeDbConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from testtable1;";
                var reader = cmd.ExecuteReader();
                dynamic employeeList;
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    employeeList = reader.GetString(0);
                }
                conn.Close();
                Insert();
            }
           

        }
            public static void Insert()
            {
            string connectionString = "scheme=https;host=jo69808.us-central1.gcp.snowflakecomputing.com;ROLE=sysadmin;WAREHOUSE=John;user=johns;password=Water123;DB=JOHN;account=jo69808.us-central1.gcp.*;";
         
            using (var conn = new SnowflakeDbConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "insert into testtable1 values('hello','snowflake'); ";// while calling procedure 
                var reader = cmd.ExecuteReader();
                dynamic resultData;
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    resultData = reader.GetString(0);
                }
                conn.Close();
            }
        }
    }
}  
     
