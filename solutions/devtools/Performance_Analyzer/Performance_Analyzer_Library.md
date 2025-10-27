---
uid: Performance_Analyzer_Library
---

# Performance Analyzer library

The first component of the Performance Analyzer Solution is the library, which is available as a NuGet package. You can use this component on its own, or together with the [Performance Analyzer app](xref:Performance_Analyzer_LCA).

## Installing the library

To install the library, download the [Skyline.DataMiner.Utils.PerformanceAnalyzer](https://www.nuget.org/packages/Skyline.DataMiner.Utils.PerformanceAnalyzer) NuGet package.

> [!NOTE]
> The [Performance Analyzer repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.PerformanceAnalyzer) is open source. Pull requests are welcome.

## Tracking performance using the library

To make the most of the Performance Analyzer library, you need to understand the reasoning behind its design. Below, this will be explained with examples, starting from a simple solution and gradually moving towards implementing the Performance Analyzer library.

Consider the following example: A script is used that connects to the database, fetches data, processes it, and stores it. Imagine that this is performance-critical, and you need to keep an eye on it and make sure any performance-related issues are detected and resolved in a timely manner.

For the example script, dummy methods will be used with arbitrary `Thread.Sleep` calls to simulate execution. Let's define the dummy methods first.

```csharp
public static void Connect()
{
  Thread.Sleep(100);
}

public static List<string> Fetch()
{
  Thread.Sleep(500);
  var data = new List<string>() { string.Empty, string.Empty, string.Empty };

  return data;
}

public static void Process(string item)
{
  Thread.Sleep(300);
}

public static void Store(List<string> data)
{
  Thread.Sleep(1000);
}

public static void Log(string message)
{
  Console.WriteLine(message);
}
```

Now that the basic setup has been configured, the first question is: how can the performance of the script be tracked?

The simplest approach is to call `DateTime.Now` at the start and end of the script, then subtract those values to calculate the execution time.

```csharp
public static void Solution()
{
  var startTime = DateTime.Now;

  Connect();

  var data = Fetch();

  foreach (var item in data)
  {
    Process(item);
  }

  Store(data);

  var executionTime = DateTime.Now - startTime;
  Log($"Execution time: {executionTime}");
}
```

This approach gives you fairly accurate execution times and a general sense of how the system is performing. While it is a good indicator of whether there is a problem, it does not help you identify the root cause. How can you determine which part of the script requires investigation? Is it a slow connection causing delays in fetching or storing data, or perhaps an inefficiently implemented processing method? With the current approach, it is not possible to tell. Measuring the overall script execution time can alert you to a problem, but it will not help you pinpoint the issue.

While you could track arbitrary code sections for this, a more intuitive approach would be to implement tracking at the method level.

```csharp
public static void Solution()
{
  var scriptStartTime = DateTime.Now;

  var connectStartTime = DateTime.Now;
  Connect();
  var connectExecutionTime = DateTime.Now - connectStartTime;

  var fetchStartTime = DateTime.Now;
  var data = Fetch();
  var fetchExecutionTime = DateTime.Now - fetchStartTime;

  TimeSpan processExecutionTime = default;
  foreach (var item in data)
  {
    var processStartTime = DateTime.Now;
    Process(item);
    processExecutionTime = DateTime.Now - processStartTime;
  }

  var storeStartTime = DateTime.Now;
  Store(data);
  var storeExecutionTime = DateTime.Now - storeStartTime;

  var scriptExecutionTime = DateTime.Now - scriptStartTime;

  Log($"Script execution time: {scriptExecutionTime}");
  Log($"Connect execution time: {connectExecutionTime}");
  Log($"Fetch execution time: {fetchExecutionTime}");
  Log($"Process execution time: {process}");
}
```

Now you can narrow down issues to specific methods, which is great, but a major drawback is that the once simple code is now very bloated. Imagine applying this to an entire project. Not only do you need to call `DateTime.Now`, which is relatively expensive, before and after every method, but this tracking is also limited to one place. If these methods are called elsewhere, the same process must be repeated. Additionally, careful handling of variable scope is needed; for instance, `processExecutionTime` had to be defined before the loop and shared between multiple calls to the `Process` method, meaning that the execution time metric for it will only capture the last processed item.

To reduce code bloat and improve scalability, you could replace the start and end time tracking with simpler language constructs and move the tracking logic directly into each method. The simplest constructs you can use are curly braces to define the start and end of a method. By defining a block of code using curly braces, you can call `DateTime.Now` at "`{`" and perform the calculation at "`}`". To achieve this behavior, you can leverage the `IDisposable` interface and the `using` statement. This requires modifying the method implementations and creating a class that implements `IDisposable`.

> [!NOTE]
> The examples below will only show the implementation for the `Connect` method. The `Fetch`, `Process`, and `Store` methods follow the same pattern.

First, define the tracker and apply it in your methods.

```csharp
public class Tracker : IDisposable
{
  private DateTime startTime;

  public Tracker()
  {
    startTime = DateTime.Now;
  }

  public TimeSpan ExecutionTime { get; private set; }

  public void Dispose()
  {
    ExecutionTime = DateTime.Now - startTime;
  }
}

public static void Connect(out TimeSpan executionTime)
{
  Tracker tracker;
  using (tracker = new Tracker())
  {
    Thread.Sleep(100);
  }

  executionTime = tracker.ExecutionTime;
}
```

Now update the script to use the `Tracker` you have just defined.

```csharp
public static void Solution()
{
  Tracker tracker;
  TimeSpan connectExecutionTime;
  TimeSpan fetchExecutionTime;
  TimeSpan processExecutionTime = default;
  TimeSpan storeExecutionTime;

  using (tracker = new Tracker())
  {
    Connect(out connectExecutionTime);

    var data = Fetch(out fetchExecutionTime);

    foreach (var item in data)
    {
      Process(item, out processExecutionTime);
    }

    Store(data, out storeExecutionTime);
  }

  Log($"Script execution time: {tracker.ExecutionTime}");
  Log($"Connect execution time: {connectExecutionTime}");
  Log($"Fetch execution time: {fetchExecutionTime}");
  Log($"Process execution time: {processExecutionTime}");
  Log($"Store execution time: {storeExecutionTime}");
}
```

While this already allows much easier scaling, the results still need to be returned to the caller, which is why `out` arguments are used. In addition, the scope issue and the issue with tracking multiple calls to the same method have not been fixed yet. This means a better way is still needed to store these results.

You could introduce a collector to gather all the results. The simplest implementation is a dictionary, where the method name serves as the key and the execution time as the value. Start by defining the collector and modifying the tracker to make use of it.

> [!NOTE]
> Here `StackTrace` is used to generate the method names, but you could just have passed the method name directly into the tracker's constructor.

```csharp
public static Dictionary<string, TimeSpan> Collector = new Dictionary<string, TimeSpan>();

public class Tracker : IDisposable
{
  private readonly DateTime startTime = DateTime.Now;

  public Tracker()
  {
  }

  public TimeSpan ExecutionTime { get; private set; }

  public void Dispose()
  {
    ExecutionTime = DateTime.Now - startTime;
    Collector.Add(GenerateMethodName(), ExecutionTime);
  }

  private string GenerateMethodName()
  {
    MethodBase methodMemberInfo = new StackTrace().GetFrames().Skip(2).FirstOrDefault()?.GetMethod();
    return methodMemberInfo.Name != "ProcessD"
      ? methodMemberInfo.Name
      : methodMemberInfo.Name + Guid.NewGuid();
  }
}

public static void Connect()
{
  using (new Tracker())
  {
    Thread.Sleep(100);
  }
}
```

Because there are multiple calls to the `Process` method, `GenerateMethodName` had to be implemented in the tracker to avoid duplicate key exceptions, but now you can finally track all of those calls.

```csharp
public static void Solution()
{
  using (new Tracker())
  {
    Connect();

    var data = Fetch();

    foreach (var item in data)
    {
      Process(item);
    }

    Store(data);
  }

  foreach (var result in Collector)
  {
    Log($"{result.Key} execution time: {result.Value}");
  }
}
```

The boilerplate has now been minimized to just one `using` statement, but at this point you still need to consider when to log the results. It is possible that `Solution` is not the last method executed in the script, meaning if you log results at the end of it, you might miss performance data gathered afterward. It is important to ensure that logging occurs only when all trackers are completed and have been disposed of, and that this happens automatically.

To address this issue, the collector logic must be expanded, as a dictionary alone will not suffice. Create a new class that implements `IDisposable` and tracks how many trackers are currently active. Only when the last tracker finishes collecting performance metrics, will the results be logged.

```csharp
public class Collector : IDisposable
{
  public Dictionary<string, TimeSpan> Results { get; private set; } = new Dictionary<string, TimeSpan>();
  public int TrackersCount { get; set; }

  public void Dispose()
  {
    TrackersCount--;
    if (TrackersCount == 0)
    {
      foreach (var result in Results)
      {
        Log($"{result.Key} execution time: {result.Value}");
      }
    }
  }
}

public class Tracker : IDisposable
{
  private readonly DateTime startTime = DateTime.Now;
  private readonly Collector collector;

  public Tracker(Collector collector)
  {
    this.collector = collector;
    collector.TrackersCount++;
  }

  public TimeSpan ExecutionTime { get; private set; }

  public void Dispose()
  {
    ExecutionTime = DateTime.Now - startTime;
    collector.Results.Add(GenerateMethodName(), ExecutionTime);
    collector.Dispose();
  }
}

public static Collector CollectorInstance { get; set; } = new Collector();

public static void Connect()
{
  using (new Tracker(CollectorInstance))
  {
    Thread.Sleep(100);
  }
}
```

Here, the `Collector` instance is a static object to keep it simple. Note that this example would not be very good design in real life, but it will give you a good idea of the bigger picture.

```csharp
public static void Solution()
{
  using (new Tracker(CollectorInstance))
  {
    Connect();

    var data = Fetch();

    foreach (var item in data)
    {
      Process(item);
    }

    Store(data);
  }
}
```

While this now looks acceptable, with the only addition compared to the original implementation being the `using` statement, there are still several ways this implementation can fall short, such as:

- Just having the method name and execution time provides limited insight.
- Methods are inherently nested, but the logs are not, so it may be difficult to know where a method is called from.
- It is not possible to save the results somewhere other than in a log file.
- As the size of the data increases, processing time will increase, but it is not possible to track if the data size changes.
- It is not clear how this implementation will behave in multithreaded environments.
- The data is not visualized effectively, so you may need to scroll to vast amounts logging.

The **Performance Analyzer** can help with these and many other challenges. Its underlying logic is similar to what is illustrated above; the only difference lies in the implementation details. Thanks to abstraction — one of the key pillars of OOP — these details will not affect how the solution is used.

The key difference between the implementation above and the Performance Analyzer is that you need to provide the `PerformanceCollector` with an instance of an object that implements the `IPerformanceLogger` interface. This gives you the flexibility to report metrics in various ways. The library provides a default implementation called `PerformanceFileLogger`, which logs metrics to a file.

```csharp
public static IPerformanceLogger Logger { get; set; } = new PerformanceFileLogger("firstCollection", "results");

public static PerformanceCollector Collector { get; set; } = new PerformanceCollector(Logger);

public static void Connect()
{
  using (new PerformanceTracker(Collector))
  {
    Thread.Sleep(100);
  }
}
```

By default, the file, *results.json* in this case, will be created in the folder `C:\Skyline_Data\PerformanceAnalyzer`.

```csharp
public static void Solution()
{
  using (new PerformanceTracker(Collector))
  {
    Connect();

    var data = Fetch();

    foreach (var item in data)
    {
      Process(item);
    }

    Store(data);
  }
}
```

`IPerformanceLogger` defines a single method: `Report(List<PerformanceData>)`. `PerformanceData` represents each method being tracked. It includes details such as the name of the class the method belongs to, the method's name, start and execution times, as well as metadata. This already provides much more information than a simple dictionary could, and in addition to this, `PerformanceData` also contains a list of sub-methods, allowing you to represent the nesting of method calls. This means that in the results, you can determine exactly where each method was called.

Even when the same code is executed repeatedly, not all executions are identical. The amount of data may vary, the type of data could differ, or the server's state might change. All these factors can impact performance, and without the right context, understanding the metrics can be challenging. This means it would be ideal if the context could be included in the results, and this is possible using **metadata**. Metadata can be defined either on the `PerformanceFileLogger` or on the `PerformanceTracker`. Metadata at the logger level can be used to provide context for the overall script execution, while metadata at the tracker level can add context for specific method calls.

```csharp
public static IPerformanceLogger Logger { get; set; } = new PerformanceFileLogger("secondCollection", "results").AddMetadata("Server", GetServer());

public static List<string> Fetch()
{
  var data = new List<string>() { string.Empty, string.Empty, string.Empty };

  using (new PerformanceTracker(Collector).AddMetadata("Count", $"{data.Count}"))
  {
    Thread.Sleep(500);
  }

  return data;
}
```

With context added, it will now be a lot easier to interpret the results accurately. But what if data processing can happen in parallel? Generally, it does not matter whether the Performance Analyzer is used in single- or multithreaded environments, but there is one important thing to keep in mind: **in multithreaded scenarios, nesting must be handled explicitly**. This means the parent tracker must be defined by passing it to the constructor of the tracker running on a separate thread.

```csharp
public static void Solution()
{
  using (var parentTracker = new PerformanceTracker(Collector))
  {
    Connect();

    var data = Fetch();

    Parallel.ForEach(data, (item) =>
    {
      using (new PerformanceTracker(parentTracker))
      {
        Process(item);
      }
    });

    Store(data);
  }
}
```

Note that while this is not an issue here since `Parallel.ForEach` is a blocking call, it is crucial to **wait for all tracked threads to complete** before disposing of the parent tracker. Otherwise, the results may not be as expected.

> [!TIP]
> For more examples, refer to the readme file in the [Performance Analyzer repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.PerformanceAnalyzer).
