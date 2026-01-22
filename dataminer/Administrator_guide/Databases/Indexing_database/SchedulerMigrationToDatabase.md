---
uid: SchedulerMigrationToDatabase
---

# Migrating scheduled tasks to database

Starting with DataMiner version 10.6.3/10.7.0, it is possible to migrate existing scheduled tasks from scheduler.xml to database storage. Supported database options include Cassandra cluster or STaaS (see [Scheduler data storage](xref:SchedulerDataStorage)).

## Migrating from XML to database

To migrate scheduled tasks, the SLNetClientTest tool can be used. 

![SLNetClientTest tool](~/dataminer/images/ClientTestToolMigrationUI_SchedulerMigration.png)<br>
*Migration window in SLNetClientTest tool (version 10.6.3)*

> [!WARNING]
>
> - Use this tool with extreme caution, as it can significantly impact your DataMiner System.
> - Scheduler will be restarted during the migration. 
> - Incoming requests to the Scheduler Manager will be blocked while the migration is in progress. 

1. Connect to the DMS using the *SLNetClientTest* tool:

    1. In the *SLNetClientTest* tool, go to *Connection* > *Connect*.

    1. In the *Connect* window, under *Authentication*, select *Explicit credentials* and specify the credentials of an administrator user.
 
    1. Click the *Connect* button.

1. From the *Advanced* menu, select *Migration*.

1. In the *Scheduler XML to database* section, click the *Start Migration* button to launch the migration wizard.

   - During migration, **no scheduled tasks will be triggered**, though tasks already running will continue executing. It is however advised not to start a migration when this is the case. 
   
   - A window will show the migration actions that have been scheduled. If you close this window, the migration will continue in the background. To cancel the migration, click the Cancel Migration button.

   - The progress of the migration will be shown in the *MigrationStatus* table in client test tool, where a row will be created for each agent in the cluster where the scheduled tasks will be migrated. 

   - If one of the DataMiner agents in the cluster cannot be reached for some reason, the migration will be canceled.

   - Once the migration completes on all agents, the storage will automatically switch from XML to database, and incoming messages will be unblocked.

> [!NOTE]
>
> - You can cancel the migration process at any time by clicking the *Cancel Migration* button in the *Scheduler XML to database* section.

### Troubleshooting

If the migration fails for any reason, the migration status object in the SLNetClientTest tool window will get a red background color. The ``SLMigrationManager.txt`` and ``SLScheduler.txt`` log files will contain more information. Scheduler Manager will not switch the configuration, so XML storage will still be used after a failed migration.

If a ``MigrationStatus`` is stuck in the ``InProgress`` state, you will need to cancel the migration to make all Scheduler Manager instances start or to trigger the migration again. You can do so with the *Cancel Migration* button in the *Scheduler XML to database* section of the SLNetClientTest tool window.

### Behavior in new installations

When a new DataMiner Agent is installed, the used storage type for scheduled tasks will be XML.

## Checking the storage type used by a DataMiner Agent

To verify the storage type used by an agent, check the configuration file in `C:\Skyline DataMiner\Scheduler\Config.xml`. For more details, see [Scheduler data storage](xref:SchedulerDataStorage).
