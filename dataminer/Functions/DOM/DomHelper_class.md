---
uid: DomHelper_class
---

# Dom helper class

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
> When multiple `DomInstances` need processing, from DataMiner 10.4.2/10.5.0 onwards<!-- RN 37891 -->, [calls are available](#multiple-instances) to do so for [up to 100 DomInstances](#maximum-number-of-instances) in one go.

For example:

```csharp
// Create a DomDefinition
var domDefinition = new DomDefinition("DomDefinitionName");
helper.DomDefinitions.Create(domDefinition);
```

By default, a `CrudFailedException` will be thrown if a call fails. However, you can disable this and check if something went wrong yourself by requesting the `TraceData` object of the last call. This object contains all errors and warnings. For example:

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

### Reading DOM data

When reading DOM data using the `Read(FilterElement<T>)` methods, you can opt to do a single read or retrieve the results in pages. When there is a chance that a lot of records can be returned, using paging is highly recommended. This ensures that a response is not too large, as large responses can have a negative impact on performance. It also gives you the chance to make a decision in the code to abort the action without having to retrieve all records.

**Read all without paging:**

```csharp
var fieldDescriptorId = new FieldDescriptorID(Guid.Parse("87fd760d-13cd-41f4-85b6-405beb0f777c"));
var filter = DomInstanceExposers.FieldValues.DomInstanceField(fieldDescriptorId).Equal("MyValue");

var allInstances = helper.DomInstances.Read(filter);
```

**Read all with paging:**

```csharp
var pagingHelper = helper.DomInstances.PreparePaging(filter);
var allInstances = pagingHelper.GetAll();
```

**Read page by page:**

```csharp
var pagingHelper = helper.DomInstances.PreparePaging(filter); // Prepare with default page size of 500
while (pagingHelper.MoveToNextPage())
{
    var currentPage = pagingHelper.GetCurrentPage();
    // Handle current page of data...
}
```

Once you have read the `DomInstance`, you can get or alter the field values. See the [examples](xref:DOM_Altering_values_of_a_DomInstance) for more info on how to do this.

> [!TIP]
> When reading multiple `DomInstances` using their IDs, it is more efficient to build one large OR filter and read them in a single call instead of retrieving them one by one. The `Tools.RetrieveBigOrFilter()` helper method is available for this. See [DOM best practices](xref:DOM_best_practices#try-to-limit-the-number-of-crud-calls) for more info.

#### Filtering

To specify which `DomInstances` need to be retrieved from the database, you can build filters using the `FilterElement` structures.

Start a filter by specifying the field you want to filter on using the `DomInstanceExposers` class. Once a field is selected, choose the comparer and provide a value. These filters can then be concatenated with AND and OR conditions.

**Base properties:**

|Field                |Type        |Supported Comparer |
|---------------------|------------|-------------------|
|Id                   |string      |Equal, NotEqual |
|SectionDefinitionIds |List\<Guid> |Contains, NotContains |
|SectionIds           |List\<Guid> |Contains, NotContains |
|DomDefinitionId      |Guid        |Equal, NotEqual |
|Name                 |string      |Equal, NotEqual, Contains, NotContains |
|StatusId             |string      |Equal, NotEqual, Contains, NotContains |
|LastModified         |DateTime    |LessThan, GreaterThan |
|LastModifiedBy       |string      |Equal, NotEqual, Contains, NotContains |
|CreatedAt            |DateTime    |LessThan, GreaterThan |
|CreatedBy            |string      |Equal, NotEqual, Contains, NotContains |

**Fields:**

These are the supported comparers when filtering on `DomInstance` values using the `DomInstanceExposers.FieldValues.DomInstanceField()` exposer.

|Field Type                |Supported Comparer |
|--------------------------|-------------------|
|string                    |Equal, NotEqual, Contains, NotContains |
|double                    |Equal, NotEqual, LessThan, LessThanOrEqual, GreaterThan, GreaterThanOrEqual |
|long                      |Equal, NotEqual, LessThan, LessThanOrEqual, GreaterThan, GreaterThanOrEqual |
|TimeSpan                  |Equal, LessThan*, GreaterThan* |
|Boolean                   |Equal |
|DateTime                  |Equal, NotEqual, LessThan, GreaterThan |
|GenericEnum (int)         |Equal, NotEqual, LessThan, LessThanOrEqual, GreaterThan, GreaterThanOrEqual |
|List GenericEnum (int)    |Contains |
|GenericEnum (string)      |Equal, NotEqual, Contains, NotContains |
|List GenericEnum (string) |Contains |
|Guid                      |Equals, NotEquals |
|List Guid                 |Contains |
|List string               |Contains |

*Only supported for [STaaS](xref:STaaS)

> [!NOTE]
>
> - From DataMiner 10.4.5/10.4.0 [CU2] onwards, `string` filters are handled as case-insensitive when using the OpenSearch database (which is how STaaS has handled `string` reads since its introduction). Prior to DataMiner version 10.4.5/10.4.0 [CU2], `string` filters are handled as case-sensitive.
> - When multiple sections of one `SectionDefinition` are allowed, filtering on a `FieldValue` scoped to a single section is not possible. See [Multiple sections](xref:DOM_MultipleSections#filtering).

**Examples:**

```csharp
var domHelper = new DomHelper(engine.SendSLNetMessages, "vehicles_app");

// DOM instances linked to a specific DOM definition
var domDefinitionId = Guid.Parse("838fbabb-3651-43fb-84ea-568995b4d066"); // Vehicles definition
var definitionFilter = DomInstanceExposers.DomDefinitionId.Equal(domDefinitionId);
var allForDefinition = domHelper.DomInstances.Read(definitionFilter);

// DOM instances in the 'maintenance' status
var statusFilter = DomInstanceExposers.StatusId.Equal("maintenance");
var inMaintenance = domHelper.DomInstances.Read(statusFilter);

// DOM instances updated in the last 24 hours
var lastModifiedFilter = DomInstanceExposers.LastModified.GreaterThan(DateTime.UtcNow.AddHours(-1));
var recentlyModified = domHelper.DomInstances.Read(lastModifiedFilter);

// DOM instances where the value for FieldDescriptor with the given ID equals 'AZN-070'
var fieldDescriptorId = new FieldDescriptorID(Guid.Parse("aa675f01-c841-4572-83c9-b2710f41ea39")); // Car license plate
var valueFilter = DomInstanceExposers.FieldValues.DomInstanceField(fieldDescriptorId).Equal("AZN-070");
var specificCar = domHelper.DomInstances.Read(valueFilter);

// DOM instances matching all of the above using an AND filter
var andFilter = new ANDFilterElement<DomInstance>(definitionFilter, statusFilter, lastModifiedFilter, valueFilter);
var andResult = domHelper.DomInstances.Read(andFilter);

// DOM instances matching any of the above using OR filter 
var orFilter = new ORFilterElement<DomInstance>(definitionFilter, statusFilter, lastModifiedFilter, valueFilter);
var orResult = domHelper.DomInstances.Read(orFilter);

// Combinations of OR and AND filters
orFilter = new ORFilterElement<DomInstance>(lastModifiedFilter, statusFilter, valueFilter);
andFilter = new ANDFilterElement<DomInstance>(definitionFilter, orFilter);
var combinedResult = domHelper.DomInstances.Read(andFilter);
```

> [!NOTE]
> Although, this section explained reading `DomInstances`, the same principles apply to all other DOM objects. Building filters is done using exposer classes and reading is done using the `DomHelper`. For example, for `SectionDefinitions`, this could be `domHelper.SectionDefinitions.Read(SectionDefinitionExposers.Name.Contains("My Name"))`.

> [!IMPORTANT]
> On a DataMiner Agent that is using OpenSearch or Elasticsearch, there is a default limit of 1024 clauses in a query. This means that you can only concatenate a maximum of 1024 field filters using an "OR" filter. If this limit is not sufficient, you can adjust it using the "indices.query.bool.max_clause_count" option in [OpenSearch](https://opensearch.org/docs/latest/install-and-configure/configuring-opensearch/index-settings/) or [Elasticsearch](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/search-settings.html).
>
> For STaaS, there is no such hard limit, but we do recommend keeping the queries short.

> [!IMPORTANT]
> When link security is enabled, the filters used to retrieve `DomInstances` or DOM history need to adhere to certain [filter requirements](xref:DOM_SecuritySettings#filtering-requirements-when-security-is-enabled).

#### Sorting

It is also possible to sort your results based on a specific field of a DOM instance (both core fields and `FieldValues`). This sorting is done in the database, which should result in good performance. To apply this sorting, call the `OrderBy` or `OrderByDescending` methods on a filter. This will return a query object that can be passed to the read method of the helper.

**Examples:**

```csharp
var domHelper = new DomHelper(engine.SendSLNetMessages, "vehicles_app");

// Build a filter
var filter = DomInstanceExposers.StatusId.Equal("maintenance");

// Sort ascending on name
var onNameQuery = filter.OrderBy(DomInstanceExposers.Name);
var orderedOnName = domHelper.DomInstances.Read(onNameQuery);

// Sort descending on last modified
var onModifiedQuery = filter.OrderByDescending(DomInstanceExposers.LastModified);
var orderedOnModified = domHelper.DomInstances.Read(onModifiedQuery);

// Sort on certain field (e.g. 'Vehicle mass')
var fieldDescriptorId = new FieldDescriptorID(Guid.Parse("253700a1-1293-4dfa-997b-86efb601d894")); // Vehicle mass
var field = DomInstanceExposers.FieldValues.DomInstanceField(fieldDescriptorId);
var onFieldQuery = filter.OrderBy(field);
var orderedOnField = domHelper.DomInstances.Read(onFieldQuery);
```

> [!NOTE]
> Natural sorting is not supported. Enabling this option on the sorting API could result in poor performance since this will be executed in memory and requires all data to be loaded from the database.

#### Read selected fields

From DataMiner 10.6.0 onwards<!-- RN 43852 -->, the `DomInstances` CRUD helper supports reading only a selected subset of fields from `DomInstance` objects. This reduces the amount of data transferred and can significantly improve performance when clients only need a few fields from each instance.

The new overloads of `Read` and `PreparePaging` accept a `SelectedFields<DomInstance>` object. To select a field, add the exposer from `DomInstanceExposers` or add the `FieldDescriptorID` to the `SelectedFields<DomInstance>` object.

> [!NOTE]
> Selecting the `FieldValues` or `FullObject` exposer is not supported and will result in a failed read operation.

When used, these methods return a list of `PartialObject<DomInstance, DomInstanceId>`, which provides:

- `ID`: the `DomInstance` ID. Note: the `Id` is always available on a `PartialObject`; you do not need to add the `Id` exposer to `SelectedFields<DomInstance>`.
- `GetValue` and `TryGetValue`: retrieve the value of a selected exposer or a single-value `FieldDescriptorID`.
- `GetValues` and `TryGetValues`: retrieve a list of values for a selected `FieldDescriptorID` (for multi-valued fields or when multiple sections are allowed).

Retrieving values — behavior summary

- Multiple values: use `GetValues<T>` / `TryGetValues<T>` to obtain a `List<T>`. `GetValues<T>` throws `InvalidOperationException` if the values are not of type `T`; `TryGetValues<T>` returns `false` in that case.
- Single value: use `GetValue<T>` / `TryGetValue<T>` for single-valued fields. `GetValue<T>` throws `InvalidOperationException` if the value is not of type `T` or when there are multiple values available for that field descriptor; `TryGetValue<T>` returns `false`.
- No value available: `GetValue<T>` returns `default(T)` (equivalent to an empty list for list types); `TryGetValue<T>` returns `false`; `GetValues<T>` returns `null`; `TryGetValues<T>` returns `false`.

> [!IMPORTANT]
> Be aware that a `FieldDescriptor` ID should be unique across section definitions in a DOM module.

**Example — Read selected fields:**

```csharp
// Build a filter
var vehicleMassFieldDescriptorId = new FieldDescriptorID(Guid.Parse("253700a1-1293-4dfa-997b-86efb601d894"));
var filter = DomInstanceExposers.FieldValues.DomInstanceField(vehicleMassFieldDescriptorId).GreaterThanOrEqual(1000.0);

// Prepare the selected fields
var selectedFields = new SelectedFields<DomInstance>()
    .Add(DomInstanceExposers.Name)
    .Add(DomInstanceExposers.StatusId)
    .Add(vehicleMassFieldDescriptorId)
    .Add(elementsFieldDescriptorId);

// Use the helper to read partial DOM instances
var results = domHelper.DomInstances.Read(filter, selectedFields);

foreach (var doc in results)
{
    // Access the values from the partial DOM instance
    var name = doc.GetValue(DomInstanceExposers.Name);
    var status = doc.GetValue(DomInstanceExposers.StatusId);
    var vehicleMass = doc.GetValue<double>(vehicleMassFieldDescriptorId);
    var elements = doc.GetValues<string>(elementsFieldDescriptorId);
}
```

**Example — Read selected fields page by page:**

Similar to the read example, the selected fields can be used for a paged read. In the example, the default preferred page size of 500 items will be used, but a different page size can be set.

```csharp
// The filter and selected fields are created the same way when reading
var pagingSession = domHelper.DomInstances.PreparePaging(filter, selectedFields);

while (pagingSession.MoveToNextPage())
{
    var results = pagingSession.GetCurrentPage();
    // Handle current page of data...
}
```

### Multiple instances

When multiple `DomInstances` need to get created, updated, or deleted, we recommend calling the *CreateOrUpdate* or *Delete* methods on a `DomInstance` CRUD helper component with a list of those `DomInstances`. This feature is available from DataMiner 10.4.2/10.5.0 onwards<!-- RN 37891 -->.

For example, to create or update multiple `DomInstances`:

```csharp
// Create or update a list of DomInstances
var createResult = helper.DomInstances.CreateOrUpdate(domInstances);
```

*CreateOrUpdate* will consider the provided `DomInstances` that already exist as updates. The other `DomInstances` will be created. Providing a mix of both is supported.

> [!TIP]
> For more information and best practices for using these calls, see [Processing multiple DomInstances — examples](xref:DOM_BulkProcessing_Examples).

> [!IMPORTANT]
> When designing the object model, consider if a high number of `DomInstances` might need to be processed quickly or need to be provisioned. If this is the case, we recommend avoiding related actions such as [launching script actions](xref:ExecuteScriptOnDomInstanceActionSettings) and [history tracking](xref:DOM_history).
>
> The number of `DomInstances` that can be passed to these methods [is limited to 100](#maximum-number-of-instances). Since those related actions might outlive these CRUD calls, keep in mind that repeating these operations in succession can still impact the stability of the system.

#### Call result

The result of the bulk methods will contain:

- A list of `DomInstances` that were successfully created or updated, when `CreateOrUpdate` is called.

- A list of `DomInstance` IDs that were successfully deleted, when `Delete` is called.

From DataMiner 10.5.0/10.5.2 onwards<!-- RN 41546 -->, if an issue occurs for any of the items that are getting created, updated, or deleted in bulk (e.g. validation), a `BulkCrudFailedException<DomInstanceId>` will be thrown. The `Result` property in the exception can be used to check for which `DomInstances` the call succeeded or failed. For information on how to implement this flow, refer to the [Checking issues example](xref:DOM_BulkProcessing_Examples#checking-issues).

As an alternative, the `TryCreateOrUpdate` or `TryDelete` methods can be used. When the operation fails for one of the `DomInstances`, those calls will return false. The `result` output parameter will contain:

- The list of successfully processed items, as is the case for `CreateOrUpdate` and `Delete`.

- A list of `DomInstance` IDs that failed to be created, updated, or deleted.

- The trace data per `DomInstance` ID.

For each of these methods, the trace data of that call is still available and will contain the trace data for all processed `DomInstances`.

In DataMiner versions prior to DataMiner Feature Release 10.5.0/10.5.2<!-- RN 37891 -->, when any validation issue occurs, no exception is thrown (even when `ThrowExceptionsOnErrorData` is true) when calling the `CreateOrUpdate` or `Delete` methods. Instead, the result of the call should be used to check for which `DomInstances` the call succeeded or failed.

#### Maximum number of instances

Since these calls might trigger related actions (such as [launching script actions](xref:ExecuteScriptOnDomInstanceActionSettings)), this could cause a high load on the system when a lot of instances are involved. A limit of 100 `DomInstances` is set, to make sure those bulk operations are implemented with scalability in mind. When a higher number of instances need processing, these actions will need to be performed in batches.

You can also find this maximum number of instances for the `CreateOrUpdate`, `TryCreateOrUpdate`, `Delete`, or `TryDelete` calls in the `MaxAmountBulkOperation` property on a `DomInstance` CRUD helper component.

If more items get passed, `CreateOrUpdate`, `TryCreateOrUpdate`, `Delete`, or `TryDelete` calls will fail with a `DomInstanceCrudMaxAmountExceededArgumentException`, and the message of the exception will state how many items were passed.

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
> - The size limit of the attachments is determined by the [Documents.MaxSize](xref:MaintenanceSettings.Documents.MaxSize) setting in *MaintenanceSettings.xml*. The default value for this is 20 MB. Trying to upload a larger file using the helper will result in a `DataMinerException`.
> - Deleting a `DomInstance` will delete all attachments from the file system. The attachments cannot be recovered.
> - To view or download `DomInstance` attachments, read permission is required, and to add or edit them, edit permission is required.
> - To include `DomInstance` attachments in a [custom backup](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups) in Cube, select *All documents located on this DMA*.
> - The attachments are synced in the DMS.
