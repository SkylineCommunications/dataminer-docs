---
uid: Configuring_DataMiner_Indexing
---

# Configuring indexing settings in DataMiner Cube

The indexing settings in System Center determine which information is stored in the indexing database. To configure these settings, go to *System Center* > *Search & Indexing*.

> [!TIP]
>
> - From DataMiner 10.3.0/10.3.3 onwards, for systems with a **dedicated clustered storage** setup, essential indexing database settings that are required to set up the database are available in System Center along with the general database settings. See [Configuring the general database settings](xref:Configuring_the_database_settings_in_Cube).
> - For earlier DataMiner versions or for setups with storage per DMA, the indexing setup is configured in *DB.xml*. See [indexing database settings](xref:DB_xml#indexing-database-settings).

The following settings are available:

- *Enable indexing on alarms:* Enables indexing of alarms. If this option is not enabled, the enhanced search options in the Alarm Console are not available.

- *Migrate booking data to Indexing Engine*: Starts a wizard that allows you to migrate booking data from the Cassandra database to the indexing database. Only displayed in case booking data have not been migrated yet.

  Please note the following regarding the migration of booking data:

  - Property names must not start with an underscore (“\_”) or contain any of the following characters: . # \* , " '<br>As such, the wizard will ask you to rename certain booking properties before starting the migration. To ensure the correct functionality of the Service & Resource Management module, some properties will be renamed automatically. For example, the *Visual.Background* and *Visual.Foreground* properties will automatically be renamed as *VisualBackground* and *VisualForeground*.

  - After migrating the booking data to the indexing database, make sure to check your Automation scripts and Visio files and adjust the booking property names where necessary.

  - After the migration is complete, you can use the *Retrieve report* button in the wizard to get a summary report of the migration.

  - An indexing database takes about twice as much disk space to store booking data compared to a Cassandra database.

> [!NOTE]
>
> - The indexing configuration is saved in the file *Indexing.xml* in the folder *C:\\Skyline DataMiner\\Database*.
> - To include booking data from the indexing database in a custom backup, select *Include SRM in backup* in the content tab of the *Backup* page. See [Configuring the DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups).
> - Resources are not automatically migrated to the indexing database as well. For more information on how to migrate these, see [Migrating SRM resources to the indexing database](xref:Resources_migration_to_elastic).

> [!TIP]
> See also: [Indexing database settings](xref:DB_xml#indexing-database-settings)
