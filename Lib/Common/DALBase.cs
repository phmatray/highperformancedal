using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Lib.Sample;

namespace Lib.Common
{
    public abstract class DALBase
    {
        // ConnectionString
        protected static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString; }
        }


        // GetDbSqlCommand
        protected static SqlCommand GetDbSQLCommand(string sqlQuery)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            return command;
        }


        // GetDbConnection
        protected static SqlConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionString);
        }


        // GetDbSprocCommand
        protected static SqlCommand GetDbSprocCommand(string sprocName)
        {
            SqlCommand command = new SqlCommand(sprocName);
            command.Connection = GetDbConnection();
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        // CreateNullParameter
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }


        // CreateNullParameter - with size for nvarchars
        protected static SqlParameter CreateNullParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Size = size;
            parameter.Value = null;
            parameter.Direction = ParameterDirection.Input;
            return parameter;
        }


        // CreateOutputParameter
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }


        // CreateOuputParameter - with size for nvarchars
        protected static SqlParameter CreateOutputParameter(string name, SqlDbType paramType, int size)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = paramType;
            parameter.Size = size;
            parameter.ParameterName = name;
            parameter.Direction = ParameterDirection.Output;
            return parameter;
        }


        // CreateParameter - uniqueidentifier
        protected static SqlParameter CreateParameter(string name, Guid value)
        {
            if (value.Equals(Common.DTOBase.NullValueGuid))
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.UniqueIdentifier);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.UniqueIdentifier;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }


        // CreateParameter - int
        protected static SqlParameter CreateParameter(string name, int value)
        {
            if (value == Common.DTOBase.NullValueInt)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.Int);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }


        // CreateParameter - datetime
        protected static SqlParameter CreateParameter(string name, DateTime value)
        {
            if (value == Common.DTOBase.NullValueDateTime)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.DateTime);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.DateTime;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }


        // CreateParameter - nvarchar
        protected static SqlParameter CreateParameter(string name, string value, int size)
        {
            if (value == Common.DTOBase.NullValueString)
            {
                // If value is null then create a null parameter
                return CreateNullParameter(name, SqlDbType.NVarChar);
            }
            else
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Size = size;
                parameter.ParameterName = name;
                parameter.Value = value;
                parameter.Direction = ParameterDirection.Input;
                return parameter;
            }
        }


        // GetSingleDTO
        protected static T GetSingleDTO<T>(ref SqlCommand command) where T : DTOBase
        {
            T dto = null;
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    DTOParser parser = DTOParserFactory.GetParser(typeof (T));
                    parser.PopulateOrdinals(reader);
                    dto = (T) parser.PopulateDTO(reader);
                    reader.Close();
                }
                else
                {
                    // Whever there's no data, we return null.
                    dto = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            // return the DTO, it's either populated with data or null.
            return dto;
        }


        // GetDTOList
        protected static List<T> GetDTOList<T>(ref SqlCommand command) where T : DTOBase
        {
            List<T> dtoList = new List<T>();
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // Get a parser for this DTO type and populate
                    // the ordinals.
                    DTOParser parser = DTOParserFactory.GetParser(typeof (T));
                    parser.PopulateOrdinals(reader);
                    // Use the parser to build our list of DTOs.
                    while (reader.Read())
                    {
                        T dto = null;
                        dto = (T) parser.PopulateDTO(reader);
                        dtoList.Add(dto);
                    }
                    reader.Close();
                }
                else
                {
                    // Whenver there's no data, we return null.
                    dtoList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error populating data", e);
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return dtoList;
        }
    }
}