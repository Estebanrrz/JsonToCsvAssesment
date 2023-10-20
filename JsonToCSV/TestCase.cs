namespace JsonToCSV
{
    public class TestCase
    {
        public TestCase(string name, string status, double executionTime, DateTime timestamp)
        {
            Name = name;
            Status = status;
            ExecutionTime = executionTime;
            Timestamp = timestamp;
        }

        public string Name { get; set; }
        public string Status { get; set; }
        public double ExecutionTime { get; set; }
        public DateTime Timestamp { get; set; }
    }
}