using System;
using DoorData.Domain;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using DoorData.Utilities;
using System.Data;

namespace DoorData.Data
{
    public class MilleniumHistoryRepository 
    {        
        private readonly string _connString = string.Empty;
        public MilleniumHistoryRepository(string ConnectionString)
        {
            this._connString = ConnectionString;
        }

        private MilleniumHistoryEntry dataReaderToObject(SqlDataReader dataReader)
        {
            return new MilleniumHistoryEntry()
            {
                Id = dataReader["HistoryTransID"].ToString().ToInt(),
                TransactionTimestamp = dataReader["TransTimestamp"].ToString().ToDateTime(),
                HistoryTimestamp = dataReader["HistoryTimestamp"].ToString().ToDateTime(),
                SiteName = dataReader["SiteName"].ToString(),
                SiteId = dataReader["SiteID"].ToString().ToInt(),
                ActionId = dataReader["ActionID"].ToString().ToInt(),
                ActionDescription = dataReader["ActionDesc"].ToString(),
                OutputColumnA = dataReader["OutputColumnA"].ToString(),
                OutputColumnB = dataReader["OutputColumnB"].ToString(),
                OutputcolumnC = dataReader["OutputColumnC"].ToString(),
                DeviceName = dataReader["DeviceName"].ToString(),
                UserCodeHi = dataReader["UserCodeHi"].ToString().ToInt(),
                UserCodeLo = dataReader["UserCodeLo"].ToString().ToInt(),
                CodeDisplayText = dataReader["CodeDisplayText"].ToString(),
                Operator = dataReader["Operator"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                FirstName = dataReader["FirstName"].ToString(),
                MiddleInitial = dataReader["MiddleInitial"].ToString(),
                ExtraId = dataReader["ExtraID"].ToString().ToInt(),
                ExtraData = dataReader["ExtraData"].ToString(),
                PrevUserCodeHi = dataReader["PrevUserCodeHi"].ToString().ToInt(),
                PrevUserCodeLo = dataReader["PrevUserCodeLo"].ToString().ToInt(),
                ChangeTimestamp = dataReader["ChangeTimestamp"].ToString().ToDateTime(),
                UserId = dataReader["UserID"].ToString().ToInt(),

            };

        }

        private List<MilleniumHistoryEntry> Get()
        {
            List<MilleniumHistoryEntry> returnMe = new List<MilleniumHistoryEntry>();

            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT * FROM HistoryTable ORDER BY HistoryTransID DESC;";
                    sqlCommand.Connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            MilleniumHistoryEntry s = dataReaderToObject(dataReader);
                            if (s != null)
                            {
                                returnMe.Add(s);
                            }
                        }
                    }
                    sqlCommand.Connection.Close();
                }
            }

            return returnMe;
        }

        public List<MilleniumHistoryEntry> Get(int Max)
        {
            List<MilleniumHistoryEntry> returnMe = new List<MilleniumHistoryEntry>();

            using (SqlConnection connection = new SqlConnection(_connString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT TOP " + Max + " * FROM HistoryTable ORDER BY HistoryTransID DESC;";
                    sqlCommand.Connection.Open();
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            MilleniumHistoryEntry s = dataReaderToObject(dataReader);
                            if (s != null)
                            {
                                returnMe.Add(s);
                            }
                        }
                    }
                    sqlCommand.Connection.Close();
                }
            }

            return returnMe;
        }


    }
}