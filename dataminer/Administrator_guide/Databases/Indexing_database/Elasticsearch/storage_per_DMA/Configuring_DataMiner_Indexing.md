---
uid: Configuring_DataMiner_Indexing
---

# Configuring indexing settings in DataMiner Cube

The indexing settings in System Center determine which information is stored in the indexing database of a [dedicated clustered storage](xref:Dedicated_clustered_storage) setup.

To configure these settings, go to *System Center* > *Search & Indexing*.

> [!TIP]
>
> - From DataMiner 10.3.0/10.3.3 onwards, for systems with a **dedicated clustered storage** setup, essential indexing database settings that are required to set up the database are available in System Center along with the general database settings. See [Configuring the general database settings](xref:Configuring_the_database_settings_in_Cube).
> - For earlier DataMiner versions or for setups with storage per DMA, the indexing setup is configured in *DB.xml*. See [indexing database settings](xref:DB_xml#indexing-database-settings).

The following settings are available:

- *Enable indexing on alarms:* Enables indexing of alarms. If this option is not enabled, the enhanced search options in the Alarm Console are not available. For systems using [STaaS](xref:STaaS) or [dedicated clustered storage](xref:Dedicated_clustered_storage), this setting is not used.<!-- RN 44435 -->

- *Migrate booking data to Indexing Engine*: Allows you to migrate older booking data (i.e. from prior to DataMiner 10.0) stored in a Cassandra database per DMA to the indexing database, if this has not been done yet. This option is not relevant for [dedicated clustered storage](xref:Dedicated_clustered_storage) or [STaaS](xref:STaaS) setups and is no longer available from DataMiner server 10.5.0 [CU12]/10.6.0 onwards<!--RN 44550-->.

  Please note the following regarding the migration of booking data:

  - Property names must not start with an underscore (“\_”) or contain any of the following characters: . # \* , " '<br>As such, the wizard will ask you to rename certain booking properties before starting the migration. To ensure the correct functionality of the Service & Resource Management module, some properties will be renamed automatically. For example, the *Visual.Background* and *Visual.Foreground* properties will automatically be renamed as *VisualBackground* and *VisualForeground*.

  - After migrating the booking data to the indexing database, make sure to check your Automation scripts and Visio files and adjust the booking property names where necessary.

  - After the migration is complete, you can use the *Retrieve report* button in the wizard to get a summary report of the migration.

  - An indexing database takes about twice as much disk space to store booking data compared to a Cassandra database.

> [!NOTE]
>
> - The indexing configuration is saved in the file *Indexing.xml* in the folder `C:\Skyline DataMiner\Database`.
> - To include booking data from the indexing database in a custom backup, select *Include SRM in backup* in the content tab of the *Backup* page. See [Configuring the DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups).
> - Resources and profiles are not automatically migrated to the indexing database as well. For more information on how to migrate these, see [Migrating SRM resources to the indexing database](xref:Resources_migration_to_elastic) and [Migrating SRM profiles to the indexing database](xref:Profile_migration_to_elastic).

> [!TIP]
> See also: [Indexing database settings](xref:DB_xml#indexing-database-settings)
