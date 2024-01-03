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

For some of the `DomInstances`, the creation or updating might not succeed. In this example, the number of `DomInstances` that fails is logged, together with the issues that occurred. Next, the number of `DomInstances` that succeed gets logged.

Like in the previous example, some `DomInstances` need to be updated:

```csharp
// Update the DomInstances.

// Save them to the DB.
var updateResult = domHelper.DomInstances.CreateOrUpdate(domInstances);

// Check if some of the updates are not successful.
if (updateResult.HasFailures())
{
  // Log the number of DomInstances that was not updated.
  // Also log the `TraceData` for all failing `DomInstances`. The `TraceData` contains all errors and warnings.
  Log($"Could not perform the update for {updateResult.UnsuccessfulIds.Count} items: {updateResult.GetTraceData()}");
  return;
}

// Log what items were successfully removed.
Log($"Could perform the update successfully for {updateResult.SuccessfulItems.Count} items");
```

The result returned by `CreateOrUpdate` contains `SuccessfulItems` and `SuccessfulIds` to reuse or check the `DomInstances` that are successfully created or updated. The IDs of the items that did not succeed are available in `UnsuccessfulIds`.

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

In case a `CreateOrUpdate` or a `Delete` call are unsuccessful, for instance because of a database issue, by default a `CrudFailedException` will be thrown. Details of the issue will be available in the `TraceData` of that exception.

In the following example, some `DomInstances` need to be deleted:

```csharp
try
{
  // Remove them from the DB.
  var deleteResult = domHelper.DomInstances.Delete(domInstances);

  // Check if some of the deletes are not successful.
  if (deleteResult.HasFailures())
  {
    // Log the number of DomInstances that did not get removed.
    // Also log the `TraceData` for all failing `DomInstances`. The `TraceData` contains all errors and warnings.
    Log($"Could not perform the delete for {deleteResult.UnsuccessfulIds.Count} items: {deleteResult.GetTraceData()}");
    return;
  }

  // Log what items are successfully removed.
  Log($"Successfully removed {deleteResult.SuccessfulIds.Count} items");
}
catch (CrudFailedException ex)
{
  // Log the issue that occurs.
  Log($"Cannot perform the removal, because of the following issue: {ex.TraceData}");
}
```

It is also possible to disable this and check if something went wrong yourself by requesting the `TraceData` object of the last call.

```csharp
// Disable the exceptions.
domHelper.DomInstances.ThrowExceptionsOnErrorData = false;

// Remove them from the DB.
var deleteResult = domHelper.DomInstances.Delete(domInstances);

// Check if a result is available.
if (deleteResult == null)
{
  // Get the TraceData and check if the last call succeeded.
  var traceData = domHelper.DomInstances.GetTraceDataLastCall();

  // Log the issue that occurs.
  Log($"An unexpected issue occurred during the removal, because of the following issue: {traceData}");
  return;
}

// Check if some of the deletes are not successful.
if (deleteResult.HasFailures())
{
  // Log the number of DomInstances that did not get removed.
  // Also log the `TraceData` for all failing `DomInstances`. The `TraceData` contains all errors and warnings.
  Log($"Could not perform the delete for {deleteResult.UnsuccessfulIds.Count} items: {deleteResult.GetTraceData()}");
  return;
}

// Log what items are successfully removed.
Log($"Successfully removed {deleteResult.SuccessfulIds.Count} items");
```
