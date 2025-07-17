---
uid: DOM_BulkProcessing_Examples
---

# Processing multiple DomInstances - examples

From DataMiner 10.4.2/10.5.0 onwards<!-- RN 37891 -->, the `DomInstance` CRUD helper component supports processing multiple `DomInstances` in one call.

In DataMiner 10.5.0/10.5.2<!-- RN 41546 -->, the error handling has been reviewed. Below you will find examples on how you can use these calls, provided by the [DomHelper](xref:DomHelper_class#multiple-instances).

> [!IMPORTANT]
> In DataMiner versions prior to DataMiner Feature Release 10.5.0/10.5.2<!-- RN 41546 -->, when any validation issue occurs, no exception is thrown when calling the `CreateOrUpdate` or `Delete` methods. Instead, the result of the call should be used to check for which `DomInstances` the call succeeded or failed. The `TryCreateOrUpdate` or `TryDelete` methods are not yet available in those versions.

## Creating multiple DomInstances

In this example, two `DomInstances` get created.

```csharp
// Instantiate a new DomInstance and assign 'Hello' as a value.
var domInstanceOne = new DomInstance() { DomDefinitionId = domDefinitionId };
domInstanceOne.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, "Hello");

// Instantiate a new DomInstance and assign 'World' as a value.
var domInstanceTwo = new DomInstance() { DomDefinitionId = domDefinitionId };
domInstanceOne.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, "World");

// Save them to the database.
var domInstances = new List<DomInstance> { domInstanceOne, domInstanceTwo };
domHelper.DomInstances.CreateOrUpdate(domInstances);
```

## Updating a value for multiple DomInstances

In this example, a field gets updated on multiple `DomInstances`.

```csharp
// Retrieve the DomInstances that need processing.
var domInstances = domHelper.DomInstances.Read(filter);

// Update the field value on those DomInstances.
foreach(var domInstance in domInstances)
{
  domInstance.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, newValue);
}

// Save them to the database.
domHelper.DomInstances.CreateOrUpdate(domInstances);
```

### Checking issues

For some of the `DomInstances`, the creation or update might not succeed. When `CreateOrUpdate` or `Delete` is used, an exception will be thrown. Like in the previous example, some `DomInstances` need to be updated:

```csharp
try
{
  // Update the DomInstances in a way similar to the example above.

  // Save them to the database.
  var updateResult = domHelper.DomInstances.CreateOrUpdate(domInstances);

  // Log which items were successfully updated.
  Log($"Could perform the update successfully for {updateResult.SuccessfulItems.Count} items");
}
catch(Exception e)
{
  // Log that the operation failed and use info included in the exception for a generic message of what failed.
  Log($"An unexpected issue occurred while updating: {e}");
}
```

In the example above, the validation done by `CreateOrUpdate` could fail for some of the `DomInstances`. In that case the exception that gets logged will include the following:

- How many items succeeded and how many items failed for that bulk CRUD operation.

- A limited list of object IDs that succeeded.

- A list of object IDs that failed, each followed by the related TraceData.

- The default info about the exception, including the stacktrace.

To more easily get the details for the items for which the operation failed or succeeded, `TryCreateOrUpdate` or `TryDelete` can be used. In the example below using `TryCreateOrUpdate`, the number of `DomInstances` that fail is logged, together with the issues that occurred. Next, the number of `DomInstances` that succeed gets logged.

> [!IMPORTANT]
> In case `CreateOrUpdate` or `Delete` are completely unsuccessful, for instance because of a database issue, by default a `CrudFailedException` will be thrown. The details of the issue will be available in the `TraceData` of that exception, which will be included when that exception gets logged.

```csharp
// Update the DomInstances.

// Save them to the database.
var updateSucceeded = domHelper.DomInstances.TryCreateOrUpdate(domInstances, out var updateResult);

if (updateResult)
{
  // Log which items were successfully removed.
  Log($"Could perform the update successfully for {updateResult.SuccessfulItems.Count} items");
}
else
{
  if (updateResult != null)
  {
    // Log the number of DomInstances that were not updated.
    // Also log the TraceData for all failing DomInstances. The TraceData contains all errors and warnings.
    Log($"Could not perform the update for {updateResult.UnsuccessfulIds.Count} items: {updateResult.GetTraceData()}");
  }
  else
  {
    // No updateResult is available because the complete request failed.
    // Log the issue that occurs.
    var traceData = domHelper.DomInstances.GetTraceDataLastCall();
    Log($"Could not perform the update because of the following issue: {traceData}");
  }
}
```

The result that `TryCreateOrUpdate` outputs contains `SuccessfulItems` and `SuccessfulIds` to reuse or check the `DomInstances` that are successfully created or updated. The IDs of the items that did not succeed are available in `UnsuccessfulIds`.

In addition to summarized logging using `GetTraceData()`, `TraceDataPerItem` can be used to check for errors and warnings per `DomInstanceId`.

> [!IMPORTANT]
> In case `TryCreateOrUpdate` or `TryDelete` are completely unsuccessful, for instance because of a database issue, these methods will return false, and the result parameter will be null. You should use `GetTraceDataLastCall()` to identify the issue that occurred, as shown in the example above.

## Remove multiple DomInstances

In this example, some `DomInstances` get filtered out to be removed.

```csharp
// Retrieve the DomInstances that need to get deleted.
var domInstances = domHelper.DomInstances.Read(filter);

// Remove them from the DB.
var deleteResult = domHelper.DomInstances.Delete(domInstances);
```

Similar to the [previous example](#checking-issues), it is possible to get `UnsuccessfulIds` and `TraceDataPerItem` and to call `HasFailures()` and `GetTraceData()` using the `deleteResult` to log any failures that occurred. However, the `deleteResult` only contains the `SuccessfulIds`.
