---
uid: Migrating_existing_data_to_STaaS
reviewer: Alexander Verkest
description: "Follow these steps to migrate existing data to STaaS in DataMiner Cube using the CloudStorageMigration script."
---

# Migrating existing data to STaaS

Before migrating your data over to STaaS, make sure you are aware of the [limitations](xref:STaaS_features#limitations) for migration. Then follow the procedure below:

1. Follow the [setup procedure](xref:Setting_up_StaaS) until you come to the step where you have received confirmation that the **registration is completed**.

1. Deploy the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02) from the Catalog.

1. In the Automation module in DataMiner Cube, locate the *CloudStorageMigration* script and [execute the script](xref:Manually_executing_a_script).

   > [!NOTE]
   >
   > - When you run the automation script and there are Failover pairs in the cluster, make sure the **main Failover Agents** (i.e., the first Agent in the Failover configuration) are the **active** ones. Otherwise, the automation script will not function correctly.
   > - To migrate a **cluster**, you only need to start the migration on **one Agent**.

   > [!IMPORTANT]
   > For a separate Cassandra setup (see [storage options overview](xref:Supported_system_data_storage_architectures)), migration is supported from DataMiner 10.4.0 [CU17], 10.5.0 [CU5], and 10.5.8 onwards.<!-- RN 43325 -->

1. Initialize the migration:

   1. Optionally, configure a proxy for the migration if necessary. This is supported from DataMiner 10.4.6 onwards.

   1. Click *Start Move to STaaS* to initialize the migration.

1. Start the migration:

   - Select the desired storage types for migration.

     Prior to DataMiner 10.5.4/10.6.0, certain custom data, such as DOM, SRM, and Analytics data, are grouped together under the *custom_data* storage type and can only be migrated as a single category. From DataMiner 10.5.4/10.6.0 onwards<!--RN 42219-->, you can select specific storage types such as *DOM*, *SRM*, and *Analytics*, allowing you to migrate this data separately.

     > [!NOTE]
     > For systems with a **lot of real-time trending**, we urge you to consider if you really need this data to be migrated. This data is typically only stored for 1 day, so when there is a lot of data, this gives an overhead on the rest of the types that need to be migrated, and this can cause the migration to take longer.

   - Click *Start migration* to start the migration.

     ![CloudStorageMigration](~/dataminer/images/CloudStorageMigration.gif)<br>*CloudStorageMigration script in DataMiner 10.5.4*

   The script will initiate the migration process, but the migration itself will not be completed immediately.

1. To monitor the migration progress, run the *CloudStorageMigrationProgress* script.

   This will log the progress of the migration for each storage type as information events.

1. Keep an eye on the progress until the status for all storage types that were triggered shows **State=Completed**.

   This indicates that the migration has successfully finished.

1. When all storage types report **State=Completed**, from DataMiner 10.6.8/10.7.0 onwards<!-- RN 45507 -->, run the *CloudStorageMigrationFinalize* script.

   This script will finalize the migration by migrating some configuration data, doing some checks, etc. After you have run the script, **immediately continue with the next steps** because any configuration changes done after this finalization and before the next restart might otherwise be lost.

1. Continue with the next step of the [setup procedure](xref:Setting_up_StaaS).

> [!NOTE]
> In case of issues during or after the migration, revert the *DB.xml* file to its previous state and re-trigger the migration process. If you want to be certain no data inconsistencies are possible, contact <support@dataminer.services>. For detailed troubleshooting information, refer to [Troubleshooting – STaaS](xref:Troubleshooting_STaaS).
