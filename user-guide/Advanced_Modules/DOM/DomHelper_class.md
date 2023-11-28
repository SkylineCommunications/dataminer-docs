---
uid: DomHelper_class
---

# DomHelper class

## CRUD methods

The `DomHelper` class can be used in a script, protocol, or app to execute create, read, update, and delete (CRUD) actions on DOM objects.

To do so, first call the constructor of the helper, provide a callback to SLNet, and specify a module ID for which module settings have been defined. For example:

```csharp
var helper = new DomHelper(engine.SendSLNetMessages, "a_module_id");
```

> [!NOTE]
> You will need to add the `using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;` statement to include the helper class.

You can then call the *Create*, *Read*, *Update*, or *Delete* methods on the CRUD helper components of the helper.

> [!NOTE]
> When multiple `DomInstances` need processing, from DataMiner 10.4.2 onwards [calls are available](xref:DomHelper_class#multiple-instances) to do so in one go.

For example:

```csharp
// Create a DomDefinition
var domDefinition = new DomDefinition("DomDefinitionName");
helper.DomDefinitions.Create(domDefinition);
```

By default, an exception will be thrown if a call fails. However, you can disable this and check if something went wrong yourself by requesting the `TraceData` object of the last call. This object contains all errors and warnings. For example:

```csharp
// Disable the exceptions
helper.DomInstances.ThrowExceptionsOnErrorData = false;

// Do a call
helper.DomInstances.Create(domInstance);

// Get the TraceData and check if the last call succeeded
var traceData = helper.DomInstances.GetTraceDataLastCall();
if (!traceData.HasSucceeded())
{
    // Something went wrong, retrieve all DomInstance errors
    var errors = traceData.GetErrorDataOfType<DomInstanceError>();
    foreach (var error in errors)
    {
        // Do something with the error, e.g. log it
        engine.GenerateInformation($"Error reason: {error.ErrorReason}");
    }

    // You can also just log the complete TraceData object,
    // this will clearly show the errors, reasons and extra info
    engine.GenerateInformation(traceData.ToString());
}
```

### Multiple instances

When multiple `DomInstances` need to get create, updated or deleted, it's recommended to call the *CreateOrUpdate* or *Delete* methods on a `DomInstance` CRUD helper component, with a list of those `DomInstances`. This feature is available from DataMiner 10.4.2 onwards. More information and best practices on how to use these calls is available [in these examples](xref:DOM_BulkProcessing_Example).

When the operation fails for one of the `DomInstances`, the result of those calls will contain the necessary information.
When calling `CreateOrUpdate`, the result will contain a list of `DomInstance` that were successfully created or updated. The trace data is available per token ID.
When calling `Delete` with a list of `DomInstances`, the result will contain a list of `DomInstance` IDs that were successfully deleted. Also here the trace data is available per token ID.

If an issue occurs when any item gets created or updated or deleted (e.g. validation), no exception will be thrown (even when `ThrowExceptionsOnErrorData` is true). The result of the call can used to check for which `DomInstances` the call failed. Next to that the trace data of that call is available and will contain the trace data for all processed `DomInstances`.

If however the entire operation would fail (e.g. when the storage layer would fail while storing the data) a `CrudFailedException` is thrown. If, in that case, `ThrowExceptionsOnErrorData` was set to false a `DataMinerException` will be thrown instead and the `TraceData` of the last call should be checked to get more details about the issue.

#### Maximum amount

Since these calls might trigger related actions (such as launching script actions), it might cause a high load on the system when a lot of instances are involved. A soft limit of 100 `DomInstances` is set, to make sure those bulk operations are implemented with scalability in mind. When a higher amount of instances should be processed, consider splitting those up in batches.

The maximum amount of items allowed on to the `CreateOrUpdate` or `Delete` calls, is available in the `MaxAmountBulkOperation` property on a `DomInstance` CRUD helper component. If a larger amount was provided the calls will fail with a `DomInstanceCrudMaxAmountExceededArgumentException` and it's message will state how many items were provided.

## Special methods

In addition to the CRUD methods, the following special methods are also supported on a `DomInstance` CRUD helper component:

- DoStatusTransition: Used to transition a `DomInstance` from one status to another. See [DOM status system](xref:DOM_status_system).

- ExecuteAction: Used to execute an action in the context of a `DomInstance` that was defined on a `DomBehaviorDefinition`. See [DOM actions](xref:DOM_actions).

## Stitching

The stitching functionality makes it easier to work with a `DomInstance`. With this, there is no need to use the helper each time and retrieve the linked objects using an ID filter. When a `DomInstance` is stitched, it is possible to:

- Retrieve the full `DomDefinition` object that the `DomInstance` is linked to, by calling `GetDomDefinition()` on the instance.
- Retrieve the full `SectionDefinition` object that a `Section` is linked to, by calling `GetSectionDefinition()` on the `Section`
- Retrieve the full `FieldDescriptor` object that a `FieldValue` is linked to, by calling `GetFieldDescriptor()` on the `FieldValue`.

> [!NOTE]
> When an item is not stitched, and one of the above-mentioned get methods is called (e.g. GetDomDefinition), an exception will be thrown.

There are two ways to stitch DOM instances:

- `DomHelper.StitchDomInstances(List<DomInstance> domInstances)`: This will stitch the given list of `DomInstances` by retrieving all objects from the server using the SLNet callback on the helper.

- `DomHelper.StitchDomInstances(List<DomInstance> domInstances, List<SectionDefinition> existingSectionDefinitions, List<DomDefinition> existingDomDefinitions)`: This will stitch the given list of `DomInstances` by trying to retrieve the other objects from the given lists. This is a more efficient option when you already have all necessary objects.

> [!NOTE]
> If stitching is used and an object cannot be found, a null value will be assigned to the related property. The `DomInstance` will still be marked as stitched. This way, when that property is retrieved, you can know it is not available.
>
> For example: If the second of the two methods above is used, but the provided `existingDomDefinitions` list is empty, the stitching logic will not be able to find the `DomDefinition` object linked to the instance. When you try to retrieve the `DomDefinition` using the `DomInstance.GetDomDefinition()` method, "null" will be returned.

## Attachments

From DataMiner 10.1.3/10.2.0 onwards, it is possible to save attachments with the `DomHelper`. These are linked to a `DomInstanceId`. You can use the `Attachments` helper on the `DomInstance` CRUD component.

```csharp
var domHelper = new DomHelper(engine.SendSLNetMessages, PermissionTestModuleId);
var fileBytes = File.ReadAllBytes("C:\MyDocuments\ImportantDocument.txt");

// Adding an attachment
domHelper.DomInstances.Attachments.Add(domInstanceId, "ImportantDocument.txt", fileBytes);

// Get the names of all attachments
List<string> fileNames = domHelper.DomInstances.Attachments.GetFileNames(domInstanceId);

// Get the content of an attachment
byte[] file = domHelper.DomInstances.Attachments.Get(domInstanceId, "ImportantDocument.txt");

// Delete an attachment
domHelper.DomInstances.Attachments.Delete(domInstanceId, "ImportantDocument.txt");
```

> [!NOTE]
>
> - The size limit of the attachments is determined by the [Documents.MaxSize](xref:MaintenanceSettings_xml#documentsmaxsize) setting in *MaintenanceSettings.xml*. The default value for this is 20 MB. Trying to upload a larger file using the helper will result in a `DataMinerException`.
> - Deleting a `DomInstance` will delete all attachments from the file system. The attachments cannot be recovered.
> - To view or download `DomInstance` attachments, read permission is required, and to add or edit them, edit permission is required.
> - To include `DomInstance` attachments in a [custom backup](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups) in Cube, select *All documents located on this DMA*.
> - The attachments are synced in the DMS.
