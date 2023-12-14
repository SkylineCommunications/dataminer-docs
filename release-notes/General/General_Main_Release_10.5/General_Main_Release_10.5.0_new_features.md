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

#### DataMiner Object Models: Defining CRUD actions for DomInstances on DomDefinition level [ID_37963]

<!-- MR 10.5.0 - FR 10.4.2 -->

Using the `ExecuteScriptOnDomInstanceActionSettings` object, it is now possible to configure DomInstance CRUD actions on DomDefinition level.

The `ExecuteScriptOnDomInstanceActionSettings` object has been made available as a `ScriptSettings` property in the `ModuleSettingsOverrides` property of a DomDefinition.

> [!NOTE]
>
> - When `ScriptSettings` are filled in in the DomDefinition, these will take precedence.
> - When, in the DomDefinition, the `ScriptSettings` object is null, the `ScriptSettings` of the `ModuleSettings` will be used instead.
> - In order for the `ModuleSettings` objects to be used, the objects in the `ModuleSettingsOverrides` of the `DomDefinition` have to be *null*. Just making them empty is not sufficient.
