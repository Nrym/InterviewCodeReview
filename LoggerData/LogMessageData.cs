using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LoggerBean;

namespace LoggerData
{
    public class LogMessageData
    {
        private string resultInfo = "";

        public bool insertLogMessage(DataMessage dataMessage)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "Insert into LogMessage (message,type,log_date) Values (@message,@type,@log_date)";
                        command.Parameters.Add("@message", SqlDbType.VarChar).Value = dataMessage.message;
                        command.Parameters.Add("@type", SqlDbType.TinyInt).Value = dataMessage.type;
                        command.Parameters.Add("@log_date", SqlDbType.DateTime).Value = dataMessage.log_date;

                        if (command.ExecuteNonQuery() > 0)
                        {
                            result = true;
                            resultInfo = "Written to database succesfully";
                        }
                        else
                        {
                            resultInfo = "Unkown error when inserting the log message into the database";
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                resultInfo = "DatabaseLoggerException thrown: " + ex.Message;
            }
            return result;
        }

        public string getResultInfo()
        {
            return resultInfo;
        }
    }
}
