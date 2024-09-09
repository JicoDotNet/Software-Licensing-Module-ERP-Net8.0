using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using DataAccess.MySql.Entity;
using MySql.Data.MySqlClient;

namespace DataAccess.MySql
{
    public class MySqlDbAccess : MySqlManager , IMySqlDBAccess, IDisposable
    {
        private CommandType CommandType { get; }

        public MySqlDbAccess(string connectionString) 
            : base(connectionString)
        {
            CommandType = CommandType.StoredProcedure;
        }


        public DataRow GetFirstOrDefaultData(string command, INameValuePairs NameValuePairObject)
        {
            try
            {
                using (DataSet ds = Get(command, NameValuePairObject))
                {
                    if (ds != null)
                        if (ds.Tables.Count > 0)
                            if (ds.Tables[0].Rows.Count > 0)
                                return ds.Tables[0].Rows[0];
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTable GetData(string command)
        {
            try
            {
                using (DataSet ds = Get(command))
                {
                    if (ds != null)
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0];
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetData(string command, INameValuePairs NameValuePairObject)
        {
            try
            {
                using (DataSet ds = Get(command, NameValuePairObject))
                {
                    if (ds != null)
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0];
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetDataSet(string command, INameValuePairs NameValuePairObject)
        {
            try
            {
                using (DataSet ds = Get(command, NameValuePairObject))
                {
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataSet Get(string command, INameValuePairs NameValuePairObject = null)
        {
            try
            {
                OpenConnection();

                MySqlCommand cmd = new MySqlCommand(command)
                {
                    Connection = this.MySqlConnectionObject,
                    CommandType = CommandType
                };
                cmd.Parameters.Clear();
                if(NameValuePairObject != null)
                {
                    foreach (NameValuePair objList in NameValuePairObject)
                    {
                        cmd.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));
                    }
                }                

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int InsertUpdateDeleteReturnInt(string command, INameValuePairs NameValuePairObject)
        {
            OpenConnection();

            MySqlCommand cmdObject = new MySqlCommand(command);            
            cmdObject.Connection = this.MySqlConnectionObject;
            cmdObject.CommandType = CommandType;
            cmdObject.Parameters.Clear();

            foreach (NameValuePair objList in NameValuePairObject)
            {
                cmdObject.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));
            }
            try
            {
                return Convert.ToInt32(cmdObject.ExecuteScalar());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public object InsertUpdateDeleteReturnObject(string Command, 
            NameValuePairs NameValuePairObject, 
            string outParameterName)
        {
            OpenConnection();
            MySqlCommand cmdObject = new MySqlCommand(Command)
            {
                Connection = this.MySqlConnectionObject,
                CommandType = CommandType
            };
            cmdObject.Parameters.Clear();

            foreach (NameValuePair objList in NameValuePairObject)
                cmdObject.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));

            cmdObject.Parameters.Add(outParameterName, MySqlDbType.VarChar, 30);
            cmdObject.Parameters[outParameterName].Direction = ParameterDirection.Output;
            try
            {
                cmdObject.ExecuteNonQuery();
                return cmdObject.Parameters[outParameterName].Value;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        private MySqlParameter createSqlParameter(string name, object value)
        {
            MySqlParameter objSqlParameter = new MySqlParameter(name, value);
            return objSqlParameter;
        }

        public void Dispose()
        {
            CloseConnection();
            GC.Collect();
        }
    }
}
