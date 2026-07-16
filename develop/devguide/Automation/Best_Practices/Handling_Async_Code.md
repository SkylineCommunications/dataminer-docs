---
uid: Handling_Async_Code
---

# Handling async code

In automation scripts, async methods **should not be used**, and all code should execute on the same thread. If an external library contains async methods, they must be executed synchronously to maintain script stability.

> [!IMPORTANT]
> The `Engine` object, and every object you obtain through it (such as `Element` objects returned by `engine.FindElement`, dummies, and their parameters), is **not thread-safe**. It may only be used from the single thread on which `Run(Engine engine)` executes.
>
> This applies even when the work you offload is fully synchronous. Dispatching Engine calls to other threads (for example with `Task.Run`, `Parallel.For`, or a manually started `Thread`) and using the Engine or its objects from more than one thread at a time can corrupt the Automation subsystem's internal state and crash the process (`SLAutomation`). Keep all interaction with the Engine and its objects on the script's main thread.

To properly call an async method from an external library, use the following approach:

```cs
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Skyline.DataMiner.Automation;

public class Script
{
  public void Run(Engine engine)
  {
    string url = "https://jsonplaceholder.typicode.com/todos/1"; // Example API
    string result = GetDataSync(url);
    engine.GenerateInformation(result);
  }

  public static string GetDataSync(string url)
  {
    using (HttpClient client = new HttpClient())
    {
      return client.GetStringAsync(url).GetAwaiter().GetResult(); // Synchronous execution
    }
  }
}
```
