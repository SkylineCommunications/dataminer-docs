---
uid: General_Main_Release_10.5.0_new_features
---

# General Main Release 10.5.0 – New features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

*No highlights have been selected yet.*

## New features

### Core functionality

#### BrokerGateway DxM will now be installed automatically during a DataMiner upgrade [ID_37714]

<!-- MR 10.5.0 - FR 10.4.1 -->

When a DataMiner Agent is upgraded to version 10.5.0/10.4.1 or above, the *BrokerGateway* DxM will automatically be installed in the `C:\Program Files\Skyline Communications\DataMiner BrokerGateway` folder.

This new DxM, which is currently still under development, is intended to manage all NATS configurations.

#### SLNetTypes and SLGlobal now support a new AlarmTreeID/SLAlarmTreeKey object [ID_37950]

<!-- MR 10.5.0 - FR 10.4.2 -->

The *SLNetTypes* and *SLGlobal* implementations have been updated to support a new *AlarmTreeID/SLAlarmTreeKey* object, which can used to refer to an alarm tree. This new object was created in order to support alarm ID ranges per element rather than per DataMiner Agent, a feature that is still in progress.

Also, a number of client messages have been adapted to support passing this new *AlarmTreeID/SLAlarmTreeKey* object, and a number of existing properties have been marked as obsolete.

### DataMiner modules

#### User-defined APIs: Query string support [ID_37733]

<!-- MR 10.5.0 - FR 10.4.1 -->

User-defined APIs now support the use of query strings.

The query parameters from the API requests are available in the `QueryParameters` property of the `ApiTriggerInput` class. This property is of type `IQueryParameters`.

The `IQueryParameters` class exposes the following methods:

```csharp
bool TryGetValues(string key, out List<string> values);

bool TryGetValue(string key, out string value);

List<string> GetAllKeys();

bool ContainsKey(string key);
```

> [!NOTE]
>
> - Multiple values can be added for one key.
> - Query parameter keys are case-sensitive.

#### Service & Resource Management - ResourceManagerHelper & ServiceManagerHelper: New Count methods [ID_37885]

<!-- MR 10.5.0 - FR 10.4.2 -->

The *ResourceManagerHelper* and *ServiceManagerHelper* now include the following *Count* methods that will allow you to count objects using a filter.

- ServiceManagerHelper:

  - CountServiceDefinitions(filter)

- ResourceManageHelper:

  - CountResources(filter)
  - CountResourcePools(filter)
  - CountReservationInstances(filter)

Example:

```csharp
var resourceManagerHelper = new ResourceManagerHelper(engine.SendSLNetSingleResponseMessage);
var count = resourceManagerHelper.CountResources(ResourceExposers.Name.Contains("name"));
```

#### DataMiner Object Models: Creating, updating and deleting multiple DOM instances in one call [ID_37891]

<!-- MR 10.5.0 - FR 10.4.2 -->

From now on, the DOM API allows you to create, update or delete up to 100 DOM instances in one single call.

##### CreateOrUpdate

A `CreateOrUpdate` operation will return the IDs of the DomInstances that were successfully created or updated, as well as the IDs of the DomInstances that were not. Trace data will be available per DomInstance ID.

A `CreateOrUpdate` operation will return a list of DomInstances that were successfully created or updated. Trace data will be available per DomInstance ID.

If an issue occurs while creating or updating an item, no exception will be thrown, even when `ThrowExceptionsOnErrorData` is true. The trace data of the last call will contain the data for all items.

If the entire `CreateOrUpdate` operation would fail, a `CrudFailedException` will be thrown. If, in that case, `ThrowExceptionsOnErrorData` was set to false, null will be returned and the trace data of the last call will contain more details about the issue.

If the list returned by a `CreateOrUpdate` operation contains DomInstances sharing the same key, only the last item with that key will be considered to be created or updated.

