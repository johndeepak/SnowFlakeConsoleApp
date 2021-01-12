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
            string connectionString = "scheme=https;ACCOUNT=bea78282;HOST=bea78282.us-east-1.snowflakecomputing.com;port=443; ROLE=sysadmin;WAREHOUSE=compute_wh; USER=nitesh; PASSWORD=XXXXXXX;DB=employeemanagement;SCHEMA=EM";
      

            //Scenario 1. Get the list of employee from Snowflake View which returns Json data  
            using (var conn = new SnowflakeDbConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from employee_skill_json_view;";
                var reader = cmd.ExecuteReader();
                dynamic employeeList;
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    employeeList = reader.GetString(0);
                }
                conn.Close();
            }

            

            //Scenario 2. Call the stored procedure employee_insert_json to insert to json data.  
            string inputJsonData = @"{employee_name : San, employee_address: Hyderabad}";
            using (var conn = new SnowflakeDbConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "call employee_insert_json('" + inputJsonData + "'); ";
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
     
