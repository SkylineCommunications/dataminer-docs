---
uid: DOM_BulkProcessing_Example
---

# Processing multiple DomInstances — examples

From DataMiner 10.4.2/10.5.0 onwards<!-- RN 37891 -->, the `DomInstance` CRUD helper component supports processing multiple `DomInstances` in one call.

This page contains examples on how you can use these calls, provided by the [DomHelper](xref:DomHelper_class#multiple-instances).

## Creating multiple DomInstances

In this example, two `DomInstances` get created.

```csharp
// Instantiate a new DomInstance & assign 'Hello' as a value.
var domInstanceOne = new DomInstance() { DomDefinitionId = domDefinitionId };
domInstanceOne.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, "Hello");

// Instantiate a new DomInstance & assign 'World' as a value.
var domInstanceTwo = new DomInstance() { DomDefinitionId = domDefinitionId };
domInstanceOne.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, "World");

// Save them to the DB.
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

// Save them to the DB.
domHelper.DomInstances.CreateOrUpdate(domInstances);
```

### Checking issues

For some of the `DomInstances`, the creation or update might not succeed. When using `CreateOrUpdate` or `Delete`, an exception will be thrown. That exception will include how many items succeeded and how many items failed for that bulk CRUD operation. Next to that a limited list of object IDs that succeeded is added. Also a list of object IDs that failed, each followed by the related TraceData. After that the default exception info gets added, including the stacktrace.

Like in the previous example, some `DomInstances` need to be updated:

```csharp
try
{
  // Update the DomInstances.

  // Save them to the DB.
  var updateResult = domHelper.DomInstances.CreateOrUpdate(domInstances);

  // Log what items were successfully updated.
  Log($"Could perform the update successfully for {updateResult.SuccessfulItems.Count} items");
}
catch(Exception e)
{
  // Log that the operation failed and use info included in the exception for a generic message of what failed.
  Log($"An unexpected issue occurred while updating: {e}");
}
```

To more easily get the details for which items the operation failed or succeeded, `TryCreateOrUpdate` or `TryDelete` can be used. In this example using `TryCreateOrUpdate`, the number of `DomInstances` that fails is logged, together with the issues that occurred. Next, the number of `DomInstances` that succeed gets logged.

```csharp
// Update the DomInstances.

// Save them to the DB.
var updateSucceeded = domHelper.DomInstances.TryCreateOrUpdate(domInstances, out var updateResult);

// Check if some of the updates are not successful.
if (!updateSucceeded && updateResult != null)
{
  // Log the number of DomInstances that was not updated.
  // Also log the TraceData for all failing DomInstances. The TraceData contains all errors and warnings.
  Log($"Could not perform the update for {updateResult.UnsuccessfulIds.Count} items: {updateResult.GetTraceData()}");
  return;
}

// Log what items were successfully removed.
Log($"Could perform the update successfully for {updateResult?.SuccessfulItems.Count ?? 0} items");
```

The result that `TryCreateOrUpdate` outputs contains `SuccessfulItems` and `SuccessfulIds` to reuse or check the `DomInstances` that are successfully created or updated. The IDs of the items that did not succeed are available in `UnsuccessfulIds`.

In addition to a summarized logging using `GetTraceData()`, `TraceDataPerItem` can be used to check for errors and warnings per `DomInstanceId`.

## Remove multiple DomInstances

In this example, some `DomInstances` get filtered out to be removed.

```csharp
// Retrieve the DomInstances that need to get deleted.
var domInstances = domHelper.DomInstances.Read(filter);

// Remove them from the DB.
var deleteResult = domHelper.DomInstances.Delete(domInstances);
```

Similar to the [previous example](xref:DOM_BulkProcessing_Example#checking-issues), it is possible to get `UnsuccessfulIds` and `TraceDataPerItem` and to call `HasFailures()` and `GetTraceData()` using the `deleteResult` to log any failures that occurred. However, the `deleteResult` only contains the `SuccessfulIds`.

## Unexpected issue

In case `CreateOrUpdate` or `Delete` calls are completely unsuccessful, for instance because of a database issue, by default a `CrudFailedException` will be thrown. Details of the issue will be available in the `TraceData` of that exception.

If the same happens when `TryCreateOrUpdate` or `TryDelete` are used, the methods will return false and the result parameter will be null. `GetTraceDataLastCall()` should be used to get the issue that occurred.

In the following example, some `DomInstances` need to be deleted:

```csharp
// Remove them from the DB.
var deleteSucceeded = domHelper.DomInstances.TryDelete(domInstances, out var deleteResult);

// Check if some of the deletes are not successful.
if (!deleteSucceeded && deleteResult != null)
{
  // Log the number of DomInstances that did not get removed.
  // Also log the `TraceData` for all failing `DomInstances`. The `TraceData` contains all errors and warnings.
  Log($"Could not perform the delete for {deleteResult.UnsuccessfulIds.Count} items: {deleteResult.GetTraceData()}");
  return;
}

if (!deleteSucceeded)
{
  // Log the issue that occurs.
  var traceData = domHelper.DomInstances.GetTraceDataLastCall();
  Log($"Cannot perform the removal, because of the following issue: {traceData}");
  return;
}

// Log what items are successfully removed.
Log($"Successfully removed {deleteResult.SuccessfulIds.Count} items");
```
