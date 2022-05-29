using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

namespace SportEventResultsV2.DbContent
{
    public class DbConnectionClass
    {
        string CompanyTable = Properties.Resources.CompanyTable;
        public bool SqlConnectionState_Check(MySqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else return false;
        }
        public static MySqlConnectionStringBuilder ConnectionStringBuilder = new MySqlConnectionStringBuilder
        {
            Server = "andr33w.beget.tech", //Properties.Resources.DBHost,
            Database = "andr33w_run_db", // Properties.Resources.DBName,
            UserID = "andr33w_run_db", // Properties.Resources.DBName,
            Password = "BPN1VbSi", // Properties.Resources.DBPass,
        };
        public MySqlConnection Sql_Connection = new MySqlConnection(ConnectionStringBuilder.ConnectionString);

        public DataTable CompanyListTable(string sqlCommandString)
        {
            DataTable companyListDT = new DataTable();
            DataSet _dataSet = new DataSet();
            try
            {
                Sql_Connection.Open();
                while (SqlConnectionState_Check(Sql_Connection) == false)
                {
                    SqlConnectionState_Check(Sql_Connection);
                    Thread.Sleep(200);
                }
                string companySelectSqlString = $"SELECT CompanyName FROM CompanyList";


                MySqlCommand companySelectCommand = new MySqlCommand(companySelectSqlString, Sql_Connection);
                MySqlDataAdapter _adapter = new MySqlDataAdapter(companySelectCommand);
                //companySelectCommand.ExecuteNonQuery();
                _adapter.Fill(_dataSet, "CompanyList");
                companyListDT = _dataSet.Tables["CompanyList"];
                Sql_Connection.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("проблемы с подключением");
                return null;
            }

            return companyListDT;
        }
    }
}
