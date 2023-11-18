using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class SpanBenchmark
{
    private readonly string _dateAsText = "23 05 2023 11:15";

    [Benchmark]
    public (int day, int month, int year, int hour, int minute) ParseDateTimeSubstring()
    {
        var dayAsText = _dateAsText.Substring(0, 2);
        var monthAsText = _dateAsText.Substring(3, 2);
        var yearAsText = _dateAsText.Substring(6, 4);
        var hourAsText = _dateAsText.Substring(11, 2);
        var minuteAsText = _dateAsText.Substring(14);

        return (
            int.Parse(dayAsText),
            int.Parse(monthAsText),
            int.Parse(yearAsText),
            int.Parse(hourAsText),
            int.Parse(minuteAsText)
        );
    }

    [Benchmark]
    public (int day, int month, int year, int hour, int minute) ParseDateTimeSpan()
    {
        ReadOnlySpan<char> dateAsSpan = _dateAsText;
        var dayAsText = dateAsSpan.Slice(0, 2);
        var monthAsText = dateAsSpan.Slice(3, 2);
        var yearAsText = dateAsSpan.Slice(6, 4);
        var hourAsText = dateAsSpan.Slice(11, 2);
        var minuteAsText = dateAsSpan.Slice(14);

        return (
            int.Parse(dayAsText),
            int.Parse(monthAsText),
            int.Parse(yearAsText),
            int.Parse(hourAsText),
            int.Parse(minuteAsText)
        );
    }
}