```csharp
/// <summary>
/// Returns the created or updated `objects`.
/// </summary>
/// <param name="objects">
/// List of `DomInstances` to be created or updated.
/// The number of `DomInstances` should not exceed `MaxAmountBulkOperation`.
/// </param>
/// The result containing a list of `DomInstances` that were successfully updated or created,
/// a list of IDs of the `DomInstances` that were not successfully updated or created
/// and a list of `TraceData` per item.
/// `null` if `ThrowExceptionsOnErrorData` is `false` and there is no `BulkCreateOrUpdateResult` available.
/// </returns>
/// <exception cref="ArgumentNullException">if `objects` is `null`.</exception>
/// <exception cref="CrudFailedException">if `ThrowExceptionsOnErrorData` is `true`,  the TraceData contains errors and there is no `BulkCreateOrUpdateResult` available.</exception>
/// <exception cref="DomInstanceCrudMaxAmountExceededArgumentException">if the number of `objects` exceeds `MaxAmountBulkOperation`.</exception>
public BulkCreateOrUpdateResult<DomInstance, DomInstanceId> CreateOrUpdate(List<DomInstance> objects)
```

##### Delete

A `Delete` operation will return the IDs of the DomInstances that were deleted, as well as the IDs of the DomInstances that were not deleted. Trace data will be available per DomInstance ID.

If an issue occurs while deleting an item, no exception will be thrown, even when `ThrowExceptionsOnErrorData` is true. The trace data of the last call will contain the data for all items.

If the entire `Delete` operation would fail, a `CrudFailedException` will be thrown. If, in that case, `ThrowExceptionsOnErrorData` was set to false, null will be returned and the trace data of the last call will contain more details about the issue.

```csharp
/// <summary>
/// Deletes the given `objects`.
/// </summary>
/// <param name="objects">
/// List of `DomInstances` to be deleted.
/// The number of `DomInstances` should not exceed `MaxAmountBulkOperation`.
/// </param>
/// <returns>
/// The result containing a list of IDs of `DomInstances` that were successfully deleted
/// a list of IDs of the `DomInstances` that were not successfully deleted
/// and a list of `TraceData` per item.
/// </returns>
/// <exception cref="ArgumentNullException">if `objects` is `null`.</exception>
/// <exception cref="CrudFailedException">if `ThrowExceptionsOnErrorData` is `true`,  the TraceData contains errors and there is no `BulkDeleteResult` available.</exception>
/// <exception cref="DomInstanceCrudMaxAmountExceededArgumentException">if the amount of `objects` exceeds `MaxAmountBulkOperation`.</exception>
public BulkDeleteResult<DomInstanceId> Delete(List<DomInstance> objects)
```

##### MaxAmountBulkOperation

By default, `MaxAmountBulkOperation` will be set to 100. This means that any `CreateOrUpdate` or `Delete` operation will be able to process up to 100 DOM instances. If more than 100 instances are passed, then an error will occur.

> [!IMPORTANT]
> Since related actions (e.g. launching script actions and history tracking) might outlive a `CreateOrUpdate` or `Delete` operation, keep in mind that repeating these operations in succession can have an impact on system stability.

##### Unique IDs

When creating, updating or deleting instances using the above-mentioned bulk operations, make sure each DOM instance in the list has a unique ID.

If multiple instances share the same ID, only the last of those instances will be taken into account.

> [!NOTE]
> This also applies when PaTokens are created, updated or deleted in bulk. If multiple instances share the same ID, only the last of those instances will be taken into account.

#### DataMiner Object Models: Defining CRUD actions for DomInstances on DomDefinition level [ID_37963]

<!-- MR 10.5.0 - FR 10.4.2 -->

Using the `ExecuteScriptOnDomInstanceActionSettings` object, it is now possible to configure DomInstance CRUD actions on DomDefinition level.

The `ExecuteScriptOnDomInstanceActionSettings` object has been made available as a `ScriptSettings` property in the `ModuleSettingsOverrides` property of a DomDefinition.

> [!NOTE]
>
> - When `ScriptSettings` are filled in in the DomDefinition, these will take precedence.
> - When, in the DomDefinition, the `ScriptSettings` object is null, the `ScriptSettings` of the `ModuleSettings` will be used instead.
> - In order for the `ModuleSettings` objects to be used, the objects in the `ModuleSettingsOverrides` of the `DomDefinition` have to be *null*. Just making them empty is not sufficient.
