---
uid: DOM_BulkProcessing_Example
---
# Processing multiple DomInstances - examples

From DataMiner 10.4.2/10.5.0 onwards the `DomInstance` CRUD helper component supports processing multiple `DomInstances` in one call.

This page contains a few examples on how you can use these calls, provided by the [DomHelper](xref:DomHelper_class#multiple-instances).

## Create multiple DomInstances

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

## Update a value for multiple DomInstances

In the following example a field gets updated on multiple `DomInstances`.

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

For some of the `DomInstances` the update might not succeed. In this example the number of `DomInstances` that fails is logged, together with the issues that occurred. Next the number of `DomInstances` that succeeds gets logged.

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
  }

  // Log what items were successfully removed.
  Log($"Could perform the update successfully for {updateResult.SuccessfulItems.Count} items");
  ```

Next to a summarized logging using `GetTraceData()`, `TraceDataPerItem` can be used to check for errors and warnings per `DomInstanceId`.

When multiple `DomInstances` are created or deleted, the issues can be logged the same way.

## Remove multiple DomInstances

In this example, some `DomInstances` get filtered out to be removed.

  ```csharp
  // Retrieve the DomInstances that need to get deleted.
  var domInstances = domHelper.DomInstances.Read(filter);

  // Remove them from the DB.
  var deleteResult = domHelper.DomInstances.Delete(domInstances);
  ```

## Unexpected issue

In case the `Delete` call is unsuccessful because of for instance a database issue, by default a `CrudFailedException` will be thrown. Details of the issue will be available in the `TraceData` of that exception.

  ```csharp
  try
  {
      // Remove them from the DB.
      var deleteResult = domHelper.DomInstances.Delete(domInstances);

      // Log what items are successfully removed.
      Log($"Successfully removed {deleteResult.SuccessfulIds.Count} items");
  }
  catch (CrudFailedException ex)
  {
      // Log the issue that occurs.
      Log($"Cannot perform the removal, because of the following issue: {ex.TraceData}");
  }
  ```

You can however disable this and check if something went wrong yourself by requesting the `TraceData` object of the last call.

  ```csharp
  // Disable the exceptions.
  domHelper.DomInstances.ThrowExceptionsOnErrorData = false;

  // Remove them from the DB.
  var deleteResult = domHelper.DomInstances.DomInstances.Delete(domInstances);

  // Check if a result is available.
  if (deleteResult != null)
  {
    // Log what items are successfully removed.
    Log($"Successfully removed {deleteResult.SuccessfulIds.Count} items");
    return;
  }
  
  // Get the TraceData and check if the last call succeeded.
  var traceData = domHelper.DomInstances.GetTraceDataLastCall();
  if (!traceData.HasSucceeded())
  {
    // Log the issue that occurs.
    Log($"Cannot perform the removal, because of the following issue: {traceData}");
  }
  ```
