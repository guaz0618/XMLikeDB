public class ConcatPipelineTests
{
    [Fact]
    public void TestDoSomething()
    {
        // Arrange
        var pipeline = new ConcatPipeline();
        var input = new ConcatPipelineInput
        {
            From = new string[] { "input1", "input2" },
            To = "output",
            Separator = ","
        };
        var row = new XRow { { "input1", "abc" }, { "input2", "def" } };

        // Act
        pipeline.DoSomething(row, input);

        // Assert
        Assert.True(row.ContainsKey("output"));
        Assert.Equal("abc,def", row["output"]);
    }
}