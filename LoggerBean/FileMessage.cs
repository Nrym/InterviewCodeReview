using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerBean
{
    public class FileMessage
    {
        public string message { get; set; }

        public string filePath { get; set; }

        public string fileName { get; set; }

        public string fileFullPath
        {
            get { return filePath + fileName; }
        }
        
        public FileMessage(string message, string filePath, string fileName)
        {
            this.message = message;
            this.filePath = filePath;
            this.fileName = fileName;
        }
    }
}
