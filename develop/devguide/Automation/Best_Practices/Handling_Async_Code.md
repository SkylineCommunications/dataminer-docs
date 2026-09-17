---
uid: Handling_Async_Code
---

# Handling async code

The automation script entry point is synchronous: use `void Run(IEngine engine)`. Do not make the entry point `async`, and do not move Engine work to a background thread.

> [!IMPORTANT]
> The `IEngine` object, and every object you obtain through it (such as `Element` objects returned by `engine.FindElement`, dummies, and their parameters), is **not thread-safe**. It may only be used from the single thread on which `Run(IEngine engine)` executes.
>
> This applies even when the work you offload is fully synchronous. Dispatching Engine calls to other threads (for example with `Task.Run`, `Parallel.For`, or a manually started `Thread`) and using the Engine or its objects from more than one thread at a time can corrupt the Automation subsystem's internal state and crash the process (`SLAutomation`). Keep all interaction with the Engine and its objects on the script's entry-point thread.

If an external library only exposes an async method, call it synchronously from the entry-point thread. Do not pass the Engine object or objects obtained from it into the asynchronous operation.

```cs
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Skyline.DataMiner.Automation;

public class Script
{
  public void Run(IEngine engine)
  {
    string url = "https://jsonplaceholder.typicode.com/todos/1"; // Example API
    string result = GetDataSync(url);
    engine.Log(result);
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
