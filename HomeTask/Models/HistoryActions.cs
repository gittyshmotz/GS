namespace HomeTask.Models
{
    public class HistoryActions
    {
        public int Id { get; set; }
        public string Operation { get; set; } = string.Empty;
        public string ValueA { get; set; } = string.Empty;
        public string ValueB { get; set; } = string.Empty;

        public double Result { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
