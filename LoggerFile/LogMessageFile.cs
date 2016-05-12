using System;
using System.IO;
using LoggerBean;
using System.Threading.Tasks;

namespace LoggerFile
{
    public class LogMessageFile
    {
        string resultInfo = "";

        public bool WriteMessage(FileMessage fileMessage)
        {
            bool result = false;

            try
            {
                if (!Directory.Exists(fileMessage.filePath))
                {
                    Directory.CreateDirectory(fileMessage.filePath);
                }

                using (StreamWriter file = new StreamWriter(fileMessage.fileFullPath, true))
                {
                    file.WriteLine(fileMessage.message);
                }

                result = true;
                resultInfo = "Written to file succesfully";
            }
            catch (Exception ex)
            {
                resultInfo = "FileLoggerException thrown: " + ex.Message;
            }
            return result;
        }

        public string getResultInfo()
        {
            return resultInfo;
        }
    }
}
