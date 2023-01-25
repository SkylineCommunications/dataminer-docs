---
uid: Resources_migration_to_elastic
---

# Resource migration to Elasticsearch

Starting from DataMiner version 10.3.1/10.4.0 it is possible to migrate the resources and resource pools from the Resources.xml file to Elasticsearch. This improves the scalability and performance on systems that have a large amount of resources.

## Migrating from XML to Elasticsearch

The migration can be triggered from the client test tool. The migration app can be found under *Advanced -> Migration*.

> [!WARNING]
> 
> - Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
> - All ResourceManagers in the cluster will restart during the migration.

1. Connect to the DMS using the *SLNetClientTest* tool:

    1. In the *SLNetClientTest* tool, go to *Connection* > *Connect*.
    1. In the *Connect* window, under *Authentication*, select *Explicit credentials* and specify the Administrator credentials.
    1. Click the *Connect* button.

1. In the *Advanced* menu, select *Migration*.

1. Click the *Start Migration* button in the *Resources XML to Elastic* section to start the migration wizard.

1. The bookings that are currently running or will start in the next hour are shown. The ResourceManager will restart during the migration, which means these bookings can potentially be impacted. No booking events will run when the ResourceManager is down.

1. The custom properties of the resources and resource pools that are incompatible with Elasticsearch (see [Allowed property names](#allowed-property-names)) will be shown, along with the conversion that will be automatically applied. If the Resources.xml file is corrupt, the properties can not be collected. In that case an error will be shown here and the migration will not start. If all found properties are compliant with Elasticsearch, the wizard will show *No properties that need conversion were found*.

1. All ResourceManagers in the cluster will now be stopped. If any ResourceManager is not reachable for some reason the migration will be canceled and all ResourceManagers will be notified to start up again without changing their storage type.

1. An alarm of type notice will be created stating the migration is in progress.

1. A ``MigrationStatus`` is created in the table for resources and resource pools.

1. All resources and resource pools are loaded from the Resources.xml file on the DataMiner Agent where the migration was triggered. The Resources.xml files of the other DataMiner Agents in the cluster are not migrated. The properties (for resources and resource pools) and property definitions (for resource pools) are converted if needed and written to Elasticsearch. Empty property names will be discarded at this stage since they cannot be indexed in Elasticsearch. Empty property values will be replaced with an empty string. The ``MigrationStatus`` rows for resources and resource pools will be updated to reflect the migration progress while the migration is ongoing. This process can be canceled by clicking the *Cancel Migration* button in the *Resources XML to Elastic* section.

1. When both ``MigrationStatus`` objects are completed, the configuration will automatically switch to ``Elasticsearch`` storage and the local ResourceManager (where the migration was triggered) will initialize.

1. The alarm of type notice will be cleared and an information event will be generated, stating that the migration has finished.

1. All other ResourceManagers in the cluster are notified they should initialize and switch to Elasticsearch storage.

A migration should not take more than half an hour. During testing, migrating a system a local Elasticsearch with a Resources.xml file of 1GB took about 13 minutes.  

### What to do when the migration fails

If your migration should fail for any reason, the migration status object in the client test tool window will have a red background color. The ``SLMigrationManager.txt`` and ``SLResourceManager.txt`` log files will contain more information. The ResourceManager will not switch the configuration, so Xml storage will still be used after a failed migration.

If a ``MigrationStatus`` is stuck in the ``InProgress`` status, it will be necessary to cancel the migration to make all ResourceManagers start or to trigger the migration again. This can be done with the *Cancel Migration* button in the client test tool window.

### New installations

When installing a new DataMiner Agent, the used storage type will depend on when the ResourceManager starts up for the first time. The following scenarios are possible:

- The DataMiner is installed with the 10.2.0 installer. Elasticsearch is not supported as a storage type for resources and resource pools on this version. If the ResourceManager starts up in 10.2.0 version it will start using Xml storage. After upgrading this DataMiner Agent to 10.3.1(CU0) or later it will continue to use Xml storage until the migration is triggered.
- The DataMiner is installed with the 10.2.0. installer. ResourceManager never starts up in this version (for example because Elasticsearch is not installed, which is a requirement for ResourceManager to start). If the DataMiner is then upgraded to 10.3.1(CU0) and ResourceManager initializes for the first time, it will use Elasticsearch storage.

When adding an DataMiner Agent to a cluster, the ResourceManager will take over the storage type of the DataMiner Agent that has been in the cluster the longest. If not all DataMiner Agents in the cluster are using the same storage type, all DataMiner Agents will take over the storage type of the DataMiner Agent that has been in the cluster the longest during the midnight sync.

## Checking the storage type used by a DataMiner Agent

If you want to know which storage type is used by a DataMiner Agent you can check so in the migration window (see [Migrating from Xml to Elasticsearch](#migrating-from-xml-to-elasticsearch)).

## Limitations and differences with Xml storage

### Allowed property names

Since the properties of resources and resource pools are indexed in Elasticsearch after the migration, there are some restrictions that apply:

- Property names may not start with character ``_``.
- Property names may not contain characters ``.`` (period), ``#`` (hashtag), ``*`` (star), ``,`` (comma), ``"`` (double quote) or ``'`` (single quote).
- Property names cannot be empty or contain only whitespace characters.
- Property values cannot be ``null``.

If ElasticSearch storage is enabled and a resource or resource pool with invalid properties is added or updated, the API will return a ``ResourceManagerErrorData`` in the ``TraceData``, with reason ``InvalidCharactersInPropertyNames``.

### Field size

Field names in Elasticsearch have a maximum length of 32766 bytes, which means any field of a resource or resource pool indexed in Elasticsearch can only contain 32766 bytes. This limit is mostly important for string fields, which can contain 32766 characters of one byte (or 16383 characters of two bytes). When trying to save a resource or resource pool with a field that is too big, the API will return an ``UnknownError``. The ``SLResourceManager.txt`` log file will contain the actual exception, which will mention the field that could not be indexed in Elasticsearch.

### Number of indices

When a resource is indexed in elasticsearch, all its properties, capacities and capabilities will be indexed as well. This means each unique property name and unique capacity and capability ID will become a field mapping in Elasticsearch. If the index contains a lot of such mappings, Elasticsearch starts having performance problems. During testing, no issues were found when using a typical amount of capacities, capabilities and property names, but slowdowns started to be noticeable when more than 300 unique field mappings were present.

### Difference when deleting resources

When using XML as storage, it is not allowed to remove a resource while one of the DataMiner Agents in the cluster is unreachable, as this could cause syncing issues. When using Elasticsearch as storage, this is allowed.

### Initial event on subscriptions

If you're using XML as storage and subscribe on the ``ResourceManagerEventMessage``, you will receive an initial event with all resources and resource pools. When using Elasticsearch as storage these events will no longer be sent. This is to prevent sending a message to the client containing thousands of resources.

### Syncing

When using XML storage, all ResourceManagers in the cluster will sync the resources in their XML file on startup and during the midnight sync. When using Elasticsearch as storage, DataMiner relies on Elasticsearch to do the syncing and data will not be sent around during the midnight sync or during startup. The ResourceManager will refresh the cached resources during the midnight sync by reading all resources and resource pools again from Elasticsearch.

## Metrics

### Resource performance

Below you can find the result of our performance testing for resource add, update and delete operations. On our setup (with a local Elasticsearch), Elasticsearch started to outperform XML storage when more than 2000 resources were present on the system.

![SRM Resource create performance](~/user-guide/images/SRM_Resource_Create_Performance.png)
![SRM Resource update performance](~/user-guide/images/SRM_Resource_Update_Performance.png)
![SRM Resource delete performance](~/user-guide/images/SRM_Resource_Delete_Performance.png)

> [!NOTE]
>  
> Read performance of resources and resource pools is unchanged, since all reads will go to a cache in SLNet. This was also confirmed during our testing.

### ResourceManager startup performance

See the following table for performance numbers for the startup time for ResourceManager with a large amount of resources:

| **Storage type** 	| **Resource cache load time** 	| **ResourceManager startup time** 	|
|------------------	|------------------------------	|----------------------------------	|
| Elasticsearch    	| 34s                          	| 1m 45s                           	|
| Xml              	| 47s                          	| 1m 52s                           	|

The **Resource cache load time** column shows the time it takes for ResourceManager to load all resources in its cache on startup. The **ResourceManager startup time** is the total time until ResourceManager is operational after initial startup. This includes the time it takes to initialize all storage types and can be higher if a lot of bookings are currently active or will start soon. This does not include the time ResourceManager spends syncing with other DataMiner Agents in the cluster if XML storage is used. The ResourceManager is considered operational before it has fully synced, since it can start handling API requests.