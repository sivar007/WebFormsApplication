using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace ClassLibrary
{
    public class Database
    {
        public static DataSet GetData(OracleCommand cmd, string host, string port, string sid, string user, string pass)
        {
            var set = new DataSet();
            using(var connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST="+host+")(PORT="+port+")))(CONNECT_DATA=(SID="+sid+")(SERVER=DEDICATED)));User ID="+user+";Password="+pass))
            {
                cmd.Connection = connection;
                connection.Open();

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(set);
            }

            return set;
        }
        static void Main(string[] args)
        {
            var connection = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=dbdev2.hscnet.hsc.usf.edu)(PORT=1522)))(CONNECT_DATA=(SID=DBDEV)(SERVER=DEDICATED)));User ID=HSC;Password=graham_hill");
            connection.Open();
            OracleCommand cmd = new OracleCommand("SELECT global_dept_name FROM HART_GLOBAL_DEPTS_MV", connection);

            var reader = cmd.ExecuteReader();
            Console.WriteLine("From Raw Query");
            Console.WriteLine(new string('-', 60));
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "api.sel_hart_global_depts_all_mv";
            cmd.Parameters.Add("r_results",  OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adapter = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            Console.WriteLine();
            Console.WriteLine("From Stored Procedure with DataTable");
            Console.WriteLine(new string('-', 60));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row["global_dept_name"]);
            }

            ds.Dispose();
            cmd.Dispose();
            connection.Dispose();
            Console.ReadLine();


            
        }
    }
}
