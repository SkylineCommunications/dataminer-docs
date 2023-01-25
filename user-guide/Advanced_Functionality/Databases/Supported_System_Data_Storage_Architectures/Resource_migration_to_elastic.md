---
uid: Resources_migration_to_elastic
---

# Resource migration to Elasticsearch

Starting from DataMiner version 10.3.1/10.4.0 it is possible to migrate the resources and resource pools from the Resources.xml file to Elasticsearch. This improves the scalability and performance on systems that have a large amount of resources.

## Migrating from Xml to Elasticsearch

The migration can be triggered from the client test tool. The migration app can be found under _Advanced -> Migration..._.

> [!NOTE]
>  
> The permission to add resources is required to start the migration.

Clicking the _Start Migration_ button in the _Resources XML to Elastic_ section will start the migration wizard, which has the following steps:

1. The bookings that are currently running or will start in the next hour are shown. The ResourceManager will restart during the migration, which means these bookings can potentially be impacted. No booking events will run when the ResourceManager is down.

1. The custom properties of the resources and resource pools that are incompatible with Elasticsearch (see [Allowed property names](#allowed-property-names)) will be shown, along with the conversion that will be automatically applied. If the Resources.xml file is corrupt, the properties can not be collected. In that case an error will be shown here and the migration will not start. If all found properties are compliant with Elasticsearch, the wizard will show _No properties that need conversion were found._

1. All ResourceManagers in the cluster will now be stopped. If any ResourceManager is not reachable for some reason the migration will be aborted and all ResourceManagers will be notified to start up again without changing their storage type.

1. A notice will be created in the alarm console stating the migration is in progress.

1. A ``MigrationStatus`` is created in the table for resources and resource pools.

1. All resources and resource pools are loaded from the Resources.xml file on the agent where the migration was triggered. The Resources.xml files of the other agents in the cluster are not migrated. The properties (for resources and resource pools) and property definitions (for resource pools) are converted if needed and written to Elasticsearch. Empty property names will be discarded at this stage since they cannot be indexed in Elasticsearch. Empty property values will be replaced with an empty string. The ``MigrationStatus`` rows for resources and resource pools will be updated to reflect the migration progress will the migration is ongoing.

1. When both ``MigrationStatus`` objects are completed, the configuration will automatically switch to ``Elasticsearch`` storage and the local ResourceManager (where the migration was triggered) will initialize.

1. The generated notice will be cleared and an information event stating the migration has finished will be generated.

1. All other ResourceManagers in the cluster are notified they should initialize and switch to Elasticsearch storage.

A migration should not take more than a couple of minutes at most. During our testing, migrating an internal system with a Resources.xml file of 1GB took about 13 minutes.  

### What to do when the migration fails

If your migration should fail for any reason, the migration status object in the client test tool window should have a red background color. The ``SLMigrationManager.txt`` and ``SLResourceManager.txt`` log files should contain more information. The ResourceManager will not switch the configuration, so Xml storage will still be used after a failed migration.

If a ``MigrationStatus`` is stuck in the ``InProgress`` status, it will be necessary to cancel the migration to make all ResourceManagers start or to trigger the migration again. This can be done with the _Cancel Migration_ button in the client test tool window.

### New installations

When installing a new DataMiner agent, the used storage type will depend on when the ResourceManager starts up for the first time. The following scenarios are possible:

- The DataMiner is installed with the 10.2.0 installer. Elasticsearch is not supported as a storage type for resources and resource pools on this version. If the ResourceManager starts up in 10.2.0 version it will start using Xml storage. After upgrading this agent to 10.3.1(CU0) or later it will continue to use Xml storage until the migration is triggered.
- The DataMiner is installed with the 10.2.0. installer. ResourceManager never starts up in this version (for example because Elasticsearch is not installed, which is a requirement for ResourceManager to start). If the DataMiner is then upgraded to 10.3.1(CU0) or and ResourceManager initializes for the first time, it will use Elasticsearch storage.

When adding an agent to a cluster, the ResourceManager will take over the storage type of the agent that has been in the cluster the longest. If not all agents in the cluster are using the same storage type, all agents will take over the storage type of the agent that has been in the cluster the longest during the midnight sync.

## Checking the storage type used by a DataMiner agent

If you want to know which storage type is used by a DataMiner agent you have several options:

- The migration window (see [Migrating from Xml to Elasticsearch](#migrating-from-xml-to-elasticsearch)) will show the storage type of the agent you are connected to.

- The current storage type can be retrieved with an SLNet message. If no storage type is present in the response, ``Xml`` storage is used:

```csharp
private ResourceStorageType GetStorageType()
{
    var getConfigMessage = new ResourceManagerConfigInfoMessage(ResourceManagerConfigInfoMessage.ConfigInfoType.Get);
    var response = _engine.SendSLNetSingleResponseMessage(getConfigMessage) as ResourceManagerConfigInfoResponseMessage;
    return response?.StorageSettings?.ResourceStorageType ?? ResourceStorageType.Xml;
}
```

- The storage type is pushed to CDMR for CDMR-connected agents. it can be found in the configurations page of the element.

- The storage type of the ResourceManager is stored in the ResourceManager config file (_C:\Skyline DataMiner\ResourceManager\Config.xml_). If no ``ResourceStorageType`` tag is present, the ``Xml`` storage will be used:

```xml
<?xml version="1.0" encoding="utf-8"?>
<ResourceManagerConfig>
  ...
  <ResourceSettings>
    <ResourceStorageType>Elastic</ResourceStorageType>
  </ResourceSettings>
</ResourceManagerConfig>
```

## Limitations and differences with Xml storage

### Allowed property names

Since the properties of resources and resource pools are indexed in Elasticsearch after the migration, there are some restrictions that apply:

- Property names may not start with character ``_``.
- Property names may not contain characters ``.`` (period), ``#`` (hashtag), ``*`` (star), ``,`` (comma), ``"`` (double quote) or ``'`` (single quote).
- Property names cannot be empty or contain only whitespace characters.
- Property values cannot be ``null``.

If ElasticSearch storage is enabled and a resource or resource pool with invalid properties is added or updated, the API will return a ``ResourceManagerErrorData`` in the ``TraceData``, with reason ``InvalidCharactersInPropertyNames``.

### Field size

Field names in Elasticsearch have a maximum length of 32766 bytes, which means any field of a resource or resource pool indexed in Elasticsearch only contain 32766 bytes. This limit is mostly important for string fields, which can contain 32766 characters of one byte (or 16383 characters of two bytes). When trying to save a resource or resource pool with a field that is too big, the API will return an ``UnknownError``. The ``SLResourceManager.txt`` log file will contain the actual exception, which will mention the field that could not be indexed in Elasticsearch.

### Number of indices

When a resource is indexed in elasticsearch, all its properties, capacities and capabilities will be indexed as well. This means each unique property name and unique capacity and capability id will become a field mapping in Elasticsearch. If the index contains a lot of such mappings, Elasticsearch starts having performance problems. During testing, no issues were found when using a typical amount of capacities, capabilities and property names, but slowdowns started to be noticeable when more than 300 unique field mappings were present.

### Difference when deleting resources

When using ``Xml`` as storage, it is not allowed to remove a resource while one of the agents in the cluster is unreachable, as this could cause syncing issues. When using Elasticsearch as storage, this is allowed.

### Initial event on subscriptions

When using ``Xml`` as storage, if a client subscribes on the ``ResourceManagerEventMessage``, he will receive an initial event with all resources and resource pools. When using Elasticsearch as storage these events will no longer be sent. This is to prevent sending a message to the client containing thousands of resources.

### Syncing

When using ``Xml`` storage, all ResourceManagers in the cluster will sync the resources in their ``Xml`` file on startup and during the midnight sync. When using Elasticsearch as storage, DataMiner relies on Elasticsearch to do the syncing and data will not be sent around during the midnight sync or during startup. The ResourceManager will refresh the cached resources during the midnight sync by reading all resources and resource pools again from Elasticsearch.

## Metrics

### Resource performance

Below you can find the result of our performance testing for resource add, update and delete operations. On our setup (with a local Elasticsearch), Elasticsearch started to outperform ``Xml`` storage when more than 2000 resources were present on the system.

![SRM Resource create performance](~/user-guide/images/SRM_Resource_Create_Performance.png)
![SRM Resource update performance](~/user-guide/images/SRM_Resource_Update_Performance.png)
![SRM Resource delete performance](~/user-guide/images/SRM_Resource_Delete_Performance.png)

__Note__: read performance of resources and resource pools is unchanged, since all reads will go to a cache in SLNet. This was also confirmed during our testing.

### ResourceManager startup performance

See the following table for performance numbers for the startup time for ResourceManager with a large amount of resources:

| __Storage type__ 	| __Resource cache load time__ 	| __ResourceManager startup time__ 	|
|------------------	|------------------------------	|----------------------------------	|
| Elasticsearch    	| 34s                          	| 1m 45s                           	|
| Xml              	| 47s                          	| 1m 52s                           	|

The __Resource cache load time__ columns shows the time it takes for ResourceManager to load all resources in its cache on startup. The __ResourceManager startup time__ is the total time until ResourceManager is operational after initial startup. This includes the time it takes to initialize all storage types and can be higher if a lot of bookings are currently active or will start soon. This does not include the time ResourceManager spends syncing with other agents in the cluster if ``Xml`` storage is used. The ResourceManager is considered operational before it has fully synced, since it can start handling API requests.