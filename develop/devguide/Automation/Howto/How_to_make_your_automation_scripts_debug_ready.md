---
metadata_version: 1
uid: How_to_make_your_automation_scripts_debug_ready
description: "Describe the DataMiner Automation development topic Making your automation scripts debug-ready, including its purpose, behavior, implementation guidance."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Making your automation scripts debug-ready

While you are working on automation scripts, exceptions can be thrown because of all kinds of valid reasons: executing actions on a variable that is not initialized, methods that are not yet fully implemented, etc.

By default, automation scripts do not show the stack trace you may expect when an exception occurs. To help you save precious time when debugging, below we will explain how you can make sure that exceptions are handled correctly from the very start.

## Example of default behavior

The following code will result in an exception being thrown:

```csharp
/// <summary>
/// DataMiner Script Class.
/// </summary>
class Script
{
    /// <summary>
    /// The Script entry point.
    /// </summary>
    /// <param name="engine">Link with SLAutomation process.</param>
    public void Run(IEngine engine)
    {
        CustomClass myCustomClass = InitCustomClass();
        LogStringValue(engine, myCustomClass);
    }
    private void LogStringValue(IEngine engine, CustomClass customClass)
    {
        engine.Log(customClass.StringValue);
    }
    private CustomClass InitCustomClass()
    {
        return null;
    }
}
public class CustomClass
{
    public string StringValue { get; set; }
    public double DoubleValue { get; set; }
}
```

Because of the exception, the following pop-up window will be shown:

![Script debug failed](~/develop/images/script_debug_failed.png)

In the Automation log file, you will find the following entries:

```txt
2021/09/21 15:11:16.877|SLAutomation.exe 10.1.2132.1478|16988|9368|CSharp|DBG|-1|(Script Debug/1) System.NullReferenceException: Object reference not set to an instance of an object.
   at CManagedAutomation.RunWrapped(CManagedAutomation* , Int32 iCookie, IUnknown* pIAutomation, tagVARIANT* varParameters, tagVARIANT* pvarReturn, String scriptName)
   at CManagedAutomation.Run(CManagedAutomation* , Int32 iCookie, Char* bstrScriptName, IUnknown* pIAutomation, tagVARIANT* varParameters, tagVARIANT* varEntryPoint, tagVARIANT* pvarReturn) (CSharp; 0x80004005h):
```

This only shows that the `Run` and `RunWrapped` methods are executed, which is internal DataMiner logic.

## Making exceptions meaningful

You can make the exception more meaningful by adding a try-catch as shown below.

```csharp
public void Run(IEngine engine)
{
    try
    {
        RunSafe(engine);
    }
    catch (ScriptAbortException)
    {
        throw;
    }
    catch (ScriptForceAbortException)
    {
        throw;
    }
    catch (ScriptTimeoutException)
    {
        throw;
    }
    catch (InteractiveUserDetachedException)
    {
        throw;
    }
    catch (Exception ex)
    {
        engine.Log(ex.ToString());
        engine.ExitFail("The script failed. See the Automation log for details.");
    }
}
private void RunSafe(IEngine engine)
{
    CustomClass myCustomClass = InitCustomClass();
    LogStringValue(engine, myCustomClass);
}
```

The pop-up window will just show what went wrong:

![Script debug failed](~/develop/images/script_debug_failed2.png)

However, the logging will contain the full stack trace that you need for debugging:

```txt
2021/09/21 15:23:52.915|SLAutomation.exe 10.1.2132.1478|16988|6768|Script|INF|-1|[Jens Vandewalle] (Script Debug) Log Message: "System.NullReferenceException: Object reference not set to an instance of an object.
   at Script.LogStringValue(IEngine engine, CustomClass customClass)
   at Script.RunSafe(IEngine engine)
   at Script.Run(IEngine engine)"
```
