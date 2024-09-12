---
uid: Exception_Handling
---

# Exception Handling

Add exception Handling to your C# classes.
Surround important code with try catches and log the errors that occur. Make sure to add any information that might be useful for debugging. ( For example, add the iteration number if you're dealing with a for loop. Add the trigger ID when a QA has multiple triggers.)

```csharp
try
{
    // Code Here
}
catch (Exception ex)
{
    protocol.Log("QA" + protocol.QActionID + "|MethodName|Exception thrown while trying to XXXXX" + Environment.NewLine + ex, LogType.Error, LogLevel.NoLogging);
} 
```
