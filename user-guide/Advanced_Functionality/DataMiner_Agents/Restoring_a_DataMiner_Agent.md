---
uid: Restoring_a_DataMiner_Agent
---

# Restoring a DataMiner Agent

Restoring a DataMiner Agent can be done with the [Taskbar Utility](xref:Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility), or manually, depending on the way the backup was taken. If you do not restore the DMA using the Taskbar Utility and you are using self-hosted storage nodes instead of [Storage as a Service](xref:STaaS), the [database](xref:Restoring_the_database_only) and [configuration](xref:Restoring_the_DMA_configuration_only) need to be restored separately. If you do use Storage as a Service, there is no need to restore the database.

You can restore a DMA either on the same (virtual) machine or on a new one. If you use [Storage as a Service](xref:STaaS) and want to restore your DataMiner Agent on a new (virtual) machine, contact <staas@dataminer.services> to make sure your new setup is connected correctly.

Before restoring a DataMiner Agent, you need to [prepare the destination server](xref:Preparing_the_destination_server_for_a_DMA_restoration) so that it is clean and ready for installation.

> [!NOTE]
> For information on how to back up and restore an OpenSearch or Elasticsearch database, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups) or [Configuring Elasticsearch backups](xref:Configuring_Elasticsearch_backups), respectively.

> [!TIP]
> See also: [Backup – Restoring and migrating a DataMiner Agent](https://community.dataminer.services/video/backup-restoring-and-migrating-a-dataminer-agent/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
