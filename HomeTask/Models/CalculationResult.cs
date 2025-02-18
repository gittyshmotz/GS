namespace HomeTask.Models
{
    public class CalculationResult
    {
        public double Result { get; set; }
        public List<HistoryActions> LastActions { get; set; }
        public int UsageCount { get; set; }
    }
}
