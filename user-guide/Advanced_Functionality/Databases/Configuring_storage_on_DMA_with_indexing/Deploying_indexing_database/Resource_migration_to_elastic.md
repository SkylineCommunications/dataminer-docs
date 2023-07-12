---
uid: Resources_migration_to_elastic
---

# Migrating SRM resources to Elasticsearch

Starting from DataMiner version 10.3.0/10.3.2, you can migrate the resources and resource pools from the *Resources.xml* file to Elasticsearch. This improves the scalability and performance on systems that have a large number of resources.

Resources are not automatically migrated when you [install Elasticsearch](xref:Installing_Elasticsearch_via_DataMiner) and [migrate booking data](xref:Configuring_DataMiner_Indexing). Based on your specific setup, and keeping in mind the [limitations and differences between XML and Elasticsearch storage](#limitations-and-differences-with-xml-storage), you can decide independently whether or not you want to start this migration.

> [!TIP]
>
> - For metrics related to resource performance with Elasticsearch or with XML storage, see [Resources benchmarks](xref:resources_benchmarks).
> - If you are looking for information on how to migrate an SRM configuration from one DMA to another, see [Migrating an SRM configuration](xref:SRM_migrating).

> [!NOTE]
> From DataMiner 10.4.0 onwards, the use of Elasticsearch to store resources and resource pools is mandatory. XML storage will no longer be supported. Upgrading to 10.4.0 will not be possible if the resources data is still stored in XML.

## Migrating from XML to Elasticsearch

To migrate the resources, you will need to use the SLNetClientTest tool.

![SLNetClientTest tool](~/user-guide/images/ClientTestToolMigrationUI_ResourceMigration.jpg)<br>
*Migration window in SLNetClientTest tool (version 10.3.2)*

> [!WARNING]
>
> - Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
> - All Resource Manager instances in the cluster will restart during the migration.

1. Connect to the DMS using the *SLNetClientTest* tool:

    1. In the *SLNetClientTest* tool, go to *Connection* > *Connect*.
    1. In the *Connect* window, under *Authentication*, select *Explicit credentials* and specify the credentials of an administrator user.
    1. Click the *Connect* button.

1. In the *Advanced* menu, select *Migration*.

1. In the *Resources XML to Elastic* section, click the *Start Migration* button to start the migration wizard.

   The bookings that are currently running or will start in the next hour will be shown. Resource Manager will restart during the migration, which means these bookings can potentially be affected. **No booking events will run while Resource Manager is down**.

1. Click *Continue Migration*.

   The custom properties of the resources and resource pools that are incompatible with Elasticsearch (see [Allowed property names](#allowed-property-names)) will be shown, along with the conversion that will be automatically applied. If the *Resources.xml* file is corrupt, the properties cannot be collected. In that case, an error will be shown, and the migration cannot be started. If all found properties are compatible with Elasticsearch, the wizard will show *No properties that need conversion were found*.

1. If you agree with the proposed conversion of the properties or no conversion is necessary, click *Continue Migration* to start the actual migration process. If you do not accept the conversion, click *Cancel Migration*.

   - A window will show the migration actions that have been scheduled. If you close this window, the migration will continue in the background.

   - The progress of the scheduled actions will be shown in the *MigrationStatus* table in SLNetClientTest tool, where a row will be created for the migration of resources and resource pools. These rows will be updated to reflect the progress of the migration.

   - All Resource Manager instances in the cluster will be stopped. If DataMiner cannot reach a Resource Manager instance for some reason, the migration will be canceled, and all Resource Manager instances will be notified to start up again without changing their storage type.

   - While the migration is in progress, a notice will be added in the Alarm Console. Once the migration is completed, the notice will be cleared and an information event will be generated, stating that the migration has finished.

   - All resources and resource pools will be loaded from the *Resources.xml* file on the DataMiner Agent where the migration was triggered. The *Resources.xml* files of the other DataMiner Agents in the cluster are not migrated. This is not necessary, as the *Resources.xml* file is synced in the cluster.

   - The properties (for resources and resource pools) and property definitions (for resource pools) will be converted if needed and written to Elasticsearch. **Empty property names will be discarded** at this stage, since they cannot be indexed in Elasticsearch. **Empty property values will be replaced with an empty string**.

   - When the migration for both resources and resource pools is completed, the configuration will automatically switch to Elasticsearch storage, and the local Resource Manager (where the migration was triggered) will be initialized. Then all other Resource Manager instances in the cluster will be notified that they should start up and switch to Elasticsearch storage.

> [!NOTE]
>
> - The migration should not take more than half an hour. During testing, migrating a *Resources.xml* file of 1 GB in a system with a local Elasticsearch database took about 13 minutes.
> - You can cancel the migration process by clicking the *Cancel Migration* button in the *Resources XML to Elastic* section.

### Troubleshooting

If the migration should fail for any reason, the migration status object in the SLNetClientTest tool window will get a red background color. The ``SLMigrationManager.txt`` and ``SLResourceManager.txt`` log files will contain more information. Resource Manager will not switch the configuration, so XML storage will still be used after a failed migration.

If a ``MigrationStatus`` is stuck in the ``InProgress`` state, you will need to cancel the migration to make all Resource Manager instances start or to trigger the migration again. You can do so with the *Cancel Migration* button in the *Resources XML to Elastic* section of the SLNetClientTest tool window.

### Behavior in new installations

When a new DataMiner Agent is installed, the used storage type will depend on when Resource Manager starts up for the first time.

- If DataMiner is installed with the 10.2.0 installer and Resource Manager is used, XML storage will be used. Elasticsearch is not yet supported as a storage type for resources and resource pools in DataMiner 10.2.0. After you have upgraded this DataMiner Agent to DataMiner 10.3.0 or later, it will continue to use XML storage until you trigger the migration.

- If DataMiner is installed with the 10.2.0 installer but Resource Manager never starts up while this version is used (for example because Elasticsearch is not installed, which is a requirement for Resource Manager to start as Elasticsearch is used to store bookings), and the DataMiner Agent is then upgraded to 10.3.1, Resource Manager will use Elasticsearch storage when it is initialized.

- When you add a new DataMiner Agent to an existing cluster, Resource Manager will use the storage type of the DataMiner Agent that has been in the cluster the longest. If not all DataMiner Agents in the cluster are using the same storage type, during the midnight sync, all DataMiner Agents will switch to the storage type of the DataMiner Agent that has been in the cluster the longest.

## Checking the storage type used by a DataMiner Agent

If you want to know which storage type a DataMiner Agent is currently using, open the migration window as detailed under [Migrating from XML to Elasticsearch](#migrating-from-xml-to-elasticsearch).

## Limitations and differences with XML storage

### Allowed property names

Since the properties of resources and resource pools are indexed in Elasticsearch after the migration, the following restrictions apply:

- Property names must not start with character ``_``.
- Property names must not contain characters ``.`` (period), ``#`` (hashtag), ``*`` (star), ``,`` (comma), ``"`` (double quote) or ``'`` (single quote).
- Property names must not be empty or contain only whitespace characters.
- Property values must not be ``null``.

> [!NOTE]
> If Elasticsearch storage is enabled and a resource or resource pool with invalid properties is added or updated, the API will return a ``ResourceManagerErrorData`` in the ``TraceData``, with reason ``InvalidCharactersInPropertyNames``.

### Difference when deleting resources

When XML storage is used, it is not possible to remove a resource when one of the DataMiner Agents in the cluster cannot be reached, as this could cause syncing issues. No such restrictions apply when Elasticsearch storage is used.

### Field size

Field names in Elasticsearch have a maximum length of 32766 bytes, which means any field of a resource or resource pool indexed in Elasticsearch can only contain 32766 bytes. This limit is mostly important for string fields, which can contain 32766 characters of one byte (or 16383 characters of two bytes).

> [!NOTE]
> If there is an attempt to save a resource or resource pool with a field that is too big, the API will return an ``UnknownError``. The ``SLResourceManager.txt`` log file will contain the actual exception, which will mention the field that could not be indexed in Elasticsearch.

### Number of indices

When a resource is indexed in Elasticsearch, all its properties, capacities, and capabilities will be indexed as well. This means that each unique property name and unique capacity and capability ID will become a field mapping in Elasticsearch. If there is an unusually large number of capacities, capabilities, and/or property names, this may lead to reduced performance of Elasticsearch. During testing, this was noticed when more than 300 unique field mappings were present. We therefore recommend that you limit the number of unique capacity IDs, capability IDs, and property names over all resources in the system so that it remains below 300.

### Initial event on subscriptions

If XML storage is used and you subscribe to the *ResourceManagerEventMessage*, you will receive an initial event with all resources and resource pools. This event is not sent when Elasticsearch storage is used, in order to prevent sending a message to the client containing thousands of resources.

### Syncing

If XML storage is used, all Resource Manager instances in the cluster will sync the resources in their XML file on startup and during the midnight sync. If Elasticsearch storage is used, DataMiner relies on Elasticsearch to do the syncing, so this does not happen during the midnight sync or on startup. However, Resource Manager will refresh the cached resources during the midnight sync by reading all resources and resource pools again from Elasticsearch. There is no functional difference between these approaches, but using Elasticsearch as storage will reduce the communication between Resource Manager instances in a cluster environment.
