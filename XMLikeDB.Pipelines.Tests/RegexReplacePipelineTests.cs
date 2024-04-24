public class RegexReplacePipelineTests
{
    [Fact]
    public void TestDoSomething()
    {
        // Arrange
        var pipeline = new RegexReplacePipeline();
        var input = new RegexReplacePipelineInput
        {
            From = "input",
            To = "output",
            Pattern = "\\d+",
            Replacement = "number"
        };
        var row = new XRow { { "input", "abc123def" } };

        // Act
        pipeline.DoSomething(row, input);

        // Assert
        Assert.True(row.ContainsKey("output"));
        Assert.Equal("abcnumberdef", row["output"]);
    }
}