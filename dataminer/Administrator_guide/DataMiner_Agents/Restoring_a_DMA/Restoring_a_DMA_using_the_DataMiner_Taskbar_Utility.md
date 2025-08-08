---
uid: Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility
---

# Restoring a DMA using the DataMiner Taskbar Utility

1. Make sure the DMA is prepared for the restoration. See [Preparing the destination server for a DMA restoration](xref:Preparing_the_destination_server_for_a_DMA_restoration).

1. In the Windows taskbar, right-click the DataMiner Taskbar Utility icon and click *Maintenance \> Restore*.

1. In the *restore* window, click the *...* button to select a backup package.

    A description of the contents of the package will appear under *Description*.

1. Click *Restore* to start restoring the DMA.

   In the restore window, the different steps of the restoration process will be displayed.

1. When the restoration is complete, click *Finished*.

> [!IMPORTANT]
> If a DMA is connected to dataminer.services and you restore it on a new (virtual) server, additional configuration is needed. See [Maintaining the dataminer.services connection when restoring a DMA](xref:Maintaining_cloud_connection_when_restoring).

> [!NOTE]
> To also restore the database, additional steps are needed, depending on your setup:
>
> - OpenSearch: see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups).
> - Elasticsearch: see [Taking and restoring snapshots](xref:Configuring_Elasticsearch_backups_Windows_Linux).
> - Cassandra: see [Standalone Cassandra Backup tool](xref:Standalone_Cassandra_Backup_Tool).
>
> If you are using [Storage as a Service](xref:STaaS), there is no need to restore the database. If you want to restore your DataMiner Agent on a new (virtual) machine, contact <support@dataminer.services> to make sure your new setup is connected correctly.

> [!TIP]
> See also: [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility)
