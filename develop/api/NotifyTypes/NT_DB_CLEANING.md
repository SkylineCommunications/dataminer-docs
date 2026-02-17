---
uid: NT_DB_CLEANING
---

# NT_DB_CLEANING (385)

Enables or disables the database cleaning and forwarding thread in the SLDataMiner process.<!-- RN 8788 -->

```csharp
protocol.NotifyDataMiner(385 /*NT_DB_CLEANING*/, false, null);

//disable the thread
try
{
   //// For example, create a large number of enhanced services.
}
finally
{
   // Enable the thread.
    protocol.NotifyDataMiner(385 /*NT_DB_CLEANING*/, true, null);
}
```

## Parameters

- isEnabled (bool): true=enabled, false=disabled.

## Return Value

- (string[]) Primary keys of the table. In case there is no table with the specified ID, a null reference is returned.

## Remarks

- Creating enhanced services, for example, can sometimes take a while because the Database Cleaning and Forwarding thread locks the alarm table. In that case, you can use the NT_DB_CLEANING call to temporarily disable the thread.
- In a QuickAction, remember to always enable the thread in a "finally" block (see example).
