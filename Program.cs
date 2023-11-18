using BenchmarkDotNet.Running;

var parser = new SpanBenchmark();
Console.WriteLine(parser.ParseDateTimeSubstring());
Console.WriteLine(parser.ParseDateTimeSpan());

BenchmarkRunner.Run<SpanBenchmark>();