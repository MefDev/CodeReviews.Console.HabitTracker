namespace CodingLogger.Models
{
    public class CodingSession
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public CodingSession(int id, int duration, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Duration = duration;
            Start = startDate;
            End = endDate;
        }
    }
}

