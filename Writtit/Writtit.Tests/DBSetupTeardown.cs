using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writtit.Tests
{
    internal class DBSetupTeardown
    {
        internal void BuildMock()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = new FileInfo("DBScripts/BuildMock.txt").OpenText().ReadToEnd(),
                    Connection = cn
                };
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        internal void TeardownMock()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = new FileInfo("DBScripts/DropMock.txt").OpenText().ReadToEnd(),
                    Connection = cn
                };
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
