---
uid: Migrating_existing_data_to_STaaS
---

# Migrating existing data to STaaS

Before migrating your data over to STaaS, make sure you are aware of the [limitations](xref:STaaS_features#limitations) for migration. Then follow the procedure below:

1. Follow the [setup procedure](xref:Setting_up_StaaS) until you come to the step where you have received confirmation that the **registration is completed**.

1. Deploy the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02) from the DataMiner Catalog.

1. In the Automation module in DataMiner Cube, locate the *CloudStorageMigration* script and [execute the script](xref:Manually_executing_a_script).

   > [!NOTE]
   > When you run the Automation script on a Failover pair, make sure the currently active Agent is the main Failover Agent (i.e. the first Agent in the Failover configuration). Otherwise, the Automation script will not function correctly.

1. Initialize the migration:

   1. Optionally, configure a proxy for the migration if necessary. This is supported from DataMiner 10.4.6 onwards.

   1. Click *Init migration* to initialize the migration.

1. Start the migration:

   - Make sure *Replication only* is **not** selected.

   - Select the desired storage types for migration.

     > [!NOTE]
     > For systems with a lot of real-time trending, we urge you to consider if you really need this data to be migrated. This data is typically only stored for 1 day, so when there is a lot of data, this gives an overhead on the rest of the types that need to be migrated, and this can cause the migration to take longer.

   - Click *Start migration* to start the migration.

   The script will initiate the migration process, but the migration itself will not be completed immediately.

1. To monitor the migration progress, run the *CloudStorageMigrationProgress* script.

   This will log the progress of the migration for each storage type as information events.

1. Keep an eye on the progress until the status for all storage types that were triggered shows **State=Completed**.

   This indicates that the migration has successfully finished.

> [!NOTE]
> In case of issues during or after the migration, revert the *DB.xml* file to its previous state and re-trigger the migration process. If you want to be certain no data inconsistencies are possible, contact [STaaS support](mailto:staas@dataminer.services). For detailed troubleshooting information, refer to [Troubleshooting – STaaS](xref:Troubleshooting_STaaS).
