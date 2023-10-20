namespace JsonToCSV
{
    /// <summary>
    /// Test Case metrics objet to Calculate metrics
    /// </summary>
    public class TestCaseMetrics
    {
        public int TotalTestCases { get; private set; }
        public int PassedTestCases { get; private set; }
        public int FailedTestCases { get; private set; }
        public int NotExecutedTestCases { get; private set; }
        public double AverageExecutionTime { get; private set; }
        public double MinExecutionTime { get; private set; }
        public double MaxExecutionTime { get; private set; }

        /// <summary>
        /// Calculates metrics based on list of test cases
        /// </summary>
        /// <param name="testCases">List of Testcases to calculate metrics</param>
        public void CalculateMetrics(List<TestCase> testCases)
        {
            TotalTestCases = testCases.Count;
            PassedTestCases = testCases.Count(tc => tc.Status == "Passed");
            FailedTestCases = testCases.Count(tc => tc.Status == "Failed");
            NotExecutedTestCases = testCases.Count(tc => tc.Status == "Not Executed");

            if (TotalTestCases > 0)
            {
                AverageExecutionTime = testCases.Average(tc => tc.ExecutionTime);
                MinExecutionTime = testCases.Min(tc => tc.ExecutionTime);
                MaxExecutionTime = testCases.Max(tc => tc.ExecutionTime);
            }
        }
    }
}
