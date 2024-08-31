namespace CodingLogger.Models
{
    public class CodingSession
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public CodingSession(int id, int duration, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Duration = duration;
            StartTime = startTime;
            EndTime = endTime;
        }
        protected CodingSession()
        {
            
        }
    }
}

