---
uid: DOM_BulkProcessing_Example
---
# Processing multiple DomInstances - examples

From DataMiner 10.4.2/10.5.0 onwards the `DomInstance` CRUD helper component supports processing multiple `DomInstances` in one call.

This page contains simple examples of how you can use these calls, provided by the [DomHelper](xref:DomHelper_class#multiple-instances).

## Update a value for multiple DomInstances

In the following example the *Type* field of some `DomInstances` needs to be updated. The update for some of them might not succeed. For instance: the *type* `FieldDescriptor` might not be allowed for the status that *DomInstance* is in, or the `SectionDefinition` might not be supported for that *DomInstance*.

For the `DomInstances` that fail, their name and the issue will be logged in this example.

  ```csharp
  // Retrieve the DomInstances that need processing.
  var domInstances = domHelper.DomInstances.Read(filter);

  // Update the field value on those DomInstances.
  foreach(var domInstance in domInstances)
  {
      domInstance.AddOrUpdateFieldValue<int>(sectionDefinitionId, fieldDescriptorId, newType);
  }

  // Save them to the DB.
  var updateResult = domHelper.DomInstances.CreateOrUpdate(domInstances);

  // Log what items were successfully removed.
  Log($"The new type was successfully set on {updateResult.SuccessfulItems.Count} items");

  // Log that some updates are not successful. Per DomInstance, check how the issue occurred.
  var incorrectInstances = updateResult.TraceDataPerItem.Where(x => !x.Value.HasSucceeded()).ToList();
  if (incorrectInstances.Count > 0)
  {
      var issues = incorrectInstances.Select(x => $"{domInstances.FirstOrDefault(y => x.Equals(y.ID))?.Name}: {x.Value}");
      Log($"The type could not be updated for {incorrectInstances.Count} items: {string.Join(Environment.NewLine, issues)}");
  }
  ```

## Create multiple DomInstances

In this example, two `DomInstances` get created. The second `DomInstance` will be created using a `FieldDescriptor` that no longer is supported for the initial state it gets created in.

In this example, the `TraceData` will be logged. Depending on the issue that occurs, the ID of the `DomInstance` might be included in the error.

  ```csharp
  // Instantiate a new DomInstance & assign 'Hello' as a value for a correct FieldDescriptor.
  var domInstanceOne = new DomInstance() { DomDefinitionId = basicDomDefinitionId };
  domInstanceOne.AddOrUpdateFieldValue<string>(sectionDefinitionId, fieldDescriptorId, "Hello");

  // Instantiate a new DomInstance & assign 'World' as a value for a FieldDescriptor no longer supported for the initial state.
  var domInstanceTwo = new DomInstance() { DomDefinitionId = advancedDomDefinitionId };
  domInstanceTwo.AddOrUpdateFieldValue<string>(sectionDefinitionId, incorrectFieldDescriptorId, "World");

  // Save them to the DB.
  var domInstances = new List<DomInstance> { domInstanceOne, domInstanceTwo };
  domHelper.DomInstances.CreateOrUpdate(domInstances);

  // Log if an issue occurs.
  var traceData = domHelper.DomInstances.GetTraceDataLastCall();
  if (!traceData.HasSucceeded())
  {
      Log($"Some of the instances could not be created: {traceData}");
  }
  ```

## Remove multiple DomInstances

In this example, some `DomInstances` get filtered out to be removed.

If, for example, the user executing this example is not allowed to remove them, it will be logged for each `DomInstance`.
In case the `Read` or `Delete` call is unsuccessful because of a database issue, a `CrudFailedException` will be thrown. Details of the issue will be available in the `TraceData` of that exception.

  ```csharp
  try
  {
      // Retrieve the DomInstances that need to get deleted.
      var domInstances = domHelper.DomInstances.Read(filter);

      // Remove them from the DB.
      var deleteResult = domHelper.DomInstances.Delete(domInstances);

      // Log what items are successfully removed.
      Log($"Successfully removed {deleteResult.SuccessfulIds.Count} items");

      // Log that some deletes are not successful. Per DomInstance check which issue occurs.
      var incorrectInstances = deleteResult.TraceDataPerItem.Where(x => !x.Value.HasSucceeded()).ToList();
      if (incorrectInstances.Count > 0)
      {
          var issues = incorrectInstances.Select(x => $"{domInstances.FirstOrDefault(y => x.Equals(y.ID))?.Name}: {x.Value}");
          Log($"Unable to remove {incorrectInstances.Count} items: {string.Join(Environment.NewLine, issues)}");
      }
  }
  catch (CrudFailedException ex)
  {
      // Log the issue that occurs.
      Log($"Unable to perform the removal, the following error occurred: {ex.TraceData}");
  }
  ```
