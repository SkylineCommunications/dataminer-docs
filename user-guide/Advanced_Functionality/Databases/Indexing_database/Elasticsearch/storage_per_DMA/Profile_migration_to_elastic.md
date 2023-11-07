---
uid: Profile_migration_to_elastic
---

# Migrating SRM profiles to the indexing database

Starting from DataMiner version 10.1.0/10.0.8, you can migrate the profiles from the *Profiles.xml* file to the indexing database. This improves the scalability and performance on systems that have a large number of profiles.

When you [install an indexing database](xref:Installing_Elasticsearch_via_DataMiner) and [migrate booking data](xref:Configuring_DataMiner_Indexing) on an existing DataMiner System prior to DataMiner 10.4.0, profiles are not automatically migrated. Based on your specific setup, and keeping in mind the [limitations and differences with XML storage](#limitations-and-differences-with-xml-storage), you can decide independently whether or not you want to start this migration. However, **from DataMiner 10.4.0 onwards**, the use of an indexing database (or Storage as a Service) to store profiles is **mandatory**. Using XML storage is no longer possible from that DataMiner version onwards.

> [!TIP]
>
> - If you are looking for information on how to migrate an SRM configuration from one DMA to another, see [Migrating an SRM configuration](xref:SRM_migrating).

> [!NOTE]
>
> - XML storage is no longer supported from DataMiner 10.4.0 onwards. Upgrading to 10.4.0 will not be possible if the profile data is still stored in XML.
> - Elasticsearch is only supported up to version 6.8. If you are using Elasticsearch as the indexing database, we therefore recommend using [Storage as a Service](xref:STaaS) instead, or if you do want to continue using self-hosted storage, using [dedicated clustered storage](xref:Dedicated_clustered_storage) with OpenSearch or the Amazon OpenSearch Service on AWS.

## Migrating from XML to the indexing database

To migrate the profiles, you will need to use the SLNetClientTest tool. Note that while the tool mentions only "Elastic", it can also be used for a migration to OpenSearch.

![SLNetClientTest tool](~/user-guide/images/ClientTestToolMigrationUI_ProfileMigration.jpg)<br>
*Migration window in SLNetClientTest tool (version 10.4.2)*

> [!WARNING]
>
> - Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
> - All Profile Manager instances in the cluster will keep working during the migration. But any creates/updates done during the migration will no longer be migrated.
> - After migration the storage type will still be XML, to switch to indexing database storage, press the *Start using Elastic* button. If the *Start using Elastic* button is not be visible, that means there is no configuration file yet, press the *Create Configuration* button to create the configuration file.

1. Connect to the DMS using the *SLNetClientTest* tool:

    1. In the *SLNetClientTest* tool, go to *Connection* > *Connect*.
    1. In the *Connect* window, under *Authentication*, select *Explicit credentials* and specify the credentials of an administrator user.
    1. Click the *Connect* button.

1. In the *Advanced* menu, select *Migration*.

1. In the *ProfileManger XML to Elastic* section, click the *Start Migration* button to start the migration wizard.

   During the migrations, the Profile Manager is not stopped, so it will keep working as expected. This also means a snapshot of the Profiles.xml is migrated. Any creates/updates done during the migration will no longer be migrated.

1. A window will show the migration actions that have been scheduled. If you close this window, the migration will continue in the background. To cancel the migration, click the *Cancel Migration* button.

   - The progress of the scheduled actions will be shown in the *MigrationStatus* table in SLNetClientTest tool, where 3 rows (profile instances, definitions & parameters) will be created for the migration of profiles. These rows will be updated to reflect the progress of the migration.

   - All profiles will be loaded from the *Profiles.xml* file on the DataMiner Agent where the migration was triggered. The *Profiles.xml* files of the other DataMiner Agents in the cluster are not migrated. This is not necessary, as the *Profiles.xml* file is synced in the cluster.

   - The profiles objects will be written to the indexing database.

   - When the migration for profiles is completed, the configuration will not switch to indexing database storage. To switch to indexing database storage, press the *Start using Elastic* button. If the *Start using Elastic* button is not be visible, that means there is no configuration file yet, press the *Create Configuration* button to create the configuration file.

> [!NOTE]
>
> - The migration should not take more than a few minutes. During testing, migrating a *Profiles.xml* file of 100 MB in a system with a local Elasticsearch database took about 1 minute.
> - You can cancel the migration process by clicking the *Cancel Migration* button in the *ProfileManager XML to Elastic* section.

### Troubleshooting

If the migration should fail for any reason, the migration status object in the SLNetClientTest tool window will get a red background color. The ``SLMigrationManager.txt`` and ``SLProfileManager.txt`` log files will contain more information.

If a ``MigrationStatus`` is stuck in the ``InProgress`` state, you will need to cancel the migration and trigger the migration again. You can do so with the *Cancel Migration* button in the *ProfileManger XML to Elastic* section of the SLNetClientTest tool window.

### Behavior in new installations

When a new DataMiner Agent is installed, the used storage type will depend on when Profile Manager starts up for the first time.

- If DataMiner is installed with the 10.0 installer and Profile Manager is used, XML storage will be used. An indexing database is not yet supported as a storage type for profiles in DataMiner 10.0. After you have upgraded this DataMiner Agent to DataMiner 10.0.8 or later, it will continue to use XML storage until you trigger the migration.

- If DataMiner is installed on version 10.4.0 and Profile Manager is used, indexing database storage will be used. This means profiles will only be functional on a DataMiner System that has indexing database storage running.

- When you add a new DataMiner Agent to an existing cluster, the same behavior applies as mentioned above.

## Checking the storage type used by a DataMiner Agent

If you want to know which storage type a DataMiner Agent is currently using, open the migration window as detailed under [Migrating from XML to the indexing database](#migrating-from-xml-to-the-indexing-database).

The current storage type is displayed in the *ProfileManger XML to Elastic* section, under the *Cancel Migration* button stating "Currently using ..." .

## Limitations and differences with XML storage

### Field size

Field names in the indexing database have a maximum length of 32766 bytes, which means any field of a profile indexed in the database can only contain 32766 bytes. This limit is mostly important for string fields, which can contain 32766 characters of one byte (or 16383 characters of two bytes).

> [!NOTE]
> While using indexing database storage, if there is an attempt to save a profile with a field that is too big, the API will return an ``Unknown`` error. The ``SLProfileManager.txt`` log file will contain the actual exception, which will mention the field that could not be indexed in the database.

### Initial event on subscriptions

If XML storage is used and you subscribe to the *ProfileManagerEventMessage*, you will receive an initial event with all profiles. This event is not sent when indexing database storage is used, in order to prevent sending a message to the client containing thousands of profiles.

### Syncing

If XML storage is used, all Profile Manager instances in the cluster will sync the profiles in their XML file on startup and during the midnight sync. If indexing database storage is used, DataMiner relies on the database to do the syncing, so this does not happen during the midnight sync or on startup. However, Profile Manager will refresh the cached profiles during the midnight sync by reading all profiles again from the database. There is no functional difference between these approaches, but using the indexing database for storage will reduce the communication between Profile Manager instances in a cluster environment.