using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.MySql
{
    public class MySqlDbAccess : MySqlManager
    {
        public CommandType CommandType { get; }
        //public MySqlDBAccess(string ConnectionStringKeyName, CommandType Type) : base(ConnectionStringKeyName)
        //{
        //    CommandType = Type;
        //}

        public MySqlDbAccess(string connectionString, CommandType Type = CommandType.StoredProcedure) 
            : base(connectionString)
        {
            CommandType = Type;
        }

        public DataTable GetData(string command, nameValuePairs nameValuePairObject)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(command);
                GetConnection(this.SqlConnectionObject);
                cmd.Connection = this.SqlConnectionObject;
                cmd.CommandType = CommandType;
                cmd.Parameters.Clear();

                foreach (nameValuePair objList in nameValuePairObject)
                {
                    cmd.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));
                }
                try
                {
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    if (ds.Tables.Count > 0)
                        return ds.Tables[0];
                    else
                        return null;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                finally
                {
                    CloseConnection(this.SqlConnectionObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetData(string command)
        {
            try
            {
                GetConnection(this.SqlConnectionObject);
                MySqlDataAdapter adp = new MySqlDataAdapter(command, this.SqlConnectionObject);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(this.SqlConnectionObject);
            }
        }

        public DataSet GetDataSet(string command, nameValuePairs nameValuePairObject)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(command);
                GetConnection(this.SqlConnectionObject);
                cmd.Connection = this.SqlConnectionObject;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                foreach (nameValuePair objList in nameValuePairObject)
                {
                    cmd.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(this.SqlConnectionObject);
            }
        }

        public int InsertUpdateDeleteReturnInt(string command, nameValuePairs nameValuePairObject)
        {
            MySqlCommand cmdObject = new MySqlCommand(command);
            GetConnection(this.SqlConnectionObject);
            cmdObject.Connection = this.SqlConnectionObject;
            cmdObject.CommandType = CommandType;
            cmdObject.Parameters.Clear();

            foreach (nameValuePair objList in nameValuePairObject)
            {
                cmdObject.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));
            }
            try
            {
                cmdObject.ExecuteScalar();
                return 1;//Convert.ToInt32();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection(this.SqlConnectionObject);
            }
        }

        public DataTable InsertUpdateDeleteReturnData(string command, nameValuePairs nameValuePairObject)
        {
            GetConnection(this.SqlConnectionObject);
            MySqlCommand cmdObject = new MySqlCommand(command)
            {
                Connection = this.SqlConnectionObject,
                CommandType = CommandType
            };
            cmdObject.Parameters.Clear();
            MySqlDataReader sdrObj;

            foreach (nameValuePair objList in nameValuePairObject)
            {
                cmdObject.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));
            }
            try
            {
                sdrObj = cmdObject.ExecuteReader();
                DataTable Dt = new DataTable();
                Dt.Load(sdrObj);
                return Dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection(this.SqlConnectionObject);
            }
        }

        public Object InsertUpdateDeleteReturnObject(string Command, 
            nameValuePairs NameValuePairObject, 
            string outParameterName)
        {
            GetConnection(this.SqlConnectionObject);
            MySqlCommand cmdObject = new MySqlCommand(Command)
            {
                Connection = this.SqlConnectionObject,
                CommandType = CommandType
            };
            cmdObject.Parameters.Clear();

            foreach (nameValuePair objList in NameValuePairObject)
                cmdObject.Parameters.Add(createSqlParameter(objList.getName, objList.getValue));

            cmdObject.Parameters.Add(outParameterName, MySqlDbType.VarChar, 30);
            cmdObject.Parameters[outParameterName].Direction = ParameterDirection.Output;
            try
            {
                cmdObject.ExecuteNonQuery();
                return cmdObject.Parameters[outParameterName].Value;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection(this.SqlConnectionObject);
            }
        }

        private MySqlParameter createSqlParameter(string name, object value)
        {
            MySqlParameter objSqlParameter = new MySqlParameter(name, value);
            return objSqlParameter;
        }
    }
}
