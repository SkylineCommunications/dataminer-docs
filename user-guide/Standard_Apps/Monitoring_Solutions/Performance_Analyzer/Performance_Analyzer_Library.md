---
uid: Performance_Analyzer_Library
---

# Performance Analyzer Library

The first component of the Performance Analyzer solution is the [library](https://www.nuget.org/packages/Skyline.DataMiner.Utils.PerformanceAnalyzer). To make the most of it, it's essential to understand the reasoning behind its design. This section will help you with that.

## Problem

Let's consider the following example:

We have a script that connects to the database, fetches the data, processes, and stores it. Imagine that this is performance critical, and we need to keep an eye on it and make sure any performance related issues are detected and resolved in a timely manner.

## Tracking the performance

We'll start with the simplest solution and gradually move towards implementing the Performance Analyzer. To do this, we'll use dummy methods with arbitrary ```Thread.Sleep``` calls to simulate execution.

Let's define the dummy methods first.

```c#
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

Now that we have the basic setup configured, we can proceed. The first question becomes: how do we track the performance of our script? 

We will start with the simplest approach: call ```DateTime.Now``` at the start and end of the script, then subtract those values to calculate the execution time.

```c#
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

This approach gives us fairly accurate execution times and a general sense of how our system is performing. While it's a good indicator of whether there is a problem, it doesn't help us identify the root cause. How can we determine which part of the script requires investigation? Is it a slow connection causing delays in fetching or storing data, or perhaps an inefficiently implemented processing method? With our current approach, we simply can't tell. 

It seems more detailed performance tracking is needed. Measuring the overall script execution time can alert us to a problem, but it won't help us pinpoint the issue. While we could track arbitrary code sections, a more intuitive approach would be to implement tracking at the method level.

```c#
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

We're now able to narrow down issues to specific methods—great! But wait, we've significantly bloated our once simple code. Imagine applying this to an entire project. Not only do we need to call ```DateTime.Now```—which is relatively expensive—before and after every method, but this tracking is also limited to one place. If these methods are called elsewhere, we must repeat the same process. Additionally, we must handle variable scope carefully; for instance, ```processExecutionTime``` had to be defined before the loop and shared between multiple calls to ```Process``` method, meaning that the execution time metric for it will only capture the last processed item.

We need more scalable solution that won't bloat our code as much. To reduce code bloat and improve scalability, we could replace the start and end time tracking with simpler language constructs and move the tracking logic directly into each method. The simplest constructs we can use are curly braces to define the start and end of a method. By defining a block of code using curly braces, we can call ```DateTime.Now``` at ```{``` and perform our calculation at ```}```. To achieve this behavior, we can leverage the ```IDisposable``` interface and the ```using``` statement. This requires modifying our method implementations and creating a class that implements ```IDisposable```. 

> [!NOTE]
> This example will only show the implementation for the ```Connect``` method. The ```Fetch```, ```Process```, and ```Store``` methods follow the same pattern. We'll continue with this approach throughout the rest of the article.

First, we will define our tracker and apply it in our methods.

```c#
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

Let’s update our script to use the ```Tracker``` we’ve just defined.

```c#
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

There's still some boilerplate, but we can now scale this with much less effort. The main issue is that we need to return the results to the caller, which is why we're using ```out``` arguments, and we still haven’t fixed the scope issue, or issue with tracking multiple calls to the same method. We need to find a better way to store these results.

We could introduce a collector to gather all the results. The simplest implementation is a dictionary, where the method name serves as the key and the execution time as the value. Here we're using ```StackTrace``` to generate the method names, but we could have just passed the method name directly into the tracker's constructor.
Start by defining the collector and modifying the tracker to make use of it.

```c#
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

Due to multiple calls to the ```Process``` method, we had to implement ```GenerateMethodName``` in our tracker to avoid duplicate key exceptions, at least we can finally track all of those calls.

```c#
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

Even though we've minimized boilerplate to just one ```using``` statement, we still need to consider when to log our results. It's possible that ```Solution``` is not the last method executed in the script, meaning if we log results at the end of it, we might miss performance data gathered afterward. We need to ensure that logging occurs only when all trackers are completed and disposed of, and that it happens automatically.

To address the this issue, we need to expand our collector logic, as a dictionary alone will not suffice. We'll create a new class that implements ```IDisposable``` and tracks how many trackers are currently active. Only when the last tracker finishes collecting performance metrics will we log the results.

```c#
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

Here, we’ve made the ```Collector``` instance is a static object to keep it simple.

> [!NOTE] 
> Please ignore the poor design—what matters most here is the big picture.

```c#
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

This now looks like something we can be proud of. The only addition compared to the original implementation is the ```using``` statement. However, I'd like to emphasize the word **looks**, because in reality, there are several scenarios where this implementation falls short. 
For example:
 - Just having the method name and execution time provides limited insight.
 - Methods are inherently nested, but our logs are not. How will we know where a method is called from?
 - What if we want to save the results somewhere other than a log file?
 - As the size of the data increases, it's expected for processing time to rise, but we can't track if the data size changes.
 - How will this implementation behave in multithreaded environments?
 - How can we visualize the data effectively? Scrolling endlessly through logs is far from ideal.
 
Let's see how the **Performance Analyzer** can help with these, and many other, challenges. The underlying logic of the **Performance Analyzer** is identical to what we've demonstrated so far; the only difference lies in the implementation details. Thanks to abstraction—one of the key pillars of OOP (yes, I snuck this in here)—these details won't impact how we use the solution.

The key difference between our implementation and the **Performance Analyzer** is that we need to provide the ```PerformanceCollector``` with an instance of an object that implements the ```IPerformanceLogger``` interface. This gives us the flexibility to report metrics in various ways. The library provides a default implementation called ```PerformanceFileLogger```, which logs metrics to a file.

```c#
public static IPerformanceLogger Logger { get; set; } = new PerformanceFileLogger("results");

public static PerformanceCollector Collector { get; set; } = new PerformanceCollector(Logger);

public static void Connect()
{
  using (new PerformanceTracker(Collector))
  {
    Thread.Sleep(100);
  }
}
```

By default, the file, *results.json* in this case, will be created at *C:\Skyline_Data\PerformanceLogger*.

```c#
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

> [!NOTE]
> The [repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.PerformanceAnalyzer) is open source, pull requests are welcome.

```IPerformanceLogger``` defines a single method: ```Report(List<PerformanceData>)```. But what is ```PerformanceData```? ```PerformanceData``` represents each method being tracked. It includes details such as the name of the class the method belongs to, the method's name, start and execution times, as well as metadata. This already provides much more information than a simple dictionary could, but there's more (every infomercial ever): ```PerformanceData``` also contains a list of sub-methods, allowing us to represent the nesting of method calls. This means that in the results, we can determine exactly where each method was called. 
Even when executing the same code repeatedly, not all executions are identical. The amount of data may vary, the type of data could differ, or the server's state might change. All these factors can impact performance, and without the right context, understanding the metrics can be challenging. It would be ideal if we could include context in our results—and, as you might have guessed, we can do this using metadata.
Metadata can be defined either on the ```PerformanceFileLogger``` or on the ```PerformanceTracker```. Metadata at the logger level can be used to provide context for the overall script execution, while metadata at the tracker level can add context for specific method calls.

```c#
public static IPerformanceLogger Logger { get; set; } = new PerformanceFileLogger("results").AddMetadata("Server", GetServer());

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

Adding context helps us interpret the results accurately—yay! But what if data processing can happen in parallel? How does the **Performance Analyzer** handle multithreaded environments? Generally, the **Performance Analyzer** is environment-agnostic. However, there's one caveat: in multithreaded scenarios, we need to handle nesting explicitly. This means we must define the parent tracker by passing it to the constructor of the tracker running on a separate thread.

```c#
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

> [!IMPORTANT]
> Although this isn't an issue here since Parallel.ForEach is a blocking call, it's crucial to wait for all tracked threads to complete before disposing of the parent tracker. Otherwise, the results may not be as expected.

> [!NOTE]
> More examples can be found in the ReadMe file of the [repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.PerformanceAnalyzer).