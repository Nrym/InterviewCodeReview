namespace LoggerBean
{
    public class DataMessage
    {
        public int id { get; set; }
        
        public string message { get; set; }
        
        public int type { get; set; }
        
        public string log_date { get; set; }


        public DataMessage(string message, int type, string log_date)
        {
            this.message = message;
            this.type = type;
            this.log_date = log_date;
        }

        public DataMessage(int id, string message, int type, string log_date)
        {
            this.id = id;
            this.message = message;
            this.type = type;
            this.log_date = log_date;
        }
    }

}
